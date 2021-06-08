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
    public class RouletteItemsController : ControllerBase
    {
        private readonly RouletteContext _context;

        public RouletteItemsController(RouletteContext context)
        {
            _context = context;
        }

        // GET: api/RouletteItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouletteItem>>> GetRouletteItems()
        {
            return await _context.RouletteItems.ToListAsync();
        }

        // GET: api/RouletteItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouletteItem>> GetRouletteItem(long id)
        {
            var rouletteItem = await _context.RouletteItems.FindAsync(id);

            if (rouletteItem == null)
            {
                return NotFound();
            }

            return rouletteItem;
        }

        // PUT: api/RouletteItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouletteItem(long id, RouletteItem rouletteItem)
        {
            if (id != rouletteItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(rouletteItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouletteItemExists(id))
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

        // POST: api/RouletteItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RouletteItem>> PostRouletteItem(RouletteItem rouletteItem)
        {
            _context.RouletteItems.Add(rouletteItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetRouletteItem", new { id = rouletteItem.Id }, rouletteItem);
            return CreatedAtAction(nameof(GetRouletteItem), new { id = rouletteItem.Id }, rouletteItem);
        }

        // DELETE: api/RouletteItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RouletteItem>> DeleteRouletteItem(long id)
        {
            var rouletteItem = await _context.RouletteItems.FindAsync(id);
            if (rouletteItem == null)
            {
                return NotFound();
            }

            _context.RouletteItems.Remove(rouletteItem);
            await _context.SaveChangesAsync();

            return rouletteItem;
        }

        private bool RouletteItemExists(long id)
        {
            return _context.RouletteItems.Any(e => e.Id == id);
        }
    }
}
