using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackActividades.Models;

namespace BackActividades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        readonly DbAngularContext _baseDatos;

        public ActividadesController(DbAngularContext baseDatos)
        {
            _baseDatos = baseDatos;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var listaActividades = await _baseDatos.Actividades.ToListAsync();
            return Ok(listaActividades);
        }
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody]Actividade request)
        {
            await _baseDatos.Actividades.AddAsync(request);
            await _baseDatos.SaveChangesAsync();
            return Ok(request);
        }
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminarActividad = await _baseDatos.Actividades.FindAsync(id);
            if (eliminarActividad == null)
                return BadRequest("No hay ninguna actividad registrada con ese id");
            _baseDatos.Actividades.Remove(eliminarActividad);
            await _baseDatos.SaveChangesAsync();
            return Ok();
        }

    }
}
