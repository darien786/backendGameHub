using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using backendGameHub.Services;

namespace backendGameHub.Middlewares;

public class SlidingExpirationJwt(RequestDelegate next)
{
    public async Task InvokeAsync (HttpContext context, JwtTokenService jwtTokenService)
    {
       try{
        string authorization = context.Request.Headers.Authorization!;
        JwtSecurityToken? token = null;
        if(!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
            token = new JwtSecurityTokenHandler().ReadJwtToken(authorization[7..]);
        if (token != null && token.ValidTo > DateTime.UtcNow)
        {
            TimeSpan timeRemaining = token.ValidTo.Subtract(DateTime.UtcNow);
            //Si quedan 5 minutos, le damos un nuevo token
            if (timeRemaining.Minutes <= 5)
            {
                var claims = new List<Claim>
                {
                    new (ClaimTypes.Name, context.User.FindFirstValue(ClaimTypes.Name)!),
                    new (ClaimTypes.GivenName, context.User.FindFirstValue(ClaimTypes.GivenName)!),
                    new (ClaimTypes.Role, context.User.FindFirstValue(ClaimTypes.Role)!)
                };
                context.Response.Headers.Append("Set-Authorization", jwtTokenService.GenerateToken(claims));
            }
        }
        
       }
       catch (Exception)
       {
           //ocurrio un fallo al revisar el token
       }
       await next(context);
    }
}

//Esta clase es para agregarlo en Program.cs
    public static class SlidingExpirationJwtExtensions
    {
        public static IApplicationBuilder UseSlidingExpirationJwt(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SlidingExpirationJwt>();
        }
    }