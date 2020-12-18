using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugSquash.Models
{
    public class Ticket
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual TicketType TicketType { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
        public virtual TicketPriority TicketPriority { get; set; }
       
    }
}