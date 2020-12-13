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
            var tickets = _context.Tickets.Include(c => c.TicketType).ToList();

            return View(tickets);
        }

        public ActionResult Details(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(c => c.Id == id);

            if (ticket == null)
                return HttpNotFound();

            return View(ticket);
        }




    }
}