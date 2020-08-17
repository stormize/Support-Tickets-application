using DilenyTeck.Ticket.Context;
using DilenyTeck.Ticket.Entities;
using DilenyTeck.Ticket.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilenyTeck.Ticket.BusinessLogic.Managers
{
   public  class AuditLogManager : Repository<AuditLog, Ctx>
    {
        public AuditLogManager(Ctx context) : base(context)
        {

        }
        public async override Task<AuditLog> GetByIdAsync(object id, string includeProperties = null)
        {
            return (await GetAsync(a => a.Id == (Guid)id)).ToList() .FirstOrDefault();
        }
    }
}
