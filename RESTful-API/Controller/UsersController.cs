using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTful_API.Model;

namespace RESTful_API.Controller
{
    public class UsersController : ApiController
    {
        // GET: api/list/1
        [HttpGet]
        public User GetUser(int id)
        {
            //return userLists.FirstOrDefault(t => t.id == id);
            User userObj = new User();
            return new User { };
        }

        //GET: api/list
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            List<User> users = new List<User>();
            return users;
            //return userLists;
            
        }

        // POST: api/list
        [HttpPost]
        public IHttpActionResult AddNewUser([FromBody] User task)
        {
            return Ok();
        }

        // PUT: api/list/3
        [HttpPut]
        public IHttpActionResult UpdateUser(int Id, string name)
        {         
            return Ok();  
        }

        // DELETE: api/list/2
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            return Ok();
        }
    }
}
