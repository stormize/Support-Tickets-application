using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DilenyTeck.Ticket.Entities
{
    [Table("audit log")]
    public class AuditLog
    {
        #region Member Variables
        public Guid Id { get; set; }
        public string Action { get; set; }

        public DateTime DateTime { get; set; }
        #endregion
        #region Foreign Keys
        [ForeignKey("User")]
        public Guid FK_UserId { get; set; }

        public User User { get; set; }
        [ForeignKey("Ticket")]
        public Guid FK_TicketId { get; set; }

        public Ticket Ticket { get; set; }


        #endregion
    }
}
