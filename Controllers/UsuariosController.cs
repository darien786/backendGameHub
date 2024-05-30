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
    [HttpGet]
    [Authorize(Roles = "Administrador")]
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
    [Authorize(Roles = "Administrador")]
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

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<CustomIdentityUserDTO>> PostUsuario(CustomIdentityUserPwdDTO usuarioDTO){

        var usuarioToCreate = new CustomIdentityUser
        {
            UserName = usuarioDTO.username,
            Email = usuarioDTO.username,
            NormalizedUserName = usuarioDTO.username.ToUpper(),
            NormalizedEmail = usuarioDTO.username.ToUpper(),
            nombre = usuarioDTO.nombre
        };

        IdentityResult result = await _userManager.CreateAsync(usuarioToCreate, usuarioDTO.password);
        if(!result.Succeeded) return BadRequest(new {Mensaje = "Registro fallido"});

        result = await _userManager.AddToRoleAsync(usuarioToCreate, usuarioDTO.rol);
        if(!result.Succeeded) return BadRequest(new {error = "Rol no asignado"});

        var usuarioViewModel = new CustomIdentityUserDTO
        {
            Id = usuarioToCreate.Id,
            username = usuarioToCreate.UserName!,
            nombre = usuarioToCreate.nombre,
            rol = usuarioDTO.rol
        };

        return CreatedAtAction(nameof(obtenerUsuarioPorUsername), new { username = usuarioToCreate.UserName }, usuarioViewModel);
    }

    [HttpPut("{username}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> PutUsuario(string username, CustomIdentityUserPwdDTO usuarioDTO){
        if(username != usuarioDTO.username) return BadRequest();

        var usuario = await _userManager.FindByEmailAsync(username);
        if(usuario == null) return NotFound();

        if(await _context.Roles.Where(r => r.Name == usuarioDTO.rol).FirstOrDefaultAsync() == null) return BadRequest();

        usuario.nombre = usuarioDTO.nombre;
        usuario.NormalizedUserName = usuarioDTO.username.ToUpper();
        IdentityResult result = await _userManager.UpdateAsync(usuario);
        if(!result.Succeeded) return BadRequest();

        if(!await _userManager.IsInRoleAsync(usuario, usuarioDTO.rol))
            await _userManager.AddToRoleAsync(usuario, usuarioDTO.rol);

        return NoContent();
    }

    [HttpDelete("{username}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> DeleteUsuario(string username){
        var usuario = await _userManager.FindByEmailAsync(username);
        if(usuario == null) return NotFound();
        
        if(usuario.protegido) return StatusCode(StatusCodes.Status403Forbidden);

        IdentityResult result = await _userManager.DeleteAsync(usuario);
        if(!result.Succeeded) return BadRequest();

        return NoContent();
    }

    private string obtenerRolUsuario(CustomIdentityUser usuario)
    {
        var roles = _userManager.GetRolesAsync(usuario).Result;
        return roles.First();
    }

}