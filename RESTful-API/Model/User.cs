using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RESTful_API.Support;
using RESTful_API.Configuration;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace RESTful_API.Model
{
    public class User
    {
        public int UserAccountId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
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

        public bool DeleteUser(User userObj)
        {
            bool deleted = _eUserAccount.Delete(Mapper.Map<USER_ACCOUNT>(userObj));
            if ( deleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateUser(int id, User newUserObj)
        {
            User temp = new User().GetUser(id);
            temp = newUserObj;
            
            bool updated = _eUserAccount.Update(Mapper.Map<USER_ACCOUNT>(temp));
            if (updated)
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