using Microsoft.EntityFrameworkCore;
using backendGameHub.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DataContext");
builder.Services.AddDbContext<DataContext>(options => {
    options.UseNpgsql(connectionString);
});

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