using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugSquash.Models;
using BugSquash.ViewModels;

namespace BugSquash.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
        public ActionResult Random()
        {
            var ticket = new Ticket();

            var ticketTypes = new List<TicketType>
            {
                new TicketType { Name = "Defect" },
                new TicketType { Name = "New Feature"},
                new TicketType { Name = "Training"}
            };

            var viewModel = new RandomTicketViewModel
            {
                Ticket = ticket,
                TicketTypes = ticketTypes
            };
            return View(viewModel);
        }

        [Route("tickets/type/{year}/{month:regex(\\d{2}):range(1, 12)}")]

        public ActionResult ByTicketType(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}