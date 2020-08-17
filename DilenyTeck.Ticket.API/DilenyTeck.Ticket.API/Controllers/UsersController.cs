using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DilenyTeck.Ticket.Context;
using DilenyTeck.Ticket.Entities;
using DilenyTeck.Ticket.BusinessLogic;

namespace DilenyTeck.Ticket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UnitOfWork unitofWork = new UnitOfWork();

      /*  public UsersController(Ctx context)
        {
            _context = context;
        }*/

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return  unitofWork.UserManager.GetAsync().Result.ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await unitofWork.UserManager.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

          await  unitofWork.UserManager.UpdateAsync(user);

            try
            {
                await unitofWork.UserManager.SaveChangesAsync();
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
           await unitofWork.UserManager.CreateAsync(user);
            await unitofWork.UserManager.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            var user = await unitofWork.UserManager.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

           await unitofWork.UserManager.DeleteAsync(user);
            await unitofWork.UserManager.SaveChangesAsync();

            return user;
        }

        private bool UserExists(Guid id)
        {
            return unitofWork.UserManager.GetByIdAsync(id)!=null;
        }
    }
}
