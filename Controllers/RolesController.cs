using backendGameHub.Data;
using backendGameHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendGameHub.Controllers;

[ApiController]
[Route("api/[controller]")]

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
