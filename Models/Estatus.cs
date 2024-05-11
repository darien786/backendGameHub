using System.Text.Json.Serialization;

namespace backendGameHub.Models;

public class Estatus
{
    public int estatusId { get; set; }
    public required string nombre_estatus { get; set; }

    [JsonIgnore]
    public ICollection<Empleado>? empleados { get; set; }
    public ICollection<Juego>? juegos { get; set; }
    public ICollection<Equipo>? equipos { get; set; }

}