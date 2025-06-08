using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public  class clsMenuCategoriesDL
    {
        public static async Task<DataTable> GetAllMenuItems()
        {
            DataTable Table = new DataTable();
            string Query = "View_GetAllMenuCategory ";
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
        public static async Task<int?>AddNewCategory(string CategoryName)
        {
            int? CategoryID = null;
            string Query = "SP_InsertCategoryItem";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                SqlTransaction Transaction = Connection.BeginTransaction();
                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection, Transaction))
                    {
                        Command.Transaction = Transaction;
                        Command.CommandType = CommandType.StoredProcedure;
                      Command.Parameters.AddWithValue("@CategoryName", CategoryName);
                        



                        object Result=await Command.ExecuteScalarAsync();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            CategoryID = ID;
                        else
                        CategoryID = null;


                        Transaction.Commit();
                    }
                }
                catch (Exception )
                {
                    Transaction.Rollback();
                    throw ;
                }
            }
            return CategoryID;
        }
        public static async Task<Boolean>UpdateCategoryStatus(int? CategoryID,bool? IsAvailable)
        {
            int RowsAffected = 0;
            string Query = "SP_UpdateCategoryStatus";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        Command.Parameters.AddWithValue("@IsAvailable", IsAvailable);
                        RowsAffected = await Command.ExecuteNonQueryAsync();
                       
                    }
                }
                catch (Exception )
                {
                   
                    throw ;
                }
            }
            return RowsAffected > 0;

        }

        public static async Task<Boolean>DeleteCategory(int? CategoryID)
        {
            int RowsAffected = 0;
            string Query = "SP_DeleteCategory";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        RowsAffected = await Command.ExecuteNonQueryAsync();
                    }
                }
                catch (Exception )
                {
                    throw ;
                }
            }
            return RowsAffected > 0;
        }

        public static bool GetMenuCategoryByID(int? CategoryID,ref string CategoryName,ref Boolean IsAvailable)
        {
            Boolean IsFound = false;
            string Query = "SP_GetMenuCategoryInfoByID";

            using(SqlConnection Connection=new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using(SqlCommand Command=new SqlCommand(Query,Connection))
                {
                    Connection.Open();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    using(SqlDataReader Reader=Command.ExecuteReader())
                    {
                        if(Reader.Read())
                        {
                            IsFound = true;
                            CategoryName = (string)Reader["CategoryName"];
                            IsAvailable = (Boolean)Reader["IsAvaliable"];

                        }

                    }
                }
            }
            return IsFound;

            

        }

        public static async Task<Boolean>IsCategoryNameExists(string CategoryName)
        {
            Boolean IsFound = false;
            string Query = "Select * from IsCategoryExists(@CategoryName)";

            using(SqlConnection Connection=new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using(SqlCommand Command=new SqlCommand(Query,Connection))
                {
                   await Connection.OpenAsync();
                    Command.Parameters.AddWithValue("@CategoryName", CategoryName);

                    object Result = await Command.ExecuteScalarAsync();
                    if (Result != DBNull.Value&&Result!=null)
                        IsFound = Convert.ToBoolean(Result);


                }
            }
            return IsFound;
        }

    }
}
