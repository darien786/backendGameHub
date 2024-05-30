using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backendGameHub.Models;
using backendGameHub.Data;
using Microsoft.AspNetCore.Authorization;

namespace backendGameHub.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Recepcionista, Administrador")]
public class EquiposController : Controller{

    private readonly IdentityContext _context;

    public EquiposController(IdentityContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipos(string? s){
       if(string.IsNullOrEmpty(s)){
           return await _context.Equipos.Include(i => i.disponibilidad).AsNoTracking().ToListAsync();
       }

       return await _context.Equipos.Include(i => i.disponibilidad).Where(w => w.disponibilidadId == int.Parse(s)).AsNoTracking().ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Equipo>> GetEquipo(int id){
        var equipo = await _context.Equipos.Include(i => i.disponibilidad).AsNoTracking().FirstOrDefaultAsync(w => w.equipoId == id);
    
        if(equipo == null){
            return NotFound();
        }
        return equipo;
    }
}

