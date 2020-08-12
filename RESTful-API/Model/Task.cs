using AutoMapper;
using RESTful_API.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful_API.Model
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
        public int ListId { get; set; }
        public int UserId { get; set; }

        static private ETask _eTask = new ETask();

        public Task GetTask(int id)
        {
            TASK task = _eTask.Read(id);
            Task taskObj = Mapper.Map<Task>(task);
            return taskObj;
        }

        public List<Task> GetTasksList()
        {
            return Mapper.Map<List<TASK>, List<Task>>(_eTask.List());
        }

        public bool AddTask(Task task)
        {
            
        }

        internal bool UpdateTask(int id, Task newTaskObj)
        {
            throw new NotImplementedException();
        }

        internal bool DeleteTask(Task.GetTask getTask)
        {
            throw new NotImplementedException();
        }
    }
}