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
            return new Task().GetTask(id);
        }

        //GET: api/task
        [HttpGet]
        public IEnumerable<Task> GetTasks()
        {
            return new Task().GetTasksList();
        }

        // POST: api/task
        [HttpPost]
        public IHttpActionResult AddNewTask([FromBody] Task task)
        {
            bool created = new Task().AddTask(task);
            if (created)
                return StatusCode(HttpStatusCode.Created);
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }

        // PUT: api/task/3
        [HttpPut]
        public IHttpActionResult UpdateTask(int Id, [FromBody] Task newTaskObj)
        {
            if (Id < 0)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            else if (new Task().UpdateTask(Id, newTaskObj))
            {
                return Ok();
            }
            else
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/task/2
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            if(new Task().DeleteTask(new Task().GetTask(id)))
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
