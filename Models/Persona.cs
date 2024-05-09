using System.Text.Json.Serialization;

namespace backendGameHub.Models;

public class Persona 
{
public int personaId { get; set; }
public required string nombre { get; set; }
public required string apellido_paterno { get; set;}
public required string apellido_materno { get; set; }
public required string telefono { get; set; }


[JsonIgnore]
public ICollection<Empleado> empleados { get; set; }
}