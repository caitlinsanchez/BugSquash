using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugSquash.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public TicketType TicketType { get; set; }
        public byte TicketTypeId { get; set; }
    }
}