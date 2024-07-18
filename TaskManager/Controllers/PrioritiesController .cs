using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Models;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PriorityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Priority
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriorityDto>>> GetPriorities()
        {
            return await _context.Priorities
                                 .Select(p => new PriorityDto { Level = p.Level })
                                 .ToListAsync();
        }

        // GET: api/Priority/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriorityDto>> GetPriority(int id)
        {
            var priority = await _context.Priorities.FindAsync(id);

            if (priority == null)
            {
                return NotFound();
            }

            return new PriorityDto { Level = priority.Level };
        }

        // POST: api/Priority
        [HttpPost]
        public async Task<ActionResult<PriorityDto>> PostPriority(PriorityDto priorityDto)
        {
            var priority = new Priority { Level = priorityDto.Level };
            _context.Priorities.Add(priority);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PriorityExists(priority.Level))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetPriority), new { id = priority.Level }, priorityDto);
        }

        // PUT: api/Priority/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriority(int id, PriorityDto priorityDto)
        {
            if (id != priorityDto.Level)
            {
                return BadRequest();
            }

            var priority = new Priority { Level = priorityDto.Level };
            _context.Entry(priority).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityExists(id))
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

        // DELETE: api/Priority/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriority(int id)
        {
            var priority = await _context.Priorities.FindAsync(id);
            if (priority == null)
            {
                return NotFound();
            }

            _context.Priorities.Remove(priority);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PriorityExists(int id)
        {
            return _context.Priorities.Any(e => e.Level == id);
        }
    }
}
