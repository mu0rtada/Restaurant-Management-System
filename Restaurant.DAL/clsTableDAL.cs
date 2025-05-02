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
    public class clsTableDAL
    {
        //Get All Tables By View 
        public static async Task<DataTable>GetTables()
        {
            DataTable Table = new DataTable();
            string Query = "select * from View_Tables";
            using(SqlConnection Connection=new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command=new SqlCommand(Query,Connection))
                {
                    await Connection.OpenAsync();
                    SqlDataReader Reader = await Command.ExecuteReaderAsync();
                    Table.Load(Reader);
                  
                }    
            }
            return Table;
        }
        //Add New Table
        public static async Task<int> AddNewTable(string TableName, int TableCapacity)
        {
            int RowsAffected = 0;
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
                        Command.Parameters.AddWithValue("@TableName", TableName);
                        Command.Parameters.AddWithValue("@TableCapacity", TableCapacity);
                        Command.Parameters.AddWithValue("@TableStatus", 1);
                        RowsAffected = await Command.ExecuteNonQueryAsync();
                        Transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Transaction.Rollback();
                    throw ex;
                }
            }
            return RowsAffected;
        }
    }
}
