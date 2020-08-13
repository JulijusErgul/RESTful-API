using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using RESTful_API.Model;

namespace RESTful_API.Controller
{
    public class TaskListsController : ApiController
    {
        // GET: api/list/1
        [HttpGet]
        public TaskList GetTaskList(int id)
        {
            return new TaskList().GetTaskList(id);
        }

        //GET: api/list
        [HttpGet]
        public IEnumerable<TaskList> GetTaskLists(int userId)
        {
            
            return new TaskList().GetTaskLists(userId);
        }

        // POST: api/list
        [HttpPost]
        public IHttpActionResult AddNewTaskList([FromBody] TaskList taskList)
        {
            bool created = new TaskList().AddTaskList(taskList);
            if (created)
                return StatusCode(HttpStatusCode.Created);
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }

        // PUT: api/list/3
        [HttpPut]
        public IHttpActionResult UpdateTaskList(int Id, [FromBody] TaskList taskList)
        {
            if (Id < 0)
                return StatusCode(HttpStatusCode.NotFound);
            else if (new TaskList().UpdateTaskList(Id, taskList))
                return StatusCode(HttpStatusCode.OK);
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }

        // DELETE: api/list/2
        [HttpDelete]
        public IHttpActionResult DeleteTaskList(int id)
        {
            if (new TaskList().DeleteTaskList(new TaskList().GetTaskList(id)))
                return StatusCode(HttpStatusCode.OK);
            else
                return StatusCode(HttpStatusCode.NotFound);
        }
    }
}
