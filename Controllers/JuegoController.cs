using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendGameHub.Data;
using backendGameHub.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data.Common;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Recepcionista,Administrador")]
public class JuegosController : ControllerBase
{
    private readonly IdentityContext _context;

    public JuegosController(IdentityContext context)
    {
        _context = context;
    }

   [HttpGet]
   [Authorize(Roles = "Administrador, Recepcionista")]
   public async Task<ActionResult<IEnumerable<Juego>>> GetJuego(string? s)
   {
    IQueryable<Juego> query = _context.Juegos.Include(j => j.estatus).Include(j => j.categorias);

    if (string.IsNullOrEmpty(s))
    {
        return await query.AsNoTracking().ToListAsync();
    }
    else
    {
        int estatusId = int.Parse(s);
        return await query.Where(j => j.estatusId == estatusId).AsNoTracking().ToListAsync();
    }
}
[HttpGet("{id}")]
[Authorize(Roles = "Administrador, Recepcionista")]
public async Task<ActionResult<Juego>> GetJuego(int id)
{
    var juego = await _context.Juegos
        .Include(j => j.estatus)
        .AsNoTracking()
        .FirstOrDefaultAsync(j => j.juegoId == id);

    if (juego == null)
    {
        return NotFound();
    }

    return juego;
}




    [HttpPost]
    public async Task<ActionResult<Juego>> PostJuego(Juego juego)
    {
        _context.Juegos.Add(juego);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetJuego), new { id = juego.juegoId }, juego);
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Recepcionista")]
    public async Task<IActionResult> PutJuego(int id, JuegoDTO juegoDTO){
        if(id != juegoDTO.juegoId){
            return BadRequest();
        }

        var juego = await _context.Juegos.Include(i => i.estatus).FirstOrDefaultAsync(s => s.juegoId == id);
        if(juego == null){
            return NotFound();
        }
        
        juego.nombre_juego = juegoDTO.nombre_juego;
        juego.plataforma = juegoDTO.plataforma;
        juego.descripcion = juegoDTO.descripcion;
        juego.url_imagen = juegoDTO.url_imagen;
        juego.estatusId = juegoDTO.estatusId;

        try{
            await _context.SaveChangesAsync();
        }catch(DbException ex){
            Console.WriteLine(ex.Message);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJuego(int id)
    {
        var juego = await _context.Juegos.FindAsync(id);
        if (juego == null)
        {
            return NotFound();
        }

        _context.Juegos.Remove(juego);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool JuegoExists(int id)
    {
        return _context.Juegos.Any(e => e.juegoId == id);
    }
}
