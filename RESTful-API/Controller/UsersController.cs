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
        public IEnumerable<User> GetUsers()
        {
            User user = new User();
            List<User> users = user.GetUserList();
            return users;
        }

        // POST: api/user
        [HttpPost]
        public IHttpActionResult Register([FromBody] User user)
        {
            User userObj = new User();

            string hashedPassword = SecurePasswordHasher.Hash(user.UserPassword);
            user.UserPassword = hashedPassword;

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
        public IHttpActionResult UpdateUser(int Id, [FromBody]User newUserObj)
        {
            User user = new User();
            if(Id < 0)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            else if(user.UpdateUser(Id, newUserObj))
            {
                return StatusCode(HttpStatusCode.OK);
            }
            else
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            
        }

        // DELETE: api/user/2
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = new User();
            if (user.DeleteUser(user.GetUser(id)))
            {
                return Ok();
            }
            else
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

        }
    }
}
