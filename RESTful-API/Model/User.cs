using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RESTful_API.Support;
using RESTful_API.Configuration;
using AutoMapper;

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

        static private EUserAccount _eUserAccount = new EUserAccount();

        public User GetUser(int UserId)
        {
            USER_ACCOUNT user_account = _eUserAccount.Read(UserId);
            User userObj = Mapper.Map<User>(user_account);
            return userObj;
        }

        public List<User> GetUserList()
        {
            return Mapper.Map<List<USER_ACCOUNT>, List<User>>(_eUserAccount.List());
        }

        public bool AddUser(User userObj)
        {
            bool created = _eUserAccount.Add(Mapper.Map<USER_ACCOUNT>(userObj));

            if(created == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}