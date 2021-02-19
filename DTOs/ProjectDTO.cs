using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugSquash.Models;
using System.ComponentModel.DataAnnotations;

namespace BugSquash.DTOs
{
    public class ProjectDTO
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



    }
}