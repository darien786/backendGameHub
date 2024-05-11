namespace backendGameHub.Models;

public class Equipo
{
    public int equipoId { get; set; }
    public required string nombre { get; set; }
    public required string modelo { get; set; }
    public required string marca { get; set; }
    public required string disponibilidad { get; set; }
    public required string estatus { get; set; }

}