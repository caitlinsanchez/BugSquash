using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BugSquash.Models;

namespace BugSquash.Controllers.API
{
    public class TicketsController : ApiController
    {
        private ApplicationDbContext _context;
        public TicketsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/tickets
        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Tickets.ToList();
        }

        // GET /api/tickets/1

        public Ticket GetTicket(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(t => t.Id == id);

            if (ticket == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return ticket;

        }

        // POST /api/tickets
        [HttpPost]
        public Ticket CreateTicket (Ticket ticket)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return ticket;

        }

        // PUT /api/tickets/1
        [HttpPut]
        public void UpdateTicket(int id, Ticket ticket)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var ticketInDb = _context.Tickets.SingleOrDefault(t => t.Id == id);

            if (ticketInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            ticketInDb.Name = ticket.Name;
            ticketInDb.TicketType = ticket.TicketType;
            ticketInDb.TicketStatus = ticket.TicketStatus;
            ticketInDb.TicketPriority = ticket.TicketPriority;

            _context.SaveChanges();
        }

        // DELETE /api/tickets/1
        [HttpDelete]
        public void DeleteTicket(int id)
        {
            var ticketInDb = _context.Tickets.SingleOrDefault(t => t.Id == id);

            if (ticketInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Tickets.Remove(ticketInDb);
            _context.SaveChanges();
        }

    }
}
