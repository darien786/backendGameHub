using System.Text.Json.Serialization;

namespace backendGameHub.Models;

public class Estatus
{
    public int estatusId { get; set; }
    public string nombre_estatus { get; set; } = "Sin nombre";
    [JsonIgnore]
    public ICollection<Juego>? juegos { get; set; }
}