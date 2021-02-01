using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BugSquash.Models;
using BugSquash.DTOs;
using AutoMapper;

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
        public IEnumerable<TicketDTO> GetTickets()
        {
            return _context.Tickets.ToList().Select(Mapper.Map<Ticket, TicketDTO>);
        }

        // GET /api/tickets/1

        public TicketDTO GetTicket(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(t => t.Id == id);

            if (ticket == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Ticket, TicketDTO>(ticket);

        }

        // POST /api/tickets
        [HttpPost]
        public TicketDTO CreateTicket (TicketDTO ticketDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var ticket = Mapper.Map<TicketDTO, Ticket>(ticketDTO);
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            ticketDTO.Id = ticket.Id;

            return ticketDTO;

        }

        // PUT /api/tickets/1
        [HttpPut]
        public void UpdateTicket(int id, TicketDTO ticketDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var ticketInDb = _context.Tickets.SingleOrDefault(t => t.Id == id);

            if (ticketInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(ticketDTO, ticketInDb);

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
