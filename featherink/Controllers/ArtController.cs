using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using featherink.Database;
using Microsoft.EntityFrameworkCore;

namespace featherink.Controllers
{
    
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtController : ControllerBase
    {
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
        public async Task<IActionResult> PutArt(int id, Art art)
        {
            if (id != art.Id)
            {
                return BadRequest();
            }

            _context.Entry(art).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Art>> DeleteArt(int id)
        {
            var art = await _context.Art.FindAsync(id);
            if (art == null)
            {
                return NotFound();
            }

            _context.Art.Remove(art);
            await _context.SaveChangesAsync();

            return art;
        }

    }
}
