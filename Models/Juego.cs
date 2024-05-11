using System.Text.Json.Serialization;

namespace backendGameHub.Models;

public class Juego{

    public int juegoId { get; set; }
    public required string nombre_juego { get; set; }
    public required string plataforma { get; set; }
    public required string categoria { get; set; }
    public required string descripcion { get; set; }
    public required string estatus { get; set; }
    public required string url_imagen { get; set; }

    [JsonIgnore]
    public ICollection<Categoria>? categorias { get; set; }
}