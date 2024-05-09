using backendGameHub.Models;
using backendGameHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendGameHub.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EstatusController : ControllerBase
{
    private readonly DataContext _context;

    public EstatusController(DataContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Estatus>>> Get()
    {
        return await _context.Estatus.AsNoTracking().ToListAsync();
    }
}