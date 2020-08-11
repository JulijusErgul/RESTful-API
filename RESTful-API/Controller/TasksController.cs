using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using RESTful_API.Model;

namespace RESTful_API.Controller
{
    public class TasksController : ApiController
    {
        // GET: api/task/1
        [HttpGet]
        public Task Get(int id)
        {
            return new Task { };
        }

        //GET: api/task
        [HttpGet]
        public IEnumerable<Task> GetTask()
        {
            return new List<Task> { };
        }

        // POST: api/task
        [HttpPost]
        public IHttpActionResult AddNewTask([FromBody] Task task)
        {
            return Ok();
        }

        // PUT: api/task/3
        [HttpPut]
        public IHttpActionResult UpdateTask(int Id, string name)
        {
            return Ok();
        }

        // DELETE: api/task/2
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            return Ok();
        }
    }
}
