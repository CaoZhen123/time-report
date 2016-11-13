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
    public class TimeEntriesController : ApiController
    {
        private ApplicationDbContext _context;
        public TimeEntriesController() {

            _context = new ApplicationDbContext();
        }

        //GET /api/timeEntries
        public IHttpActionResult GetTimeEntries()
        {

            return Ok(_context.TimeEntries.ToList().Select(Mapper.Map<TimeEntry, TimeEntryDto>));
        }

       
        //GET /api/timeEntries/1
        public IHttpActionResult GetTimeEntry(int id)
        {
            var timeEntry = _context.TimeEntries.SingleOrDefault(c => c.Id == id);
            if (timeEntry == null)
                return NotFound();
            
            return Ok(Mapper.Map<TimeEntry, TimeEntryDto>(timeEntry));
        }

        //POST /api/timeEntries
        [HttpPost]
        public IHttpActionResult CreateTimeEntry(TimeEntryDto timeEntryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var timeEntry = Mapper.Map<TimeEntryDto, TimeEntry>(timeEntryDto);
            _context.TimeEntries.Add(timeEntry);
            _context.SaveChanges();
            timeEntryDto.Id = timeEntry.Id;
            return Created(new Uri(Request.RequestUri +"/"+ timeEntry.Id), timeEntryDto);
        }

        //PUT /api/timeEntries/1
        [HttpPut]
        public IHttpActionResult UpdateTimeEntry(int id, TimeEntryDto timeEntryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var timeEntryInDb = _context.TimeEntries.SingleOrDefault(c => c.Id == id);
            if (timeEntryInDb == null)
                return NotFound();
            Mapper.Map(timeEntryDto, timeEntryInDb);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/timeEntries/1
        [HttpDelete]
        public IHttpActionResult DeleteTimeEntry(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var timeEntryInDb = _context.TimeEntries.SingleOrDefault(c => c.Id == id);
            if (timeEntryInDb == null)
                return NotFound();

            _context.TimeEntries.Remove(timeEntryInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
