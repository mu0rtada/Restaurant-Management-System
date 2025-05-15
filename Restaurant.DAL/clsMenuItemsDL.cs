using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class clsMenuItemsDL
    {

        public static async Task<DataTable> GetAllMenuItems()
        {
            DataTable Table = new DataTable();
            string Query = "View_GetAllMenuItems";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    SqlDataReader Reader =await Command.ExecuteReaderAsync();
                    
                    Table.Load(Reader);
                }
            }

            return Table;

        }
        public static async Task<int> AddNewMenuItem(string MenuItemName, string Description,
            decimal Price, int CategoryID,string ImagePath)
        {
            int MenuItemID = 0;
            string Query = "InsertMenuItem";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
              await Connection.OpenAsync();
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@MenuItemName", MenuItemName);
                    Command.Parameters.AddWithValue("@Description", Description);
                    Command.Parameters.AddWithValue("@Price", Price);
                    Command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    if (string.IsNullOrEmpty(ImagePath))
                    {
                        Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    }
                    else
                    {
                        Command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    }
                    MenuItemID =await Command.ExecuteNonQueryAsync();
                }

            }
           
                return MenuItemID;
        }

        public static async Task<Boolean>UpdateMenuItem(int MenuItemID, string MenuItemName, string Description,
            decimal Price, int CategoryID, string ImagePath)
        {
            int RowsAffected = 0;
            string Query = "SP_UpdateMenuItem";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@MenuItemID", MenuItemID);
                    Command.Parameters.AddWithValue("@MenuItemName", MenuItemName);
                    Command.Parameters.AddWithValue("@Description", Description);
                    Command.Parameters.AddWithValue("@Price", Price);
                    Command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    if (string.IsNullOrEmpty(ImagePath))
                    {
                        Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    }
                    else
                    {
                        Command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    }
                    RowsAffected = await Command.ExecuteNonQueryAsync();
                }
            }
            return RowsAffected > 0;
        }
    }
}
