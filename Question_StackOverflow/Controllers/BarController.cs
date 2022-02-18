using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Question_StackOverflow.DAL;
using Question_StackOverflow.Models;

namespace Question_StackOverflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BarController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Bar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bar>>> GetBars()
        {
            return await _context.Bars.ToListAsync();
        }

        // GET: api/Bar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bar>> GetBar(Guid id)
        {
            var bar = await _context.Bars.FindAsync(id);

            if (bar == null)
            {
                return NotFound();
            }

            return bar;
        }

        // PUT: api/Bar/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBar(Guid id, Bar bar)
        {
            if (id != bar.Id)
            {
                return BadRequest();
            }

            _context.Entry(bar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarExists(id))
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

        // POST: api/Bar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bar>> PostBar(Bar bar)
        {
            _context.Bars.Add(bar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBar", new { id = bar.Id }, bar);
        }

        // DELETE: api/Bar/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBar(Guid id)
        {
            var bar = await _context.Bars.FindAsync(id);
            if (bar == null)
            {
                return NotFound();
            }

            _context.Bars.Remove(bar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarExists(Guid id)
        {
            return _context.Bars.Any(e => e.Id == id);
        }
    }
}
