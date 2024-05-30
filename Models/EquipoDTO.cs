namespace backendGameHub.Models;

public class EquipoDTO
{
    public int equipoId { get; set; }
    public required string nombre { get; set; }
    public string url_imagen { get; set; } = "N/A";
    public string modelo { get; set; } = "Sin modelo";
    public string marca { get; set; } = "Sin marca";
    public int? disponibilidadId { get; set; }
    public string? nombre_disponibilidad { get; set; } = "N/A";
}