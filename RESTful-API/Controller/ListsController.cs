using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTful_API.Controller
{
    public class TaskList
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class ListsController : ApiController
    {
        List<TaskList> taskLists = new List<TaskList>
        {
            new TaskList{id = 1, name = "list 1" },
            new TaskList{id = 2, name = "list 2"},
            new TaskList{id = 3, name = "list 3"}
        };

        // GET: api/list/1
        [HttpGet]
        public TaskList GetTaskList(int id)
        {
            return taskLists.FirstOrDefault(t => t.id == id);
        }

        //GET: api/list
        [HttpGet]
        public IEnumerable<TaskList> GetTaskLists()
        {
            return taskLists;
        }

        // POST: api/list
        [HttpPost]
        public IHttpActionResult AddNewTaskList([FromBody] TaskList task)
        {
            taskLists.Add(task);
            return Ok(taskLists);
        }

        // PUT: api/list/3
        [HttpPut]
        public IHttpActionResult UpdateTaskList(int Id, string name)
        {
            TaskList newTask = taskLists.FirstOrDefault(test => test.id == Id);
            if (newTask == null)
            {
                return NotFound();
            }
            else
            {
                newTask.name = name;
                return Ok(taskLists);
            }
        }

        // DELETE: api/list/2
        [HttpDelete]
        public IHttpActionResult DeleteTaskList(int id)
        {
            TaskList taskDelete = taskLists.FirstOrDefault(t => t.id == id);
            if (taskDelete == null)
            {
                return NotFound();
            }
            else
            {
                taskLists.Remove(taskDelete);
                return Ok(taskLists);
            }
        }
    }
}
