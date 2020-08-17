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
    public class AuditLogsController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

       /* public AuditLogsController(Ctx context)
        {
            _context = context;
        }*/

        // GET: api/AuditLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditLog>>> GetAuditLogs()
        {
            return (await unitOfWork.AuditLogManager.GetAsync()).ToList();
        }

        // GET: api/AuditLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuditLog>> GetAuditLog(Guid id)
        {
            var auditLog = await unitOfWork.AuditLogManager.GetByIdAsync(id);

            if (auditLog == null)
            {
                return NotFound();
            }

            return auditLog;
        }

        // PUT: api/AuditLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditLog(Guid id, AuditLog auditLog)
        {
            if (id != auditLog.Id)
            {
                return BadRequest();
            }

           await unitOfWork.AuditLogManager.UpdateAsync(auditLog);

            try
            {
                await unitOfWork.AuditLogManager.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditLogExists(id))
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

        // POST: api/AuditLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AuditLog>> PostAuditLog(AuditLog auditLog)
        {
          await  unitOfWork.AuditLogManager.CreateOnDbAsync(auditLog);
            await unitOfWork.AuditLogManager.SaveChangesAsync();

            return CreatedAtAction("GetAuditLog", new { id = auditLog.Id }, auditLog);
        }

        // DELETE: api/AuditLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuditLog>> DeleteAuditLog(Guid id)
        {
            var auditLog = await unitOfWork.AuditLogManager.GetByIdAsync(id);
            if (auditLog == null)
            {
                return NotFound();
            }

           await unitOfWork.AuditLogManager.DeleteAsync(auditLog);
            await unitOfWork.AuditLogManager.SaveChangesAsync();

            return auditLog;
        }

        private bool AuditLogExists(Guid id)
        {
            return (unitOfWork.AuditLogManager.GetByIdAsync(id) != null);
        }
    }
}
