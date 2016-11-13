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
    public class TimePeriodsController : ApiController
    {
        private ApplicationDbContext _context;

        public TimePeriodsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/timePeriods
        public IHttpActionResult GetTimePeriods()
        {

            return Ok(_context.TimePeriods.ToList().Select(Mapper.Map<TimePeriod, TimePeriodDto>));
        }

        //GET /api/timePeriods/1
        public IHttpActionResult GetTimePeriod(int id)
        {

            var timePeriod = _context.TimePeriods.SingleOrDefault(c => c.Id == id);
            if (timePeriod == null)
                return NotFound();
            return Ok(Mapper.Map<TimePeriod, TimePeriodDto>(timePeriod));
        }

        //POST /api/timePeriods
        [HttpPost]
        public IHttpActionResult CreateTimePeriod(TimePeriodDto timePeriodDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var timePeriod = Mapper.Map<TimePeriodDto, TimePeriod>(timePeriodDto);
            _context.TimePeriods.Add(timePeriod);
            _context.SaveChanges();
            timePeriodDto.Id = timePeriod.Id;
            return Created(new Uri(Request.RequestUri + "/" + timePeriod.Id), timePeriodDto);
        }

        //PUT /api/timePeriods/1
        [HttpPut]
        public IHttpActionResult UpdateTimePeriod(int id, TimePeriodDto timePeriodDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var timePeriodInDb = _context.TimePeriods.SingleOrDefault(c => c.Id == id);
            if (timePeriodInDb == null)
                return NotFound();
            Mapper.Map(timePeriodDto, timePeriodInDb);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/timePeriod/1
        [HttpDelete]
        public IHttpActionResult DeleteTimePeriod(int id)
        {
            var timePeriodInDb = _context.TimePeriods.SingleOrDefault(c => c.Id == id);
            if (timePeriodInDb == null)
                return NotFound();
            _context.TimePeriods.Remove(timePeriodInDb);
            return Ok();
        }
    }
}
