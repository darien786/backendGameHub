using backendGameHub.Models;
using backendGameHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace backendGameHub.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrador")]
public class UsuariosController : Controller
{

    private readonly IdentityContext _context;
    private readonly UserManager<CustomIdentityUser> _userManager;

    public UsuariosController(IdentityContext context, UserManager<CustomIdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    //GET: api/empleados
    //[HttpGet]
    public async Task<ActionResult<IEnumerable<CustomIdentityUserDTO>>> obtenerUsuariosGET()
    {
        var usuarios = new List<CustomIdentityUserDTO>();

        foreach (var usuario in await _context.Users.AsNoTracking().ToListAsync())
        {
            usuarios.Add(new CustomIdentityUserDTO
            {
                Id = usuario.Id,
                username = usuario.UserName!,
                nombre = usuario.nombre,
                rol = obtenerRolUsuario(usuario)
            });
        }

        return usuarios;
    }

    //GET: api/empleados/username
    [HttpGet("{username}")]
    public async Task<ActionResult<CustomIdentityUserDTO>> obtenerUsuarioPorUsername(string username)
    {
        var usuario = await _userManager.FindByEmailAsync(username);

        if(usuario == null) return NotFound();

        return new CustomIdentityUserDTO
        {
            Id = usuario.Id,
            username = usuario.UserName!,
            nombre = usuario.nombre,
            rol = obtenerRolUsuario(usuario)
        };
    
    }

    private string obtenerRolUsuario(CustomIdentityUser usuario)
    {
        var roles = _userManager.GetRolesAsync(usuario).Result;
        return roles.First();
    }
}