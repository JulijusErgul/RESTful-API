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
    }
}