using backendGameHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendGameHub.Data.Seed;

public class SeedEquipo : IEntityTypeConfiguration<Equipo>
{
    public void Configure(EntityTypeBuilder<Equipo> builder)
    {
        builder.HasData(
            new Equipo { equipoId = 1, nombre = "PC Gamer Delios", modelo = "50i", marca = "DELL", disponibilidadId = 1 },
            new Equipo { equipoId = 2, nombre = "Alienware Aurora", modelo = "R11", marca = "DELL", disponibilidadId = 1 },
            new Equipo { equipoId = 3, nombre = "HP Omen", modelo = "30L", marca = "HP", disponibilidadId = 1 },
            new Equipo { equipoId = 4, nombre = "ASUS ROG Strix", modelo = "G15", marca = "ASUS", disponibilidadId = 1 },
            new Equipo { equipoId = 5, nombre = "MSI Trident 3", modelo = "Arctic", marca = "MSI", disponibilidadId = 3 },

            // Consolas
            new Equipo { equipoId = 6, nombre = "Xbox Series S", modelo = "1TB", marca = "Microsoft", disponibilidadId = 1 },
            new Equipo { equipoId = 7, nombre = "Xbox Series S", modelo = "1TB", marca = "Microsoft", disponibilidadId = 1 },
            new Equipo { equipoId = 8, nombre = "Xbox Series S", modelo = "1TB", marca = "Microsoft", disponibilidadId = 1 },
            new Equipo { equipoId = 9, nombre = "Xbox Series S", modelo = "1TB", marca = "Microsoft", disponibilidadId = 1 },
            new Equipo { equipoId = 10, nombre = "Xbox Series S", modelo = "1TB", marca = "Microsoft", disponibilidadId = 3 }
        );
    }   
}