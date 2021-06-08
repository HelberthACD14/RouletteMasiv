using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouletteMasiv.Models;

namespace RouletteMasiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteBetsController : ControllerBase
    {
        private readonly RouletteContext _context;

        public RouletteBetsController(RouletteContext context)
        {
            _context = context;
        }

        // GET: api/RouletteBets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouletteBet>>> GetRouletteBets()
        {
            return await _context.RouletteBets.ToListAsync();
        }

        // GET: api/RouletteBets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouletteBet>> GetRouletteBet(long id)
        {
            var rouletteBet = await _context.RouletteBets.FindAsync(id);

            if (rouletteBet == null)
            {
                return NotFound();
            }

            return rouletteBet;
        }

        // PUT: api/RouletteBets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouletteBet(long id, RouletteBet rouletteBet)
        {
            if (id != rouletteBet.Id)
            {
                return BadRequest();
            }

            _context.Entry(rouletteBet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouletteBetExists(id))
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

        // POST: api/RouletteBets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RouletteBet>> PostRouletteBet(RouletteBet rouletteBet)
        {
            _context.RouletteBets.Add(rouletteBet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRouletteBet", new { id = rouletteBet.Id }, rouletteBet);
        }

        // DELETE: api/RouletteBets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RouletteBet>> DeleteRouletteBet(long id)
        {
            var rouletteBet = await _context.RouletteBets.FindAsync(id);
            if (rouletteBet == null)
            {
                return NotFound();
            }

            _context.RouletteBets.Remove(rouletteBet);
            await _context.SaveChangesAsync();

            return rouletteBet;
        }

        private bool RouletteBetExists(long id)
        {
            return _context.RouletteBets.Any(e => e.Id == id);
        }
    }
}
