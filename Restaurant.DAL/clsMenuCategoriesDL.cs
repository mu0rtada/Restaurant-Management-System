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
        public static async Task<int>AddNewCategory(string CategoryName)
        {
            int CategoryID = 0;
            string Query = "SP_InsertCategoryItem";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                SqlTransaction Transaction = Connection.BeginTransaction();
                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection, Transaction))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                      Command.Parameters.AddWithValue("@CategoryName", CategoryName);
                        

                        CategoryID=await Command.ExecuteNonQueryAsync();


                        Transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Transaction.Rollback();
                    throw ;
                }
            }
            return CategoryID;
        }
        public static async Task<Boolean>UpdateCategoryStatus(int CategoryID,bool IsAvailable)
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
                catch (Exception ex)
                {
                   
                    throw ;
                }
            }
            return RowsAffected > 0;

        }

        public static async Task<Boolean>DeleteCategory(int CategoryID)
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
                catch (Exception ex)
                {
                    throw ;
                }
            }
            return RowsAffected > 0;
        }
    }
}
