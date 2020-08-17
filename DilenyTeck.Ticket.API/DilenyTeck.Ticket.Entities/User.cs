using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DilenyTeck.Ticket.Entities
{
    [Table("user")]
    public class User
    {
        #region Member Variables
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        #endregion
        #region Foreign Key

        #endregion
    }
}
