using DilenyTeck.Ticket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DilenyTeck.Ticket.Context
{
   public class Ctx:DbContext
    {
        public Ctx(DbContextOptions<Ctx> options):base(options)
        {

        }
        public Ctx()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Ticket;Integrated Security=True", opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
        }
        public virtual DbSet<Entities.Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }
    }
}
