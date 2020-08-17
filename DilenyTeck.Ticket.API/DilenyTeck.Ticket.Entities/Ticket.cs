using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DilenyTeck.Ticket.Entities
{
    [Table("ticket")]
    public class Ticket
    {
        #region Memeber variables
        public Guid Id { get; set; }
        [MaxLength(150)]
        [MinLength(8)]
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        [MaxLength(300)]
        [MinLength(10)]
        public string Content { get; set; }
        public DateTime LastStatusChange { get; set; }
        #endregion
        #region Foreign Keys
        [ForeignKey("User")]
        public Guid FK_UserId { get; set; }

        public User User { get; set; }
        #endregion
    }
}
