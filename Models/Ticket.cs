using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugSquash.Models
{
    public class Ticket
    {
        #region IDs
        public int Id { get; set; }
        [Display(Name = "Ticket Type")]
        public int TicketTypeId { get; set; }
        [Display(Name = "Ticket Status")]
        public int TicketStatusId { get; set; }
        [Display(Name = "Ticket Priority")]
        public int TicketPriorityId { get; set; }

        #endregion
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }




        public virtual TicketType TicketType { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
        public virtual TicketPriority TicketPriority { get; set; }

        
    }
}