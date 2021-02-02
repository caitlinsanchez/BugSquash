using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugSquash.Models;
using System.ComponentModel.DataAnnotations;

namespace BugSquash.DTOs
{
    public class TicketDTO
    {
        #region IDs
        public int Id { get; set; }
        
        public int TicketTypeId { get; set; }
        
        public int TicketStatusId { get; set; }
        
        public int TicketPriorityId { get; set; }

        #endregion
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public TicketTypeDTO TicketType { get; set; }

        public TicketStatusDTO TicketStatus { get; set; }

        public TicketPriorityDTO TicketPriority { get; set; }


    }
}