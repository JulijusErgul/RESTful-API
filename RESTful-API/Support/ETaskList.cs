using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RESTful_API.Model;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace RESTful_API.Support
{
    public class ETaskList
    {
        private TASKLIST _taskListObj = null;
        public ETaskList()
        {
            
        }
        public ETaskList(int taskListId)
        {
            _taskListObj = this.Read(taskListId);
        }

        public TASKLIST TaskListObj { get { return _taskListObj; } }

        public TASKLIST Read(int taskListId)
        {
            using(var db = new RESTfulDBEntities())
            {
                return db.TASKLIST
                    .Include(tl => tl.TASK)
                    .FirstOrDefault(tl => tl.TASKLISTID == taskListId);
            }
        }

        public List<TASKLIST> List(int userAccountID)
        {
            using(var db = new RESTfulDBEntities())
            {
                db.TASK.Load();
                var query = db.TASKLIST
                            .OrderBy(x => x.TASKLISTID)
                            .Where(x => x.USER_ACCOUNT.USERACCOUNTID == userAccountID);
                return query.ToList();
            }
        }
        public bool Add(TASKLIST taskListObj)
        {
            using(var db = new RESTfulDBEntities())
            {
                using(DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.TASKLIST.Load();
                        taskListObj.TASKLISTID = (db.TASKLIST.ToList().Max(x => x.TASKLISTID) + 1);
                        db.TASKLIST.Add(taskListObj);
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

        public bool Update(TASKLIST newTaskListObj)
        {
            using(var db = new RESTfulDBEntities())
            {
                try
                {
                    db.TASKLIST.Attach(newTaskListObj);
                    db.Entry(newTaskListObj).State = EntityState.Modified;
                    Shared.save(db);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Delete(TASKLIST taskListObj)
        {
            using(var db = new RESTfulDBEntities())
            {
                using(DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        _taskListObj = db.TASKLIST.Find(taskListObj.TASKLISTID);
                        db.TASKLIST.Remove(_taskListObj);
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