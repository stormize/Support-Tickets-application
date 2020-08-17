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
   public class UserManager : Repository<User, Ctx>
    {
        public UserManager(Ctx context) : base(context)
        {

        }
        public async override Task<User> GetByIdAsync(object id, string includeProperties = null)
        {
            return (await GetAsync(a => a.Id == (Guid)id)).ToList().FirstOrDefault();
        }
    }
}
