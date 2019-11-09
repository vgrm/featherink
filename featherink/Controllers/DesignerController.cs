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
            var item = new Designer();
            return Ok(item);
        }

        // GET: api/Designer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Designer>> GetDesigner(int id)
        {
            var item = new Designer();
            return Ok(item);
        }

        // PUT: api/Designer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesigner(int id)
        {
            var item = new Designer();
            return Ok("Put item");
        }

        // POST: api/Designer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Designer>> PostDesigner()
        {
            var item = new Designer();
            return CreatedAtAction("GetDesigner", new { id = item.Id }, item);
        }

        // DELETE: api/Designer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Designer>> DeleteDesigner(int id)
        {
            var designer = await _context.Designer.FindAsync(id);
            if (designer == null)
            {
                return NotFound("designer page with ID not found");
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
