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
    public class FooController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FooController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Foo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Foo>>> GetFoos()
        {
            return await _context.Foos.ToListAsync();
        }

        // GET: api/Foo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Foo>> GetFoo(Guid id)
        {
            var foo = await _context.Foos.FindAsync(id);

            if (foo == null)
            {
                return NotFound();
            }

            return foo;
        }

        // PUT: api/Foo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoo(Guid id, Foo foo)
        {
            if (id != foo.Id)
            {
                return BadRequest();
            }

            _context.Entry(foo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FooExists(id))
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

        // POST: api/Foo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Foo>> PostFoo(Foo foo)
        {
            _context.Foos.Add(foo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoo", new { id = foo.Id }, foo);
        }

        // DELETE: api/Foo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoo(Guid id)
        {
            var foo = await _context.Foos.FindAsync(id);
            if (foo == null)
            {
                return NotFound();
            }

            _context.Foos.Remove(foo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FooExists(Guid id)
        {
            return _context.Foos.Any(e => e.Id == id);
        }
    }
}
