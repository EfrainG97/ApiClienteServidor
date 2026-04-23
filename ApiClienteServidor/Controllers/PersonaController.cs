using ApiClienteServidor.Data;
using ApiClienteServidor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ApiClienteServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consulta = await _context.Persona.ToListAsync();
            return Ok(new { exito = true, consulta });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var consulta = await _context.Persona.Where(p => p.Id == id).ToListAsync();
            if (consulta == null || consulta.Count == 0)
            {
                return NotFound();
            }
            return Ok(new { exito = true, consulta });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Persona persona)
        {
            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = persona.Id }, new
            {
                Ok = true,
                mensaje = "Persona agregada correctamente",
                data = persona
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Persona persona)
        {
            var consulta = await _context.Persona.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            consulta.Id = persona.Id;
            consulta.Nombre = persona.Nombre;
            consulta.Edad = persona.Edad;

            _context.Entry(consulta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Ok = true,
                mensaje = "Persona actualizada correctamente",
                data = consulta
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _context.Persona.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            _context.Persona.Remove(consulta);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Ok = true,
                mensaje = "Persona eliminada correctamente",
                data = consulta
            });
        }
    }
}
