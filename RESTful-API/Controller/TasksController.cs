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
        List<Task> tasks = new List<Task>
        {
            new Task{id = 1, name = "string 1" },
            new Task{id = 2, name = "string 2"},
            new Task{id = 3, name = "string 3"}
        };

        // GET: api/task/1
        [HttpGet]
        public Task Get(int id)
        {
            return tasks.FirstOrDefault(t => t.id == id);
        }

        //GET: api/task
        [HttpGet]
        public IEnumerable<Task> GetTask()
        {
            return tasks;
        }

        // POST: api/task
        [HttpPost]
        public IHttpActionResult AddNewTask([FromBody] Task task)
        {
            tasks.Add(task);
            return Ok(tasks);
        }

        // PUT: api/task/3
        [HttpPut]
        public IHttpActionResult UpdateTask(int Id, string name)
        {
            Task newTask = tasks.FirstOrDefault(test => test.id == Id);
            if(newTask == null)
            {
                return NotFound();
            }
            else
            {
                newTask.name = name;
                return Ok(tasks);
            }
        }

        // DELETE: api/task/2
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            Task taskDelete = tasks.FirstOrDefault(t => t.id == id);
            if(taskDelete == null)
            {
                return NotFound();
            }
            else
            {
                tasks.Remove(taskDelete);
                return Ok(tasks);
            }
        }
    }
}
