using backendGameHub.Models;
using backendGameHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendGameHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : ControllerBase
{
    private readonly DataContext _context;

    public EmpleadosController(DataContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> Get()
    {
        return await _context.Empleado
            .Select(x => obtenerEmpleado(x))
            .ToListAsync();
    }

    //GET: api/empleados/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Empleado>> Get(int id)
    {
        var empleados = await _context.Empleado.FindAsync(id);

        if (empleados == null)
        {
            return NotFound();
        }

        return empleados;
    }

    private static EmpleadoDTO obtenerEmpleado(Empleado empleados) => 
    new EmpleadoDTO 
    {
        empleadoId = empleados.empleadoId,
        sexo = empleados.sexo,
        curp = empleados.curp,
        correo = empleados.correo,
        username = empleados.username,
        password = empleados.password,
        fecha_ingreso = empleados.fecha_ingreso,
        fecha_baja = empleados.fecha_baja,
        estatusId = empleados.estatusId,
        personaId = empleados.personaId,
        rolId = empleados.rolId
    };
}