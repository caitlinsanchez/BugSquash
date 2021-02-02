using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public IHttpActionResult GetTickets()
        {
            var ticketDTOs = _context.Tickets
                .Include(c => c.TicketType)
                .ToList()
                .Select(Mapper.Map<Ticket, TicketDTO>);

            return Ok(ticketDTOs);
        }

        // GET /api/tickets/1

        public IHttpActionResult GetTicket(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(t => t.Id == id);
            var ticketTypes = _context.TicketTypes.ToList().Select(Mapper.Map<TicketType>);

            if (ticket == null)
                return NotFound();

            return Ok(Mapper.Map<Ticket, TicketDTO>(ticket));

        }

        // POST /api/tickets
        [HttpPost]
        public IHttpActionResult CreateTicket (TicketDTO ticketDTO, TicketTypeDTO ticketTypeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ticket = Mapper.Map<TicketDTO, Ticket>(ticketDTO);
            var ticketTypes = Mapper.Map<TicketTypeDTO, TicketType>(ticketTypeDTO);
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            ticketDTO.Id = ticket.Id;

            return Created(new Uri(Request.RequestUri + "/" + ticket.Id), ticketDTO);

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
