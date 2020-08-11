using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTful_API.Controller
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class UsersController : ApiController
    {
        List<User> userLists = new List<User>
        {
            new User{id = 1, name = "list 1" },
            new User{id = 2, name = "list 2"},
            new User{id = 3, name = "list 3"}
        };

        // GET: api/list/1
        [HttpGet]
        public User GetUser(int id)
        {
            return userLists.FirstOrDefault(t => t.id == id);
        }

        //GET: api/list
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return userLists;
        }

        // POST: api/list
        [HttpPost]
        public IHttpActionResult AddNewUser([FromBody] User task)
        {
            userLists.Add(task);
            return Ok(userLists);
        }

        // PUT: api/list/3
        [HttpPut]
        public IHttpActionResult UpdateUser(int Id, string name)
        {
            User newUser = userLists.FirstOrDefault(u => u.id == Id);
            if (newUser == null)
            {
                return NotFound();
            }
            else
            {
                newUser.name = name;
                return Ok(userLists);
            }
        }

        // DELETE: api/list/2
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            User userDelete = userLists.FirstOrDefault(t => t.id == id);
            if (userDelete == null)
            {
                return NotFound();
            }
            else
            {
                userLists.Remove(userDelete);
                return Ok(userLists);
            }
        }
    }
}
