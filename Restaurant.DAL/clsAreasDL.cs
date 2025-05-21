using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.ComponentModel;

namespace Restaurant.DAL
{
    public class clsAreasDL
    {
        /// <summary>
        /// Gets Areas (BAGHDAD)
        /// </summary>
     
        public static async Task <DataTable> GetAllAreas()
        {
            DataTable Table = new DataTable();

            string Query = "SP_GetAllAreas";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
               await Connection.OpenAsync();
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
        /// <summary>
        /// GetArea Name 
        /// </summary>

        public static string GetAreaByID(int? AreaID)
        {
            string AreaName = string.Empty;
            //Get Function By ID
            string Query = "select dbo.GetAreaName(@AreaID)";
            using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    Command.Parameters.AddWithValue("@AreaID", AreaID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {

                            AreaName = Reader[0].ToString();
                        }
                    }



                }

            }
            return AreaName;

        }

    }
}
