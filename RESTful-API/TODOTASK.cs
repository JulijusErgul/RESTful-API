//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RESTful_API
{
    using System;
    using System.Collections.Generic;
    
    public partial class TODOTASK
    {
        public int TASKID { get; set; }
        public string TASKNAME { get; set; }
        public string TASKDESCRIPTION { get; set; }
        public bool TASKSTATUS { get; set; }
        public int FK_TASK_USER { get; set; }
        public int FK_TASK_LIST { get; set; }
    
        public virtual LIST LIST { get; set; }
        public virtual USER USER { get; set; }
    }
}
