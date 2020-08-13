using RESTful_API.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RESTful_API.Support
{
    public class ETask
    {
        private TASK _taskObj = null;
        public ETask()
        {
            
        }
        public ETask(int taskId)
        {
            _taskObj = this.Read(taskId);
        }

        public TASK TaskObj { get { return _taskObj; } }

        public TASK Read(int id)
        {
            using(var db = new RESTfulDBEntities())
            {
                return db.TASK.FirstOrDefault(t => t.TASKID == id);
            }            
        }

        public List<TASK> List(int userAccountID, int taskListID)
        {
            using(var db = new RESTfulDBEntities())
            {
                db.TASK.Load();
                var query = db.TASK.OrderBy(t => t.TASKID)
                    .Where(x=>x.USER_ACCOUNT.USERACCOUNTID == userAccountID)
                    .Where(x=>x.TASKLIST.TASKLISTID==taskListID);
                return query.ToList();
            }
        }

        public bool Add(TASK taskObj)
        {
            using(var db = new RESTfulDBEntities())
            {
                using(DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.TASK.Load();
                        taskObj.TASKID = (db.TASK.ToList().Max(x => x.TASKID) + 1);
                        db.TASK.Add(taskObj);
                        Shared.save(db);
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool Update(TASK newTaskObj)
        {
            using(var db = new RESTfulDBEntities())
            {
                try
                {
                    db.TASK.Attach(newTaskObj);
                    db.Entry(newTaskObj).State = EntityState.Modified;
                    Shared.save(db);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Delete(TASK taskObj)
        {
            using (var db = new RESTfulDBEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        _taskObj = db.TASK.Find(taskObj.TASKID);
                        db.TASK.Remove(taskObj);
                        Shared.save(db);
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}