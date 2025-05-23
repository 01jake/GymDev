using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymDev.Date;
using GymDev.Shared.Modelos;

namespace GymDev.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrenadorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntrenadorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Entrenadors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrenador>>> GetEntrenadores()
        {
            return await _context.Entrenadores.ToListAsync();
        }

        // GET: api/Entrenadors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entrenador>> GetEntrenador(int id)
        {
            var entrenador = await _context.Entrenadores.FindAsync(id);

            if (entrenador == null)
            {
                return NotFound();
            }

            return entrenador;
        }

        // PUT: api/Entrenadors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrenador(int id, Entrenador entrenador)
        {
            if (id != entrenador.Id)
            {
                return BadRequest();
            }

            _context.Entry(entrenador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrenadorExists(id))
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

        // POST: api/Entrenadors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entrenador>> PostEntrenador(Entrenador entrenador)
        {
            _context.Entrenadores.Add(entrenador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntrenador", new { id = entrenador.Id }, entrenador);
        }

        // DELETE: api/Entrenadors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntrenador(int id)
        {
            var entrenador = await _context.Entrenadores.FindAsync(id);
            if (entrenador == null)
            {
                return NotFound();
            }

            _context.Entrenadores.Remove(entrenador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntrenadorExists(int id)
        {
            return _context.Entrenadores.Any(e => e.Id == id);
        }
    }
}
