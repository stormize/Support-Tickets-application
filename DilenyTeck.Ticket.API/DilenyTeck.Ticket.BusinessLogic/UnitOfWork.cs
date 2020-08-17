using DilenyTeck.Ticket.BusinessLogic.Managers;
using DilenyTeck.Ticket.Context;
using System;

namespace DilenyTeck.Ticket.BusinessLogic
{
    public class UnitOfWork
    {
        readonly Ctx _context = new Ctx();

        public AuditLogManager AuditLogManager
        {
            get
            {
                return new AuditLogManager(_context);
            }
        }
        public TicketManager TicketManager
        {
            get
            {
                return new TicketManager(_context);
            }
        }

        public UserManager UserManager
        {
            get
            {
                return new UserManager(_context);
            }
        }
    }
}
