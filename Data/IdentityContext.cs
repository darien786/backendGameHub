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
    public DbSet<Disponibilidad> Disponibilidad { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Equipo> Equipos { get; set; }
    public DbSet<Juego> Juegos { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new SeedEstatus());
        builder.ApplyConfiguration(new SeedDisponibilidad());
        builder.ApplyConfiguration(new SeedEquipo());
        builder.SeedUserIdentityData();

        base.OnModelCreating(builder);
    }


}