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
    public class ProjectsController : Controller
    {
        // GET: Projects
       
            private ApplicationDbContext _context;
            public ProjectsController()
            {
            _context = new ApplicationDbContext();
            }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult List()
        {
            if (User.IsInRole(RoleName.CanManageProjects))
                return View("List");
                return View("ReadOnlyList");
        }

        
        public ActionResult Details(int id)
        {
            var project = _context.Projects.SingleOrDefault(c => c.Id == id);

            if (project == null)
                return HttpNotFound();

            return View(project);
        }

         // GET: Projects/Create
       
        public ActionResult Create()
        {
            
            var viewModel = new ProjectFormViewModel
            {
                Project = new Project(),
               
            };
            return View("Create", viewModel);
        }
        // POST: Projects/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProjectFormViewModel
                {
                    Project = project,
                    
                };

                return View("Create", viewModel);
            }

            if (project.Id == 0)
            {
                _context.Projects.Add(project);
            }

            else
            {
                var projectInDb = _context.Projects.Single(t => project.Id == project.Id);

                projectInDb.Name = project.Name;
                projectInDb.Description = project.Description;
            }

            _context.SaveChanges();

            return RedirectToAction("List", "Projects");
        }

        public ActionResult Edit(int id)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == id);
             
            if (project == null)
                return HttpNotFound();

            var viewModel = new ProjectFormViewModel
            {
                Project = project,
                
            };
            return View("Create", viewModel);
        }
    }
}