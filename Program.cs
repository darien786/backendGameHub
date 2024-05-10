using backendGameHub.Models;
using backendGameHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DataContext");
builder.Services.AddDbContext<IdentityContext>(options => {
    options.UseNpgsql(connectionString);
});

builder.Services.AddIdentity<CustomIdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
})
.AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:3001", "https://localhost:8080")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithMethods("GET", "POST", "PUT", "DELETE");
    });
});

builder.Services.AddControllers();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.UseCors();

app.MapControllers();
app.Run();