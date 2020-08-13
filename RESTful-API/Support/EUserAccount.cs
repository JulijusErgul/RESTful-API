using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RESTful_API.Model;
using System.Security.Cryptography.X509Certificates;

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
                db.USER_ACCOUNT.Load();
                db.TASKLIST.Load();
                var query=db.USER_ACCOUNT.FirstOrDefault(x => x.USERACCOUNTID == userAccountId);
                return query;
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

        public bool Delete(USER_ACCOUNT user_accountObj)
        {
            using(var db = new RESTfulDBEntities())
            {
                using(DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        _userAccountObj = db.USER_ACCOUNT.Find(user_accountObj.USERACCOUNTID);
                        db.USER_ACCOUNT.Remove(_userAccountObj);
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
        public bool Update(USER_ACCOUNT newUser)
        {
            using(var db = new RESTfulDBEntities())
            {
                try
                {
                    db.USER_ACCOUNT.Attach(newUser);
                    db.Entry(newUser).State = EntityState.Modified;
                    Shared.save(db);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}