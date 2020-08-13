using AutoMapper;
using RESTful_API.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RESTful_API.Model
{
    public class TaskList
    {
        public int TaskListId { get; set; }
        [Required]
        public string TaskListName { get; set; }
        public string TaskListDescription { get; set; }
        public int UserID { get; set; }
        public List<Task> Tasks { get; set; }

        static private ETaskList _eTaskList = new ETaskList();

        public TaskList GetTaskList(int taskListId)
        {
            TASKLIST taskList = _eTaskList.Read(taskListId);
            TaskList taskListObj = Mapper.Map<TaskList>(taskList);
            return taskListObj;
        }

        public List<TaskList> GetTaskLists(int userAccountID)
        {
            return Mapper.Map<List<TASKLIST>, List<TaskList>>(_eTaskList.List(userAccountID));
        }

        public bool AddTaskList(TaskList taskListObj)
        {
            bool created = _eTaskList.Add(Mapper.Map<TASKLIST>(taskListObj));
            if (created)
                return true;
            else
                return false;
        }

        public bool DeleteTaskList(TaskList taskListObj)
        {
            bool deleted = _eTaskList.Delete(Mapper.Map<TASKLIST>(taskListObj));
            if (deleted)
                return true;
            else
                return false;
        }

        public bool UpdateTaskList(int id, TaskList newTaskListObj)
        {
            TaskList temp = new TaskList().GetTaskList(id);
            temp = newTaskListObj;

            bool updated = _eTaskList.Update(Mapper.Map<TASKLIST>(temp));
            if (updated)
                return true;
            else
                return false;
        }
    }
}