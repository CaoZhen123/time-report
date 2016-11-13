using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeRecordSystem1.Dtos;
using TimeRecordSystem1.Models;
using AutoMapper;

namespace TimeRecordSystem1.Controllers.Api
{

    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();

        }
        
        //GET /api/users
            public IEnumerable<UserDto> GetUsers()
            {
                return _context.Users.ToList().Select(Mapper.Map<User, UserDto>);
            }

        //GET /api/users/1
        public IHttpActionResult GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);
            if (user == null)
            {
               return NotFound();
            }
            return Ok(Mapper.Map<User, UserDto>(user));
        }

        //POST /api/users
        [HttpPost]
        public IHttpActionResult CreateUser(UserDto userDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var user = Mapper.Map<UserDto, User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();

            userDto.Id = user.Id;
            return Created(new Uri(Request.RequestUri + "/" + user.Id), userDto);
        }

        //PUT /api/users/1
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userInDb = _context.Users.SingleOrDefault(c => c.Id == id);
            if(userInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(userDto, userInDb);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/users/1
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var userInDb = _context.Users.SingleOrDefault(c => c.Id == id);
            if (userInDb == null)
                return NotFound();

            _context.Users.Remove(userInDb);
            _context.SaveChanges();

            return Ok();
        }


    }
}
