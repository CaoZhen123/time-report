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
    public class UserTimeEntriesController : ApiController
    {
        ApplicationDbContext _context;
        public UserTimeEntriesController() {

            _context = new ApplicationDbContext();
        } 
          
        public IHttpActionResult GetTimeEntriesByUserId(int id) {

            var queryTimeEntriesByUserId = from timeEntry in _context.TimeEntries.ToList()
                                           where timeEntry.User.Id == id
                                           select timeEntry;

                                    
            return Ok(queryTimeEntriesByUserId.Select(Mapper.Map<TimeEntry, TimeEntryDto>));
        }
    }
}
