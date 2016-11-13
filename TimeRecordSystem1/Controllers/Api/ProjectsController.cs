using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using TimeRecordSystem1.Dtos;
using TimeRecordSystem1.Models;

namespace TimeRecordSystem1.Controllers.Api
{
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
                _context = new ApplicationDbContext();
        }

        //GET /api/projects
        public IHttpActionResult GetProjects()
        {
            return Ok(_context.Projects.ToList().Select(Mapper.Map<Project, ProjectDto>));
        }

        //GET /api/projects/1
        public IHttpActionResult GetProject(int id)
        {
            var project = _context.Projects.SingleOrDefault(c => c.Id == id);

            if(project == null)
                return NotFound();
            return Ok(Mapper.Map<Project,ProjectDto>(project));
        }

        //POST /api/projects
        [HttpPost]
        public IHttpActionResult CreateProject(ProjectDto projectDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var project = Mapper.Map<ProjectDto, Project>(projectDto);
            _context.Projects.Add(project);
            _context.SaveChanges();
            projectDto.Id = project.Id;
            return Created(new Uri(Request.RequestUri + "/" + project.Id), projectDto);
        }

        //PUT /api/projects/1
        [HttpPut]
        public IHttpActionResult UpdateProject(int id, ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var projectInDb = _context.Projects.SingleOrDefault(c => c.Id == id);
            if (projectInDb == null)
                return NotFound();
            Mapper.Map(projectDto, projectInDb);
            return Ok();
        }

        //DELETE /api/projects/1
        [HttpDelete]
        public IHttpActionResult DeleteProject(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var projectInDb = _context.Projects.SingleOrDefault(c => c.Id == id);
            if (projectInDb == null)
                return NotFound();

            _context.Projects.Remove(projectInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
