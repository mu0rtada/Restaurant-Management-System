using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Restaurant.DAL
{
    public class StrConnection
    {
        //Connection DataBase 
        public static string ConnectionString =
        ConfigurationManager.ConnectionStrings["ConnectionSTR"].ConnectionString;
    }
}
