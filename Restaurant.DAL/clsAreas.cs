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
        // Gets Areas (BAGHDAD)
        public static DataTable GetAllAreas()
        {
            DataTable Table = new DataTable();

            string Query = "SP_GetAllAreas";
            using (SqlConnection Connection = new SqlConnection(StrConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                Connection.Open();
                    Command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.HasRows)
                        {
                            Table.Load(Reader);

                        }
                    }

                }

            }
            //Return Result
            return Table;
        }
      
    }
}
