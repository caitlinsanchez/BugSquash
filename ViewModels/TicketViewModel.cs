using BugSquash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugSquash.ViewModels
{
    public class TicketViewModel
    {
        public List<Ticket> Ticket { get; set; }
        public List<TicketType> TicketTypes { get; set; }
    }
}