using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTful_API.Model;

namespace RESTful_API.Controller
{
    public class ListsController : ApiController
    {
        // GET: api/list/1
        [HttpGet]
        public TaskList GetTaskList(int id)
        {
            return new TaskList { };
        }

        //GET: api/list
        [HttpGet]
        public IEnumerable<TaskList> GetTaskLists()
        {
            return new List<TaskList> { };
        }

        // POST: api/list
        [HttpPost]
        public IHttpActionResult AddNewTaskList([FromBody] TaskList task)
        {
           
            return Ok();
        }

        // PUT: api/list/3
        [HttpPut]
        public IHttpActionResult UpdateTaskList(int Id, string name)
        {
            return Ok();
        }

        // DELETE: api/list/2
        [HttpDelete]
        public IHttpActionResult DeleteTaskList(int id)
        {
            return Ok();
        }
    }
}
