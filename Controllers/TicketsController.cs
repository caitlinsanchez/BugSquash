using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using BugSquash.Models;
using BugSquash.ViewModels;
using System.Configuration;

namespace BugSquash.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
       
            private ApplicationDbContext _context;
            public TicketsController()
            {
            _context = new ApplicationDbContext();
            }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult List()
        {
            if (User.IsInRole(RoleName.CanManageTickets))
                return View("List");
                return View("ReadOnlyList");
        }

        
        public ActionResult Details(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(c => c.Id == id);

            if (ticket == null)
                return HttpNotFound();

            return View(ticket);
        }

        // GET: Tickets/Create
        [Authorize(Roles = RoleName.CanManageTickets)]
        public ActionResult Create()
        {
            var ticketTypes = _context.TicketTypes.ToList();
            var ticketStatus = _context.TicketStatus.ToList();
            var ticketPriorities = _context.TicketPriorities.ToList();
            var viewModel = new TicketFormViewModel
            {
                Ticket = new Ticket(),
                TicketTypes = ticketTypes,
                TicketStatus = ticketStatus,
                TicketPriorities = ticketPriorities

            };
            return View("Create", viewModel);
        }
        // POST: Tickets/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TicketFormViewModel
                {
                    Ticket = ticket,
                    TicketTypes = _context.TicketTypes.ToList(),
                    TicketStatus = _context.TicketStatus.ToList(),
                    TicketPriorities = _context.TicketPriorities.ToList()
                };

                return View("Create", viewModel);
            }

            if (ticket.Id == 0)
            {
                _context.Tickets.Add(ticket);
            }

            else
            {
                var ticketInDb = _context.Tickets.Single(t => ticket.Id == ticket.Id);

                ticketInDb.Name = ticket.Name;
                ticketInDb.TicketTypeId = ticket.TicketTypeId;
                ticketInDb.TicketStatusId = ticket.TicketStatusId;
                ticketInDb.TicketPriorityId = ticket.TicketPriorityId;
            }

            _context.SaveChanges();

            return RedirectToAction("List", "Tickets");
        }

        public ActionResult Edit(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(t => t.Id == id);

            if (ticket == null)
                return HttpNotFound();

            var viewModel = new TicketFormViewModel
            {
                Ticket = ticket,
                TicketTypes = _context.TicketTypes.ToList(),
                TicketStatus = _context.TicketStatus.ToList(),
                TicketPriorities = _context.TicketPriorities.ToList()
            };
            return View("Create", viewModel);
        }
    }
}