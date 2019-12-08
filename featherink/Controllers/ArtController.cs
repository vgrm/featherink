using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using featherink.Database.Entities;
using Microsoft.EntityFrameworkCore;
using featherink.Database;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace featherink.Controllers
{
    
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Art> _modelRepository;

        public ArtController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _modelRepository = _unitOfWork.GetRepository<Art>();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Art>> Get()
        {
            var arts = await _modelRepository.Get(null, new[] { nameof(Art.Designer) });

            return Ok(arts);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Art>> Get(int id)
        {
            var row = await _modelRepository.GetById(id, new[] { nameof(Art.Designer) });

            return row == null ? (ActionResult<Art>)NotFound() : Ok(row);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Art>> Post([FromBody] Art entity)
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
        public async Task<ActionResult<Art>> Put(int id, [FromBody] Art entity)
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
        public async Task<ActionResult<Art>> Delete(int id)
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
        private readonly FeatherInkContext _context;

        public ArtController(FeatherInkContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Art art = new Art();
            return Ok(art);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetArt(int id)
        {
            Art art = new Art();
            return Ok(art);
        }

        [HttpPost]
        public IActionResult AddArt()
        {
            Art Item = new Art();
            Item.DesignerId = 1;
            Item.Name = "ART";
            Item.Description = " aa";
            Item.FilePath = "okok";
            _context.Art.Add(Item);
            _context.SaveChanges();
            return CreatedAtAction("GetArtist", new { id = Item.Id }, Item);
            //return Ok(Item);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutArt(int id)
        {
            //return Ok("put Art");
            var item = new Art();

            if (id != item.Id)
            {
                return BadRequest("ID not found");
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

            return Ok("Put item");
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Art>> DeleteArt(int id)
        {
            var art = await _context.Art.FindAsync(id);
            if (art == null)
            {
                return NotFound("Id not found delete art");
            }

            _context.Art.Remove(art);
            await _context.SaveChangesAsync();

            return art;
        }
        */
    }
}
