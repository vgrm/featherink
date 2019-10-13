using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using featherink.Database;

namespace featherink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignerController : ControllerBase
    {
        private readonly FeatherInkContext _context;

        public DesignerController(FeatherInkContext context)
        {
            _context = context;
        }

        // GET: api/Designer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Designer>>> GetDesigner()
        {
            return await _context.Designer.ToListAsync();
        }

        // GET: api/Designer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Designer>> GetDesigner(int id)
        {
            var designer = await _context.Designer.FindAsync(id);

            if (designer == null)
            {
                return NotFound();
            }

            return designer;
        }

        // PUT: api/Designer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesigner(int id, Designer designer)
        {
            if (id != designer.Id)
            {
                return BadRequest();
            }

            _context.Entry(designer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignerExists(id))
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

        // POST: api/Designer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Designer>> PostDesigner(Designer designer)
        {
            _context.Designer.Add(designer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesigner", new { id = designer.Id }, designer);
        }

        // DELETE: api/Designer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Designer>> DeleteDesigner(int id)
        {
            var designer = await _context.Designer.FindAsync(id);
            if (designer == null)
            {
                return NotFound();
            }

            _context.Designer.Remove(designer);
            await _context.SaveChangesAsync();

            return designer;
        }

        private bool DesignerExists(int id)
        {
            return _context.Designer.Any(e => e.Id == id);
        }
    }
}
