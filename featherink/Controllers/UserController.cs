using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using featherink.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using featherink.Services;
using featherink.Database;
using featherink.Models;
using System.Security.Claims;

namespace featherink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly FeatherInkContext _context;

        private readonly IUserService _userService;
        private readonly IRepository<User> _userRepository;

        public UserController( IUserService userService, IUnitOfWork unitOfWork)
        {
            //_context = context;
            _userService = userService;
            _userRepository = unitOfWork.GetRepository<User>();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserInfoModel>> Get()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest();
            }

            var user = await _userRepository.GetById(userId.Value);

            if (user == null)
            {
                return NotFound();
            }

            var userInfoModel = new UserInfoModel
            {
                Role = user.Role,
                Username = user.Username,
                Email = user.Email,
                Picture = user.Picture
            };

            return Ok(userInfoModel);
        }

        [HttpPost("authentication")]
        public async Task<ActionResult<TokenModel>> Authenticate([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var token = await _userService.AuthenticateAsync(loginModel.Username, loginModel.Password);

                var tokenModel = new TokenModel(token);

                return Ok(tokenModel);
            }
            catch (UsernameOrPasswordInvalidException)
            {
                return BadRequest(new ErrorResponseModel("Username or password is invalid"));
            }
        }

        [HttpPost("registration")]
        public async Task<ActionResult<TokenModel>> Registrate([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var token = await _userService.RegistrateAsync(loginModel.Username, loginModel.Password);

                var tokenModel = new TokenModel(token);

                return Ok(tokenModel);
            }
            catch (UsernameTakenException)
            {
                return BadRequest(new ErrorResponseModel("Username is taken"));
            }
            catch (RegistrationException)
            {
                return StatusCode(500);
            }
        }

        /*
        // GET: api/User
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        */

        /*
        // PUT: api/User/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id)
        {
            
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

            var item = new User();
            return Ok("Put item");

        }
    */
        /*
            // POST: api/User
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            [HttpPost]
            public async Task<ActionResult<User>> PostUser(User user)
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }

            // DELETE: api/User/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<User>> DeleteUser(int id)
            {
                var user = await _context.User.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                _context.User.Remove(user);
                await _context.SaveChangesAsync();

                return user;
            }

            private bool UserExists(int id)
            {
                return _context.User.Any(e => e.Id == id);
            }
        */
    }
}
