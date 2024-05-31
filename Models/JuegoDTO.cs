namespace backendGameHub.Models;

public class JuegoDTO
{
    public int id { get; set; }
    public required string nombre_juego { get; set; } = "Sin nombre";
    public string plataforma { get; set; } = "N/A";
    public string descripcion { get; set; } = "Sin descripcion";
    public string url_imagen { get; set; } = "N/A";
    public int[]? CategoriasJuegos { get; set; }
    public string[]? nombre_categoria { get; set; }

}