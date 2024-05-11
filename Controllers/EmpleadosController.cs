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
public class EmpleadosController : Controller
{

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
        fecha_baja = empleados.fecha_baja!,
        estatusId = empleados.estatusId,
        personaId = empleados.personaId,
        rolId = empleados.rolId
    };
}