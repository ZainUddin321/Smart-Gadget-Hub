using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Mobile_Web.DB
{
    public class Connection
    {
        public static string ConnectionString= ConfigurationManager.ConnectionStrings["Mobile_WebEntities"].ConnectionString;
        //public static string ConnectionString = @"Data Source=ZAINUDDIN\SQLEXPRESS;Initial Catalog='Mobile Web';Integrated Security=True;";
    }
}
