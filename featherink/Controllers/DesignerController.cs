using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using featherink.Database.Entities;
using featherink.Database;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace featherink.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DesignerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Designer> _modelRepository;

        public DesignerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _modelRepository = _unitOfWork.GetRepository<Designer>();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Designer>> Get()
        {
            var models = await _modelRepository.Get(null, new[] { nameof(Designer.User) });

            return Ok(models);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Designer>> Get(int id)
        {
            var row = await _modelRepository.GetById(id, new[] { nameof(Designer.User) });

            return row == null ? (ActionResult<Designer>)NotFound() : Ok(row);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Designer>> Post([FromBody] Designer entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _modelRepository.Create(entity);
            await _unitOfWork.Save();

            return Ok(entity);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Designer>> Put(int id, [FromBody] Designer entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _modelRepository.UpdateById(id, entity);

            if (result == null)
            {
                return NotFound();
            }

            await _unitOfWork.Save();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Designer>> Delete(int id)
        {

            //check if the user has claims
            var userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            var temp = userId.Value;

            var row = await _modelRepository.GetById(id, new[] { nameof(Designer.User) });

            if (row.UserId.ToString() != temp)
            {
                return Unauthorized();
            }
            //

            var result = await _modelRepository.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            await _unitOfWork.Save();

            return Ok(result);
        }

        /*
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
        */
    }
}
