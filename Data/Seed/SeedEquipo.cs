using backendGameHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendGameHub.Data.Seed;

public class SeedEquipo : IEntityTypeConfiguration<Equipo>
{
    public void Configure(EntityTypeBuilder<Equipo> builder)
    {
        builder.HasData(
            new Equipo { equipoId = 1, nombre = "PC Gamer Delios", url_imagen = "https://th.bing.com/th/id/OIP.pqgvcdzTUqEg1Dn4TB6p9QHaHa?rs=1&pid=ImgDetMain", modelo = "50i", marca = "DELL", disponibilidadId = 1 },
            new Equipo { equipoId = 2, nombre = "Alienware Aurora", url_imagen = "https://th.bing.com/th/id/OIP.ybUvOyf2tQLPRjKpvZqhPgHaHa?rs=1&pid=ImgDetMain", modelo = "R11", marca = "DELL", disponibilidadId = 1 },
            new Equipo { equipoId = 3, nombre = "HP Omen", url_imagen = "https://th.bing.com/th/id/OIP.kuD2oV-5Gh6pxBKcC5BltAHaFj?rs=1&pid=ImgDetMain", modelo = "30L", marca = "HP", disponibilidadId = 1 },
            new Equipo { equipoId = 4, nombre = "ASUS ROG Strix", url_imagen = "https://th.bing.com/th/id/R.62ff86997b0fa6088ffdd0cc6c50db28?rik=k3MAQ1hNeojL7A&pid=ImgRaw&r=0", modelo = "G15", marca = "ASUS", disponibilidadId = 1 },
            new Equipo { equipoId = 5, nombre = "MSI Trident 3", url_imagen = "https://www.bhphotovideo.com/images/images2500x2500/msi_mpg_trident_3_12tc_007us_trident_3_i7f_3060_1709605.jpg", modelo = "Arctic", marca = "MSI", disponibilidadId = 3 },

            // Consolas
            new Equipo { equipoId = 6, nombre = "Xbox Series S", url_imagen="https://th.bing.com/th/id/R.2abcd1e0694b7d96057df2ffc77b5ac9?rik=MtyoTVw3ZbrXYw&pid=ImgRaw&r=0", modelo = "1TB", marca = "Microsoft", disponibilidadId = 1 },
            new Equipo { equipoId = 7, nombre = "Xbox Series S", url_imagen="https://th.bing.com/th/id/R.2abcd1e0694b7d96057df2ffc77b5ac9?rik=MtyoTVw3ZbrXYw&pid=ImgRaw&r=0", modelo = "1TB", marca = "Microsoft", disponibilidadId = 1 },
            new Equipo { equipoId = 8, nombre = "Xbox Series S", url_imagen="https://th.bing.com/th/id/R.2abcd1e0694b7d96057df2ffc77b5ac9?rik=MtyoTVw3ZbrXYw&pid=ImgRaw&r=0", modelo = "1TB", marca = "Microsoft", disponibilidadId = 1 },
            new Equipo { equipoId = 9, nombre = "Xbox Series S", url_imagen="https://th.bing.com/th/id/R.2abcd1e0694b7d96057df2ffc77b5ac9?rik=MtyoTVw3ZbrXYw&pid=ImgRaw&r=0", modelo = "1TB", marca = "Microsoft", disponibilidadId = 1 },
            new Equipo { equipoId = 10, nombre = "Xbox Series S", url_imagen="https://th.bing.com/th/id/R.2abcd1e0694b7d96057df2ffc77b5ac9?rik=MtyoTVw3ZbrXYw&pid=ImgRaw&r=0", modelo = "1TB", marca = "Microsoft", disponibilidadId = 3 }
        );
    }   
}