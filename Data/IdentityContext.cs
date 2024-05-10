using backendGameHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using backendGameHub.Data.Seed;

namespace backendGameHub.Data;

public class IdentityContext : IdentityDbContext<CustomIdentityUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    public DbSet<Estatus> Estatus { get; set; }
    public DbSet<Rol> Rol { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Persona> Personas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new SeedEstatus());
        builder.ApplyConfiguration(new SeedRoles());
        builder.SeedUserIdentityData();

        base.OnModelCreating(builder);
    }


}