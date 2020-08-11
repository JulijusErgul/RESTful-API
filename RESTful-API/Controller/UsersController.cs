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
        // GET: api/user/1
        [HttpGet]
        public User GetUser(int id)
        {
            User user = new User();
            return user.GetUser(id);
        }

        //GET: api/user
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            User user = new User();
            List<User> users = user.GetUserList();
            return users;
        }

        // POST: api/user
        [HttpPost]
        public IHttpActionResult AddNewUser([FromBody] User user)
        {
            User userObj = new User();
            bool created = userObj.AddUser(user);
            if (created)
            {
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return InternalServerError();
            }
        }

        // PUT: api/user/3
        [HttpPut]
        public IHttpActionResult UpdateUser(int Id, string name)
        {         
            return Ok();  
        }

        // DELETE: api/user/2
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            return Ok();
        }
    }
}
