namespace backendGameHub.Models;

public class PersonaDTO
{
    public int? personaId { get; set; }
    public required string nombre { get; set; }
    public required string apellido_paterno { get; set;}
    public required string apellido_materno { get; set; }
    public required string telefono { get; set; }
}