using backendGameHub.Models;
using backendGameHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace backendGameHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : Controller
{
    private readonly IdentityContext _context;
    private readonly UserManager<CustomIdentityUser> _userManager;

    public EmpleadosController(IdentityContext context, UserManager<CustomIdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    //GET: api/empleados
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomIdentityUserDTO>>> GetEmpleados()
    {
        var usuarios = new List<CustomIdentityUserDTO>();

        foreach (var usuario in await _context.Users.AsNoTracking().ToListAsync())
        {
            usuarios.Add(new CustomIdentityUserDTO
            {
                Id = usuario.Id,
                username = usuario.UserName,
                nombre = usuario.nombre,
                rol = GetUserRol(usuario)
            });
        }

        return usuarios;
    }

    //GET: api/empleados/username
    [HttpGet("{username}")]
    public async Task<ActionResult<CustomIdentityUserDTO>> GetUsuario(string username)
    {
        var usuario = await _userManager.FindByEmailAsync(username);

        if(usuario == null) return NotFound();

        return new CustomIdentityUserDTO
        {
            Id = usuario.Id,
            username = usuario.UserName,
            nombre = usuario.nombre,
            rol = GetUserRol(usuario)
        };
    
    }

    private string GetUserRol(CustomIdentityUser usuario)
    {
        var roles = _userManager.GetRolesAsync(usuario).Result;
        return roles.First();
    }


    //POST: api/empleados
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