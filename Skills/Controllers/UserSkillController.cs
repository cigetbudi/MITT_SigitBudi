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
    public class UserSkillController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserSkillController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserSkill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSkills>>> GetUserSkills()
        {
            return await _context.UserSkills.ToListAsync();
        }

        // GET: api/UserSkill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSkills>> GetUserSkills(string id)
        {
            var userSkills = await _context.UserSkills.FindAsync(id);

            if (userSkills == null)
            {
                return NotFound();
            }

            return userSkills;
        }

        // PUT: api/UserSkill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSkills(string id, UserSkills userSkills)
        {
            if (id != userSkills.UserSkillId)
            {
                return BadRequest();
            }

            _context.Entry(userSkills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSkillsExists(id))
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

        // POST: api/UserSkill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserSkills>> PostUserSkills(UserSkills userSkills)
        {
            _context.UserSkills.Add(userSkills);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserSkillsExists(userSkills.UserSkillId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserSkills", new { id = userSkills.UserSkillId }, userSkills);
        }

        // DELETE: api/UserSkill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSkills(string id)
        {
            var userSkills = await _context.UserSkills.FindAsync(id);
            if (userSkills == null)
            {
                return NotFound();
            }

            _context.UserSkills.Remove(userSkills);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSkillsExists(string id)
        {
            return _context.UserSkills.Any(e => e.UserSkillId == id);
        }
    }
}
