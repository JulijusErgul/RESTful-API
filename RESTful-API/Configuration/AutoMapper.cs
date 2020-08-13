using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTful_API.Model;

namespace RESTful_API.Configuration
{
    public class AutoMapper
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ToUserAccountProfile());
                cfg.AddProfile(new FromUserAccountProfile());
                cfg.AddProfile(new ToTaskListProfile());
                cfg.AddProfile(new FromTaskListProfile());
                cfg.AddProfile(new ToTaskProfile());
                cfg.AddProfile(new FromTaskProfile());
                cfg.ValidateInlineMaps = false;

            });
        }
        public class ToUserAccountProfile : Profile
        {
            public ToUserAccountProfile()
            {
                CreateMap<User, USER_ACCOUNT>();
            }
        }
        public class FromUserAccountProfile : Profile
        {
            public FromUserAccountProfile()
            {
                CreateMap<USER_ACCOUNT, User>();
            }
        }
        public class ToTaskListProfile:Profile
        {
            public ToTaskListProfile()
            {
                CreateMap<TaskList, TASKLIST>();
            }
        }
        public class FromTaskListProfile : Profile
        {
            public FromTaskListProfile()
            {
                CreateMap<TASKLIST, TaskList>();
            }
        }
        public class ToTaskProfile : Profile
        {
            public ToTaskProfile()
            {
                CreateMap<Task, TASK>();
            }
        }
        public class FromTaskProfile : Profile
        {
            public FromTaskProfile()
            {
                CreateMap<TASK, Task>();
            }
        }
    }
}