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
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        //private readonly FeatherInkContext _context;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Comment> _modelRepository;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _modelRepository = _unitOfWork.GetRepository<Comment>();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Comment>> Get()
        {
            var comments = await _modelRepository.Get(null, new[] { nameof(Comment.Art) });

            return Ok(comments);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Comment>> Get(int id)
        {
            var row = await _modelRepository.GetById(id, new[] { nameof(Comment.Art) });

            return row == null ? (ActionResult<Comment>)NotFound() : Ok(row);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Comment>> Post([FromBody] Comment entity)
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
        public async Task<ActionResult<Comment>> Put(int id, [FromBody] Comment entity)
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
        public async Task<ActionResult<Comment>> Delete(int id)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest();
            }

            var result = await _modelRepository.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            await _unitOfWork.Save();

            return Ok(result);
        }

        /*
        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComment()
        {
            var item = new Comment();
            return Ok(item);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var item = new Comment();
            return item;
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id)
        {
            var item = new Comment();
            return Ok("Put item");
        }

        // POST: api/Comments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment()
        {
            var item = new Comment();
            return CreatedAtAction("GetComment", new { id = item.Id }, item);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound("comment with ID not found");
            }

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }
        */
    }
}
