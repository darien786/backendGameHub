using System.Text.Json.Serialization;

namespace backendGameHub.Models;

public class Categoria
{
    public int categoriaId { get; set; }
    public required string nombre_categoria { get; set; }
 
    [JsonIgnore]
    public ICollection<Juego>? juegos { get; set; }
}