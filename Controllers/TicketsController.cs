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
        public ActionResult Index()
        {
            var ticket = new List<Ticket>
            {   new Ticket { Name = "Defect" },
                new Ticket { Name = "New Feature" },
                new Ticket { Name = "Training" },

            };

            var viewModel = new TicketViewModel
            {
                Ticket = ticket,
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