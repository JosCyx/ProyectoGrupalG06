using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGrupalG06.Models;

namespace ProyectoGrupalG06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugerenciasController : ControllerBase
    {
        private readonly PROYECTOG06Context _context;

        public SugerenciasController(PROYECTOG06Context context)
        {
            _context = context;
        }

        // GET: api/Sugerencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sugerencia>>> GetSugerencias()
        {
          if (_context.Sugerencias == null)
          {
              return NotFound();
          }
            return await _context.Sugerencias.ToListAsync();
        }

        // GET: api/Sugerencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sugerencia>> GetSugerencia(int id)
        {
          if (_context.Sugerencias == null)
          {
              return NotFound();
          }
            var sugerencia = await _context.Sugerencias.FindAsync(id);

            if (sugerencia == null)
            {
                return NotFound();
            }

            return sugerencia;
        }

        // PUT: api/Sugerencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSugerencia(int id, Sugerencia sugerencia)
        {
            if (id != sugerencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(sugerencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SugerenciaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sugerencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sugerencia>> PostSugerencia(Sugerencia sugerencia)
        {
          if (_context.Sugerencias == null)
          {
              return Problem("Entity set 'PROYECTOG06Context.Sugerencias'  is null.");
          }
            _context.Sugerencias.Add(sugerencia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SugerenciaExists(sugerencia.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSugerencia", new { id = sugerencia.Id }, sugerencia);
        }

        // DELETE: api/Sugerencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSugerencia(int id)
        {
            if (_context.Sugerencias == null)
            {
                return NotFound();
            }
            var sugerencia = await _context.Sugerencias.FindAsync(id);
            if (sugerencia == null)
            {
                return NotFound();
            }

            _context.Sugerencias.Remove(sugerencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SugerenciaExists(int id)
        {
            return (_context.Sugerencias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
