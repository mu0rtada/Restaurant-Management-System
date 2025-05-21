using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Restaurant.DAL
{
    public class clsTableDL
    {
        /// <summary>
        /// Get All Tables By View 
        /// </summary>
        /// <returns></returns>
        public static async Task<DataTable> GetTables()
        {
            DataTable Table = new DataTable();
            string Query = "select * from View_Tables";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    await Connection.OpenAsync();
                    SqlDataReader Reader = await Command.ExecuteReaderAsync();
                    Table.Load(Reader);

                }
            }
            return Table;
        }
        /// <summary>
        /// Get All Tables Available SQL Stored Procedure
        /// </summary>
        /// <returns></returns>
        public static async Task<DataTable> GetAvailableTables()
        {
            DataTable Table = new DataTable();
            string Query = "SP_GetAllAvailableTables";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    await Connection.OpenAsync();
                    SqlDataReader Reader = await Command.ExecuteReaderAsync();
                    Table.Load(Reader);
                }
            }
            return Table;
        }



        /// <summary>
        /// Add New Table
        /// </summary>

        public static async Task<int?> AddNewTable(string TableName, short? TableCapacity)
        {
            int? RowsAffected = null;
            string Query = "SP_InsertTable";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                SqlTransaction Transaction = Connection.BeginTransaction();
                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection, Transaction))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Transaction = Transaction;

                        Command.Parameters.AddWithValue("@TableName", TableName);
                        Command.Parameters.AddWithValue("@TableCapacity", TableCapacity);
                        Command.Parameters.AddWithValue("@TableStatus", 1);
object Result=await Command.ExecuteScalarAsync();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))

                            RowsAffected = ID;

                        else
                            RowsAffected = null;

                            Transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    Transaction.Rollback();
                    throw ;
                }
            }
            return RowsAffected;
        }
        /// <summary>
        /// Update Status Table 
        /// </summary>

        public static async Task<bool> UpdateTableStatus(int? TableID, bool? TableStatus)
        {
            int RowsAffected = 0;
            string Query = "SP_UpdateTableStatus";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                SqlTransaction Transaction = Connection.BeginTransaction();
                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection, Transaction))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@TableID", TableID);
                        Command.Parameters.AddWithValue("@Status", TableStatus);
                        RowsAffected = await Command.ExecuteNonQueryAsync();
                        Transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    Transaction.Rollback();
                    throw ;
                }
            }
            return RowsAffected>0;
        }

        /// <summary>
        /// Get Available Tables By TableID
        /// </summary>

        public static async Task<Boolean> IsTableAvailable(int? TableID)
        {
            bool IsFound = false;
            string Query = "select dbo.GetAvailableTables(@TableID)";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@TableID", TableID);
                    object result = await Command.ExecuteScalarAsync();
                    if (result != DBNull.Value)
                    {
                        IsFound = Convert.ToBoolean(result);
                    }
                }


            }
            return IsFound;
        }


        //Get Table By ID
        public static bool GetTableInfoByID
          (int? TableID,ref string TableName,
            ref short? CapCity,ref bool? Status)
        {
            bool IsFound = false;

            string Query = "SP_GetTableByID";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@TableID", TableID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;
                            TableID = (int)Reader["TableID"];
                            TableName = (string)Reader["TableName"];
                            CapCity = (short)Reader["CapCity"];
                            Status = (bool)Reader["Status"];


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

