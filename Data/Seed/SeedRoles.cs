using  backendGameHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendGameHub.Data.Seed;

public class SeedRoles : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.HasData(
            new Rol{ rolId = 1, nombre_rol = "Administrador"},
            new Rol{ rolId = 2, nombre_rol = "Recepcionista"}
        );
    }
}