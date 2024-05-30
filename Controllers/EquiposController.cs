using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backendGameHub.Models;
using backendGameHub.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data.Common;

namespace backendGameHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquiposController : Controller{

    private readonly IdentityContext _context;

    public EquiposController(IdentityContext context){
        _context = context;
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Recepcionista")]
    public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipos(string? s){
       if(string.IsNullOrEmpty(s)){
           return await _context.Equipos.Include(i => i.disponibilidad).AsNoTracking().ToListAsync();
       }

       return await _context.Equipos.Include(i => i.disponibilidad).Where(w => w.disponibilidadId == int.Parse(s)).AsNoTracking().ToListAsync();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador, Recepcionista")]
    public async Task<ActionResult<Equipo>> GetEquipo(int id){
        var equipo = await _context.Equipos.Include(i => i.disponibilidad).AsNoTracking().FirstOrDefaultAsync(w => w.equipoId == id);
    
        if(equipo == null){
            return NotFound();
        }
        return equipo;
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<Equipo>> PostEquipo(EquipoDTO equipoDTO){
        Equipo equipo = new Equipo() {
            nombre = equipoDTO.nombre,
            url_imagen = equipoDTO.url_imagen,
            modelo = equipoDTO.modelo,
            marca = equipoDTO.marca,
            disponibilidadId = equipoDTO.disponibilidadId
        };

        _context.Equipos.Add(equipo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEquipo), new { id = equipo.equipoId }, equipo);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Recepcionista")]
    public async Task<IActionResult> PutEquipo(int id, EquipoDTO equipoDTO){
        if(id != equipoDTO.equipoId){
            return BadRequest();
        }

        var equipo = await _context.Equipos.Include(i => i.disponibilidad).FirstOrDefaultAsync(s => s.equipoId == id);
        if(equipo == null){
            return NotFound();
        }
        
        equipo.nombre = equipoDTO.nombre;
        equipo.url_imagen = equipoDTO.url_imagen;
        equipo.modelo = equipoDTO.modelo;
        equipo.marca = equipoDTO.marca;
        equipo.disponibilidadId = equipoDTO.disponibilidadId;

        try{
            await _context.SaveChangesAsync();
        }catch(DbException ex){
            Console.WriteLine(ex.Message);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> DeleteEquipo(int id){
        var equipo = await _context.Equipos.FindAsync(id);
        
        if(equipo == null){
            return NotFound();
        }

        _context.Equipos.Remove(equipo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}



