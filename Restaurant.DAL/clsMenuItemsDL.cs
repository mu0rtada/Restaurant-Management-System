using System;
using System.Data;
using System.Data.SqlClient;
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

        public static async Task<DataTable> GetAllMenuItemsByCategoryID(int? CategoryID)
        {
            DataTable Table = new DataTable();
            string Query = "View_GetAllMenuItems where CategoryID=@CategoryID";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    SqlDataReader Reader = await Command.ExecuteReaderAsync();

                    Table.Load(Reader);
                }
            }

            return Table;

        }

        public static async Task<int?> AddNewMenuItem(string MenuItemName, string Description,
            decimal ?Price, int? CategoryID,string ImagePath)
        {
            int? MenuItemID = null;
            string Query = "InsertMenuItem";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
              await Connection.OpenAsync();
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@MenuItemName", MenuItemName);
                    Command.Parameters.AddWithValue("@Description", Description??null);
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
                    object Result=await Command.ExecuteScalarAsync();
                    if(Result!=null&&int.TryParse(Result.ToString(),out int ID))
                        MenuItemID = ID;

                    MenuItemID = null;

                }

            }
           
                return MenuItemID;
        }

        public static async Task<Boolean>UpdateMenuItem(int? MenuItemID, string MenuItemName, string Description,
            decimal? Price, int? CategoryID, string ImagePath)
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

        public static bool GetMenuItemInfoByID
          (int? MenuItemID, ref string MenuItemName, ref string Description, ref decimal? Price,
           ref int? CategoryID,ref string ImagePath)
        {
            bool IsFound = false;

            string Query = "SP_GetMenuItemByID";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@MenuItem", MenuItemID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;
                            MenuItemName = (string)Reader["MenuItemName"];
                            Description = (string)Reader["Description"];
                            CategoryID = (int)Reader["CategoryID"];
                            Price = (decimal)Reader["Price"];
                            if (Reader["ImagePath"] != null)
                                ImagePath = (string)Reader["ImagePath"];
                            else
                                ImagePath = null;



                        }
                        else
                            IsFound = false;
                    }
                }
            }
            return IsFound;


        }

       

        public static bool GetMenuItemInfoByCategoryID
         (int? CategoryID,ref int? MenuItemID, ref string MenuItemName, ref string Description, ref decimal? Price,
           ref string ImagePath)
        {
            bool IsFound = false;

            string Query = "SP_GetMenuItemByID";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@MenuItem", MenuItemID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;
                            MenuItemID = (int)Reader["MenuItemID"];
                            MenuItemName = (string)Reader["MenuItemName"];
                            Description = (string)Reader["Description"];
                            Price = (decimal)Reader["Price"];
                            if (Reader["ImagePath"] != null||DBNull.Value!=null)
                                ImagePath = (string)Reader["ImagePath"];
                            else
                                ImagePath = null;



                        }
                        else
                            IsFound = false;
                    }
                }
            }
            return IsFound;


        }
    }
}
