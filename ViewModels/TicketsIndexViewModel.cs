using BugSquash.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugSquash.ViewModels
{
    public class TicketsIndexViewModel
    {
        public Ticket Ticket { get; set; }
        public IEnumerable<TicketType> TicketTypes { get; set; }
    }

    public class EditTicketViewModel
    {

    }
}