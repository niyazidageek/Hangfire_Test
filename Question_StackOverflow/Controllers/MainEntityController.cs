using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Question_StackOverflow.DAL;
using Question_StackOverflow.Models;

namespace Question_StackOverflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainEntityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MainEntityController(AppDbContext context)
        {
            _context = context;
        }

        [NonAction]
        public void sec10()
        {
            Thread.Sleep(10000);
            Console.WriteLine("I am thread 10");
        }

        [NonAction]
        public void sec5()
        {
            Thread.Sleep(5000);
            Console.WriteLine("I am thread 5");
        }


        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> TestHangfire(string message)
        {
            string jobId = BackgroundJob.Enqueue(() => sec10());

            string jobId2 = BackgroundJob.Enqueue(() => sec5());

            return Ok("saamemkmkme");
        }

        // GET: api/MainEntity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainEntity>>> GetMainEntities()
        {
            return await _context.MainEntities.Include(x=>x.Foos)
                .ThenInclude(x=>x.Bars).ToListAsync();
        }

        // GET: api/MainEntity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainEntity>> GetMainEntity(Guid id)
        {
            var mainEntity = await _context.MainEntities.FindAsync(id);

            if (mainEntity == null)
            {
                return NotFound();
            }

            return mainEntity;
        }

        // PUT: api/MainEntity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainEntity(Guid id, MainEntity mainEntity)
        {
            if (id != mainEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(mainEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainEntityExists(id))
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

        // POST: api/MainEntity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MainEntity>> PostMainEntity(MainEntity mainEntity)
        {
            _context.MainEntities.Add(mainEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMainEntity", new { id = mainEntity.Id }, mainEntity);
        }

        // DELETE: api/MainEntity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMainEntity(Guid id)
        {
            var mainEntity = await _context.MainEntities.FindAsync(id);
            if (mainEntity == null)
            {
                return NotFound();
            }

            _context.MainEntities.Remove(mainEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MainEntityExists(Guid id)
        {
            return _context.MainEntities.Any(e => e.Id == id);
        }
    }
}
