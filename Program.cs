using Microsoft.EntityFrameworkCore;
using backendGameHub.Data;
using backendGameHub.Models;
using backendGameHub.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backendGameHub.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DataContext");
builder.Services.AddDbContext<IdentityContext>(options => {
    options.UseNpgsql(connectionString);
});
builder.Services.AddScoped<JwtTokenService>();

//Soporte para Identity
builder.Services.AddIdentity<CustomIdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
    //como quieren que se maneje las contraseña
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
})
    .AddEntityFrameworkStores<IdentityContext>();
   
//Soporte para JWT
builder.Services
    .AddHttpContextAccessor() // para poder acceder al HtppContext()
    .AddAuthorization() // para autorizar en cada metodo el acceso
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme =  JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
        };
    });

//Agrega el soporte para CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
            .AllowAnyHeader()
            .WithMethods("GET", "POST", "PUT", "DELETE");
        }
    );
});

//agrega la funcionalidad de controladores
builder.Services.AddControllers();

// Agrregar la documentacion del API
builder.Services.AddSwaggerGen();
//contruye la app web
var app = builder.Build();

// Si queremos mostrar la documentacion de la API en la raiz 
if (app.Environment.IsDevelopment()){
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}

//si queremos mostrar la documentación de la API en laraiz

//Redirige a HTTPS
app.UseHttpsRedirection();

//utiliza rutas para los endpoints de los controladores
app.UseRouting();
//Utiliza Autenticación
app.UseAuthentication();

//Utiliza autorización
app.UseAuthorization();

app.UseSlidingExpirationJwt();
//Usa CORS con la policy definida anteriormente
app.UseCors();
//establece el uso de tutas sin especificar una por defult
app.MapControllers();

app.Run();