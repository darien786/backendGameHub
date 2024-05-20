using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backendGameHub.Data;
using backendGameHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace backendGameHub.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController : Controller
{
    private readonly IdentityContext _context;
    private readonly UserManager<CustomIdentityUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthController(IdentityContext context, UserManager<CustomIdentityUser> userManager, IConfiguration configuration){
        _context = context;
        _userManager = userManager;
        _configuration = configuration;       
    }

    [HttpPost]
    public async Task<ActionResult> inicioSesion([FromBody] LoginDTO loginDTO)
    {
        var usuario = await _userManager.FindByNameAsync(loginDTO.username);

        if (usuario is null || !await _userManager.CheckPasswordAsync(usuario, loginDTO.password))
        {
            return Unauthorized(new { mensaje = "Credenciales incorrectas." });
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, usuario.UserName!),
            new(ClaimTypes.GivenName, usuario.nombre!),
        };

        var roles = await _userManager.GetRolesAsync(usuario);
        foreach (var rol in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, rol));
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
     
        return Ok(new {
            usuario.UserName,
            usuario.nombre,
            rol = string.Join(",", roles),
            token
        });   
    }
}