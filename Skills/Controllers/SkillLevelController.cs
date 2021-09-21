using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skills.Models;

namespace Skills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillLevelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SkillLevelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SkillLevel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillLevel>>> GetSkillLevel()
        {
            return await _context.SkillLevel.ToListAsync();
        }

        // GET: api/SkillLevel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillLevel>> GetSkillLevel(int id)
        {
            var skillLevel = await _context.SkillLevel.FindAsync(id);

            if (skillLevel == null)
            {
                return NotFound();
            }

            return skillLevel;
        }

        // PUT: api/SkillLevel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillLevel(int id, SkillLevel skillLevel)
        {
            if (id != skillLevel.SkillLevelId)
            {
                return BadRequest();
            }

            _context.Entry(skillLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillLevelExists(id))
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

        // POST: api/SkillLevel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SkillLevel>> PostSkillLevel(SkillLevel skillLevel)
        {
            _context.SkillLevel.Add(skillLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkillLevel", new { id = skillLevel.SkillLevelId }, skillLevel);
        }

        // DELETE: api/SkillLevel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillLevel(int id)
        {
            var skillLevel = await _context.SkillLevel.FindAsync(id);
            if (skillLevel == null)
            {
                return NotFound();
            }

            _context.SkillLevel.Remove(skillLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillLevelExists(int id)
        {
            return _context.SkillLevel.Any(e => e.SkillLevelId == id);
        }
    }
}
