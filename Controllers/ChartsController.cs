using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugSquash.Models;
using BugSquash.ViewModels;
using static BugSquash.ViewModels.ChartViewModels.ChartOptions;

namespace BugSquash.Controllers
{
    public class ChartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: Ticket Priority Data
        public JsonResult TicketPriorityChartData()
        {
            var data = new ChartData();
            data.KeyLabel = "# of Tickets";
            foreach (var priority in db.TicketPriorities.ToList())
            {
                var dataCount = db.Tickets.Where(t => t.TicketPriorityId == priority.Id).Count();
                data.Labels.Add(priority.Name);
                data.Data.Add(dataCount);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}