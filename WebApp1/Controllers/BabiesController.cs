using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabiesController : ControllerBase
    {
        private readonly BabyContext _context;

        public BabiesController(BabyContext context)
        {
            _context = context;
        }

        // GET: api/Babies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Baby>>> GetBabies()
        {
            return await _context.Babies.ToListAsync();
        }

        // GET: api/Babies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Baby>> GetBaby(long id)
        {
            var baby = await _context.Babies.FindAsync(id);

            if (baby == null)
            {
                return NotFound();
            }

            return baby;
        }

        // PUT: api/Babies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaby(long id, Baby baby)
        {
            if (id != baby.Id)
            {
                return BadRequest();
            }

            _context.Entry(baby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BabyExists(id))
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

        // POST: api/Babies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Baby>> PostBaby(Baby baby)
        {
            _context.Babies.Add(baby);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaby", new { id = baby.Id }, baby);
            //return CreatedAtAction(nameof(GetBaby)), new { id = baby.Id }, baby);
        }

        // DELETE: api/Babies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Baby>> DeleteBaby(long id)
        {
            var baby = await _context.Babies.FindAsync(id);
            if (baby == null)
            {
                return NotFound();
            }

            _context.Babies.Remove(baby);
            await _context.SaveChangesAsync();

            return baby;
        }

        private bool BabyExists(long id)
        {
            return _context.Babies.Any(e => e.Id == id);
        }
    }
}
