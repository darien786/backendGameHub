using backendGameHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendGameHub.Data.Seed;

public class SeedEstatus : IEntityTypeConfiguration<Estatus>
{
    public void Configure(EntityTypeBuilder<Estatus> builder)
    {
        builder.HasData(
            new Estatus{ estatusId = 1, nombre_estatus = "Activo"},
            new Estatus{ estatusId = 2, nombre_estatus = "Inactivo"}
        );
    }   
}