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
            bool created = _eTask.Add(Mapper.Map<TASK>(task));
            if (created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTask(int id, Task newTaskObj)
        {
            Task tempTask = new Task().GetTask(id);
            tempTask = newTaskObj;

            bool updated = _eTask.Update(Mapper.Map<TASK>(tempTask));
            if (updated)
                return true;
            else
                return false;
        }

        public bool DeleteTask(Task taskObj)
        {
            bool deleted = _eTask.Delete(Mapper.Map<TASK>(taskObj));
            if (deleted)
                return true;
            else
                return false;
        }
    }
}