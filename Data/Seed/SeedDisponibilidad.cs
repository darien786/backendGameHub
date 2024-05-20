using backendGameHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendGameHub.Data.Seed;

public class SeedDisponibilidad : IEntityTypeConfiguration<Disponibilidad>{

    public void Configure(EntityTypeBuilder<Disponibilidad> builder)
    {
        builder.HasData(
            new Disponibilidad{ disponibilidadId = 1, nombre_disponibilidad = "Disponible"},
            new Disponibilidad{ disponibilidadId = 2, nombre_disponibilidad = "Ocupado"},
            new Disponibilidad{ disponibilidadId = 3, nombre_disponibilidad = "En mantenimiento"}
        );
    }
}