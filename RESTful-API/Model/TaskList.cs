using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful_API.Model
{
    public class TaskList
    {
        public int TaskListId { get; set; }
        public string TaskListName { get; set; }
        public string TaskListDescription { get; set; }
        public int UserID { get; set; }
        public List<Task> Tasks { get; set; }

    }
}