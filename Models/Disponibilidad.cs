using System.Text.Json.Serialization;

namespace backendGameHub.Models;

public class Disponibilidad
{
    public int disponibilidadId { get; set; }
    public required string nombre_disponibilidad { get; set; }

    [JsonIgnore]
    public ICollection<Equipo>? equipos { get; set; }
}