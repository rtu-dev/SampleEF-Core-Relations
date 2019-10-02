using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleEF_Core_Relations.Data;
using SampleEF_Core_Relations.Entity;

namespace SampleEF_Core_Relations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubGroupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubGroup>>> GetSubGroup()
        {
            return await _context.SubGroup.ToListAsync();
        }

        // GET: api/SubGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubGroup>> GetSubGroup(int id)
        {
            var subGroup = await _context.SubGroup.FindAsync(id);

            if (subGroup == null)
            {
                return NotFound();
            }

            return subGroup;
        }

        // PUT: api/SubGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubGroup(int id, SubGroup subGroup)
        {
            if (id != subGroup.SubGroupId)
            {
                return BadRequest();
            }

            _context.Entry(subGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubGroupExists(id))
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

        // POST: api/SubGroups
        [HttpPost]
        public async Task<ActionResult<SubGroup>> PostSubGroup(SubGroup subGroup)
        {
            _context.SubGroup.Add(subGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubGroup", new { id = subGroup.SubGroupId }, subGroup);
        }

        // DELETE: api/SubGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubGroup>> DeleteSubGroup(int id)
        {
            var subGroup = await _context.SubGroup.FindAsync(id);
            if (subGroup == null)
            {
                return NotFound();
            }

            _context.SubGroup.Remove(subGroup);
            await _context.SaveChangesAsync();

            return subGroup;
        }

        private bool SubGroupExists(int id)
        {
            return _context.SubGroup.Any(e => e.SubGroupId == id);
        }
    }
}
