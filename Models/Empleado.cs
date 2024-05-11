
namespace backendGameHub.Models;

public class Empleado 
{
    public int empleadoId { get; set; }
    public required string curp { get; set; }
    public required string sexo { get; set; }
    public required string correo { get; set; }
    public required string username { get; set; }
    public required string password { get; set; }
    public required string fecha_ingreso { get; set; }
    public string? fecha_baja { get; set; }
    public int estatusId { get; set; }
    public Estatus? estatus { get; set; }
    public int personaId { get; set; }
    public Persona? persona { get; set; }
    public int rolId { get; set;}
    public Rol? rol { get; set;}
}