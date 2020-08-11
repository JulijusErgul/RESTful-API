using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RESTful_API.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserImage { get; set; }
        public List<Task> Tasks { get; set; }
        public List<TaskList> TaskLists { get; set; }


        public static USER_ACCOUNT Read(int UserId)
        {
            using(var db = new RESTfulDBEntities())
            {
                return db.USER_ACCOUNT.FirstOrDefault(x => x.USERACCOUNTID == UserId);
            }
        }

        public List<USER_ACCOUNT> List()
        {
            using (var db = new RESTfulDBEntities())
            {
                db.USER_ACCOUNT.Load();
                var query = db.USER_ACCOUNT.OrderBy(x => x.USERACCOUNTID);
                return query.ToList();
            }
        }
    }
}