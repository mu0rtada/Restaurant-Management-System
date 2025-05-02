using System;
using System.Data;
using System.Data.SqlClient;


namespace Restaurant.DAL
{
    public class clsPeopleDAL
    {
        // Get all people from a view
        public static DataTable GetPeopleActive()
        {
            string Query = "select * from View_People order by PersonID";
            DataTable Table = new DataTable();
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();
                    SqlDataReader Reade = Command.ExecuteReader();
                    Table.Load(Reade); // Load results into DataTable
                }
            }
            return Table;
        }
  

       
    }
}
