using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using featherink.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using featherink.Database;

namespace featherink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Database.Entities.Task> _modelRepository;

        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _modelRepository = _unitOfWork.GetRepository<Database.Entities.Task>();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Database.Entities.Task>> Get()
        {
            var models = await _modelRepository.Get(null, new[] { nameof(Database.Entities.Task.Designer) });

            return Ok(models);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Database.Entities.Task>> Get(int id)
        {
            var row = await _modelRepository.GetById(id, new[] { nameof(Database.Entities.Task.Designer) });

            return row == null ? (ActionResult<Database.Entities.Task>)NotFound() : Ok(row);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Database.Entities.Task>> Post([FromBody] Database.Entities.Task entity)
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
        public async Task<ActionResult<Database.Entities.Task>> Put(int id, [FromBody] Database.Entities.Task entity)
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
        public async Task<ActionResult<Database.Entities.Task>> Delete(int id)
        {
            var result = await _modelRepository.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            await _unitOfWork.Save();

            return Ok(result);
        }

        /*
        private readonly FeatherInkContext _context;

        public TaskController(FeatherInkContext context)
        {
            _context = context;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Database.Entities.Task>>> GetTask()
        {
            var item = new Database.Entities.Task();
            return Ok(item);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Database.Entities.Task>> GetTask(int id)
        {
            var item = new Database.Entities.Task();
            return Ok(item);
        }

        // PUT: api/Task/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id)
        {
            var item = new Database.Entities.Task();
            return Ok("Put item");
        }

        // POST: api/Task
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Database.Entities.Task>> PostTask()
        {
            var item = new Database.Entities.Task();
            return CreatedAtAction("GetTask", new { id = item.Id }, item);
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Database.Entities.Task>> DeleteTask(int id)
        {
            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound("Task with ID not found");
            }

            _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
        */
    }
}
