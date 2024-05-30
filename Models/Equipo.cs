using System.Text.Json.Serialization;

namespace backendGameHub.Models;

public class Equipo
{
    public int equipoId { get; set; }
    public string nombre { get; set; } = "Sin nombre";
    public string url_imagen { get; set; } = "N/A";
    public string modelo { get; set; } = "Sin modelo";
    public string marca { get; set; } = "Sin marca";
    public int? disponibilidadId { get; set; }
    public Disponibilidad? disponibilidad { get; set; }
}