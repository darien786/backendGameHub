using System.Text.Json.Serialization;

namespace backendGameHub.Models;

public class Rol
{
    public int rolId { get; set; }
    public required string nombre_rol { get; set; }

    [JsonIgnore]
    public ICollection<Empleado>? empleados { get; set; }
}