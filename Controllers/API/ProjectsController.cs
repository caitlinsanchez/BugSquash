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
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _context;
        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/projects
        public IHttpActionResult GetProjects()
        {
            var projectDTOs = _context.Projects
                .ToList()
                .Select(Mapper.Map<Project, ProjectDTO>);

            return Ok(projectDTOs);
        }

        // GET /api/projects/1

        public IHttpActionResult GetProject(int id)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == id);


            if (project == null)
                return NotFound();

            return Ok(Mapper.Map<Project, ProjectDTO>(project));

        }

        // POST /api/projects
        [HttpPost]
        public IHttpActionResult CreateProject(ProjectDTO projectDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var project = Mapper.Map<ProjectDTO, Project>(projectDTO);
            _context.Projects.Add(project);
            _context.SaveChanges();

            projectDTO.Id = project.Id;

            return Created(new Uri(Request.RequestUri + "/" + project.Id), projectDTO);

        }

        // PUT /api/projects/1
        [HttpPut]
        public void UpdateProject(int id, ProjectDTO projectDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var projectInDb = _context.Projects.SingleOrDefault(t => t.Id == id);

            if (projectInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(projectDTO, projectInDb);

            _context.SaveChanges();
        }

        // DELETE /api/projects/1
        [HttpDelete]
        public void DeleteProject(int id)
        {
            var projectInDb = _context.Projects.SingleOrDefault(t => t.Id == id);

            if (projectInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Projects.Remove(projectInDb);
            _context.SaveChanges();
        }

    }
}
