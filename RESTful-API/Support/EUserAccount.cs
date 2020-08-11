using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RESTful_API.Model;

namespace RESTful_API.Support
{
    public class EUserAccount
    {
        public EUserAccount()
        {

        }

        public EUserAccount(int userAccountId)
        {
            _userAccountObj = this.Read(userAccountId);
        }
        private USER_ACCOUNT _userAccountObj = null;

        public USER_ACCOUNT UserAccountObj { get { return _userAccountObj; } }
        public USER_ACCOUNT Read(int userAccountId)
        {
            using (var db = new RESTfulDBEntities())
            {
                return db.USER_ACCOUNT
                    .Include(a => a.TASKLIST)
                    .Include(a => a.TASK)
                    .FirstOrDefault(x => x.USERACCOUNTID == userAccountId);
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

        public bool Add(USER_ACCOUNT user_accountObj)
        {
            using(var db = new RESTfulDBEntities())
            {
                using(DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.USER_ACCOUNT.Load();
                        user_accountObj.USERACCOUNTID = (db.USER_ACCOUNT
                            .ToList().Max(x => x.USERACCOUNTID) + 1);
                        db.USER_ACCOUNT.Add(user_accountObj);
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