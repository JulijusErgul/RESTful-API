using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful_API
{
    public class DataSource
    {
        static public string getConnectionString(string name)
        {
            return System.Web.Configuration
                .WebConfigurationManager
                .ConnectionStrings["RESTfulDBEntities"]
                .ConnectionString;
        }
    }
}