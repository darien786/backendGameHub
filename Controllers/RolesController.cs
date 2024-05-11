using backendGameHub.Data;
using backendGameHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendGameHub.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrador")]

public class RolesController : ControllerBase
{
    private readonly IdentityContext _context;

    public RolesController(IdentityContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Rol>>> Get()
    {
        return await _context.Rol.AsNoTracking().ToListAsync();
    }
}
