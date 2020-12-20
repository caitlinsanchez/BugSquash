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

        public ViewResult Index()
        {
            var tickets = _context.Tickets.Include(c => c.TicketStatus).ToList();

            return View(tickets);
        }

        public ActionResult Details(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(c => c.Id == id);

            if (ticket == null)
                return HttpNotFound();

            return View(ticket);
        }

        public ActionResult Create()
        {
            var ticketTypes = _context.TicketTypes.ToList();
            var ticketStatus = _context.TicketStatus.ToList();
            var ticketPriorities = _context.TicketPriorities.ToList();
            var viewModel = new TicketFormViewModel
            {
                TicketTypes = ticketTypes,
                TicketStatus = ticketStatus,
                TicketPriorities = ticketPriorities

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return RedirectToAction("Index", "Tickets");
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