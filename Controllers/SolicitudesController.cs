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
    public class SolicitudesController : ControllerBase
    {
        private readonly PROYECTOG06Context _context;

        public SolicitudesController(PROYECTOG06Context context)
        {
            _context = context;
        }

        // GET: api/Solicitudes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitude>>> GetSolicitudes()
        {
          if (_context.Solicitudes == null)
          {
              return NotFound();
          }
            return await _context.Solicitudes.ToListAsync();
        }

        // GET: api/Solicitudes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitude>> GetSolicitude(int id)
        {
          if (_context.Solicitudes == null)
          {
              return NotFound();
          }
            var solicitude = await _context.Solicitudes.FindAsync(id);

            if (solicitude == null)
            {
                return NotFound();
            }

            return solicitude;
        }

        // PUT: api/Solicitudes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitude(int id, Solicitude solicitude)
        {
            if (id != solicitude.Id)
            {
                return BadRequest();
            }

            _context.Entry(solicitude).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudeExists(id))
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

        // POST: api/Solicitudes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Solicitude>> PostSolicitude(Solicitude solicitude)
        {
          if (_context.Solicitudes == null)
          {
              return Problem("Entity set 'PROYECTOG06Context.Solicitudes'  is null.");
          }
            _context.Solicitudes.Add(solicitude);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SolicitudeExists(solicitude.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(PostSolicitude), new { id = solicitude.Id }, solicitude);
        }

        // DELETE: api/Solicitudes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitude(int id)
        {
            if (_context.Solicitudes == null)
            {
                return NotFound();
            }
            var solicitude = await _context.Solicitudes.FindAsync(id);
            if (solicitude == null)
            {
                return NotFound();
            }

            _context.Solicitudes.Remove(solicitude);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolicitudeExists(int id)
        {
            return (_context.Solicitudes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
