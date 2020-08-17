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
    public class TicketsController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

     /*   public TicketsController(Ctx context)
        {
            unitOfWork = context;
        }*/

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DilenyTeck.Ticket.Entities.Ticket>>> GetTickets()
        {
            return  unitOfWork.TicketManager.GetAsync().Result.ToList();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DilenyTeck.Ticket.Entities.Ticket>> GetTicket(Guid id)
        {
            var ticket = await unitOfWork.TicketManager.GetByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(Guid id, DilenyTeck.Ticket.Entities.Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }
           await unitOfWork.TicketManager.UpdateAsync(ticket);
            

            try
            {
                await unitOfWork.TicketManager.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DilenyTeck.Ticket.Entities.Ticket>> PostTicket(DilenyTeck.Ticket.Entities.Ticket ticket)
        {
           await unitOfWork.TicketManager.CreateAsync(ticket);
            await unitOfWork.TicketManager.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DilenyTeck.Ticket.Entities.Ticket>> DeleteTicket(Guid id)
        {
            var ticket = await unitOfWork.TicketManager.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

           await unitOfWork.TicketManager.DeleteAsync(ticket);
            await unitOfWork.TicketManager.SaveChangesAsync();

            return ticket;
        }

        private bool TicketExists(Guid id)
        {
            return unitOfWork.TicketManager.GetByIdAsync(id)!=null;
        }
    }
}
