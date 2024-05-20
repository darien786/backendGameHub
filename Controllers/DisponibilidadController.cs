using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backendGameHub.Models;
using backendGameHub.Data;
using Microsoft.AspNetCore.Authorization;

namespace backendGameHub.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrador")]
public class DisponibilidadController : Controller{

    private readonly IdentityContext _context;

    public DisponibilidadController(IdentityContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Disponibilidad>>> Get(){
        return await _context.Disponibilidad.AsNoTracking().ToListAsync();
    }

}