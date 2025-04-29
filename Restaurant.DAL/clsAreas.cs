using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Restaurant.DAL
{
    public class clsAreas
    {
       public static DataTable GetAllAreas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
               
                conn.Open();
                StrongTypingException strongTypingException = new StrongTypingException();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Areas", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            
            return dt;
        }
      
    }
}
