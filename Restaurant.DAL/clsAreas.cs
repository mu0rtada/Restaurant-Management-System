using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Areas", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            
            return dt;
        }
      
    }
}
