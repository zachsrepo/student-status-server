using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_status_server.Models;

namespace student_status_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly StudentStatusDbContext _context;

        public UsersController(StudentStatusDbContext context)
        {
            _context = context;
        }

        //Login for Users
        [HttpGet("{username}/{password}")]
        public async Task<ActionResult<User>> Login(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == username && x.Password == password);
            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //Setting the status of the user
        [HttpPut("green/{id}")]
        public async Task<IActionResult> Green(int id)
        {
            var request = await _context.Users.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            else
            {
                request.Status = "GREEN";
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
        //Setting the status of the user
        [HttpPut("red/{id}")]
        public async Task<IActionResult> Red(int id)
        {
            var request = await _context.Users.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            else
            {
                request.Status = "RED";
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Setting the status of the user
        [HttpPut("yellow/{id}")]
        public async Task<IActionResult> Yellow(int id)
        {
            var request = await _context.Users.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            else
            {
                request.Status = "YELLOW";
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Setting the status of the user
        [HttpPut("white/{id}")]
        public async Task<IActionResult> White(int id)
        {
            var request = await _context.Users.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            else
            {
                request.Status = "WHITE";
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
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
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'StudentStatusDbContext.Users'  is null.");
          }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
