using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BugSquash.Models
{
    public class Project
    {
        public int Id { get; set; }
        [DisplayName("Project Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}