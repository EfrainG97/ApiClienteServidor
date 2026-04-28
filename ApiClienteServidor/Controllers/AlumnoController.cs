using ApiClienteServidor.Data;
using ApiClienteServidor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiClienteServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlumnoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consulta = await _context.Alumno.ToListAsync();
            return Ok(new { exito = true, consulta });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var consulta = await _context.Alumno.Where(p => p.Id == id).ToListAsync();
            if (consulta == null || consulta.Count == 0)
            {
                return NotFound();
            }
            return Ok(new { exito = true, consulta });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Alumno alumno)
        {
            _context.Alumno.Add(alumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = alumno.Id }, new
            {
                Ok = true,
                mensaje = "Alumno agregado correctamente",
                data = alumno
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Alumno alumno)
        {
            var consulta = await _context.Alumno.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            consulta.Id = alumno.Id;
            consulta.Nombre = alumno.Nombre;
            consulta.Matricula = alumno.Matricula;
            consulta.Edad = alumno.Edad;

            _context.Entry(consulta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Ok = true,
                mensaje = "Alumno actualizado correctamente",
                data = consulta
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _context.Alumno.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            _context.Alumno.Remove(consulta);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Ok = true,
                mensaje = "Alumno eliminado correctamente",
                data = consulta
            });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAlumno(int id, [FromBody] Dictionary<string, object> actualizacion)
        {
            var consulta = await _context.Alumno.FindAsync(id);
            
            if (consulta == null)
            {
                return NotFound();
            }

            foreach (var campo in actualizacion)
            {
                switch (campo.Key.ToLower())
                {
                    case "nombre":
                        consulta.Nombre = campo.Value.ToString();
                        break;
                    case "matricula":
                        consulta.Matricula = ConvierteEntero(campo.Value);
                        break;
                    case "edad":
                        consulta.Edad = ConvierteEntero(campo.Value);
                        break;
                    default:
                        break;
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Ok = true,
                mensaje = "Alumno actualizado correctamente",
                data = consulta
            });
        }

        private int ConvierteEntero(object Valor)
        {
            if (Valor == null)
                return 0;

            if (Valor is JsonElement elementoJson)
            {
                return elementoJson.GetInt32();
            }

            if (Valor is string cadenaValor)
            {
                return int.Parse(cadenaValor);
            }

            return Convert.ToInt32(Valor);
        }
    }
}
