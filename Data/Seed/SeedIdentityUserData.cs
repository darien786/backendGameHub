using backendGameHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace backendGameHub.Data.Seed;

public static class SeedIdentityUserData
{
    public static void SeedUserIdentityData(this ModelBuilder modelBuilder){
        string AdministradorRoleId = Guid.NewGuid().ToString();
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = AdministradorRoleId,
            Name = "Administrador",
            NormalizedName = "ADMINISTRADOR".ToUpper()
        });

        string UsuarioRoleId = Guid.NewGuid().ToString();
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = UsuarioRoleId,
            Name = "Recepcionista",
            NormalizedName = "RECEPCIONISTA".ToUpper()
        });

        var UsuarioId = Guid.NewGuid().ToString();
        modelBuilder.Entity<CustomIdentityUser>().HasData(new CustomIdentityUser
        {
            Id = UsuarioId,
            UserName = "zkorpio12",
            Email = "zkorpio12",
            NormalizedEmail = "zkorpio12".ToUpper(),
            nombre = "Uriel Velasco",
            NormalizedUserName = "zkorpio12".ToUpper(),
            PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "123456"),
            protegido = true
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> 
            {
                RoleId = AdministradorRoleId,
                UserId = UsuarioId
            }
            );

        UsuarioId = Guid.NewGuid().ToString();
        modelBuilder.Entity<CustomIdentityUser>().HasData(
            new CustomIdentityUser
            {
                Id = UsuarioId,
                UserName = "patito123",
                Email = "patito123",
                NormalizedEmail = "patito123".ToUpper(),
                nombre = "Pato Gonzalez Perez",
                NormalizedUserName = "patito123".ToUpper(),
                PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "123456")
            }
        );
        
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = UsuarioRoleId,
                UserId = UsuarioId
            });
    }
}