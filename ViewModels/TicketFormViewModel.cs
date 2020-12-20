using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugSquash.Models;

namespace BugSquash.ViewModels
{
    public class TicketFormViewModel
    {
        public IEnumerable<TicketType> TicketTypes { get; set; }
        public IEnumerable<TicketStatus> TicketStatus { get; set; }
        public IEnumerable<TicketPriority> TicketPriorities { get; set; }
        public Ticket Ticket { get; set; }

    }
}