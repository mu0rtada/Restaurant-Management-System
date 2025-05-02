using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class clsUsersDL
    {
        public static async Task<DataTable> GetUsersActiveAsync()
        {
            string Query = "Select * from View_UsersActive";
            DataTable Table = new DataTable();
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

        public static async Task<DataTable> GetUsers_Not_activeAsync()
        {
            string Query = "Select * from View_Users_Not_active";
            DataTable Table = new DataTable();
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

        public static async Task<int> AddNewUserAsync(string UserName, string Password, int Person, byte Role)
        {
            int RowsAffected = 0;
            string Query = "SP_InsertUser";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                SqlTransaction Transaction = Connection.BeginTransaction();
                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection, Transaction))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@UserName", UserName);
                        Command.Parameters.AddWithValue("@Password", Password);
                        Command.Parameters.AddWithValue("@PersonID", Person);
                        Command.Parameters.AddWithValue("@Role", Role);
                        RowsAffected = await Command.ExecuteNonQueryAsync();
                    }
                    Transaction.Commit();
                }
                catch
                {
                    Transaction.Rollback();
                    throw;
                }
            }
            return RowsAffected;
        }

        public static async Task<bool> UpdatePasswordUserAsync(int UserID, string NewPassword)
        {
            int RowsAffected = 0;
            string Query = "SP_ChangePassword";
            using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    await connection.OpenAsync();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserID", UserID);
                    Command.Parameters.AddWithValue("@NewPassword", NewPassword);
                    RowsAffected = await Command.ExecuteNonQueryAsync();
                }
            }
            return RowsAffected > 0;
        }

        public static async Task<bool> DeleteUserAsync(int UserID)
        {
            int RowsAffected = 0;
            string Query = "SP_DeleteUser";
            using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await connection.OpenAsync();
                SqlTransaction Transaction = connection.BeginTransaction();
                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, connection, Transaction))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@UserID", UserID);
                        RowsAffected = await Command.ExecuteNonQueryAsync();
                    }
                    Transaction.Commit();
                }
                catch
                {
                    Transaction.Rollback();
                    throw;
                }
            }
            return RowsAffected > 0;
        }

        public static async Task<bool> IsUserExistAsync(int UserID)
        {
            bool IsFound = false;
            string Query = "select dbo.CheckUserExists(@UserID)";
            using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    await connection.OpenAsync();
                    Command.Parameters.AddWithValue("@UserID", UserID);
                    object Result = await Command.ExecuteScalarAsync();
                    if (Result != null)
                    {
                        IsFound = Convert.ToBoolean(Result);
                    }
                }
            }
            return IsFound;
        }

        public static async Task<bool> IsPasswordExistsAsync(int UserID, string Password)
        {
            bool IsFound = false;
            string Query = "select dbo.CheckPasswordExists(@UserID,@Password)";
            using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    await connection.OpenAsync();
                    Command.Parameters.AddWithValue("@UserID", UserID);
                    Command.Parameters.AddWithValue("@Password", Password);
                    object Result = await Command.ExecuteScalarAsync();
                    if (Result != null)
                    {
                        IsFound = Convert.ToBoolean(Result);
                    }
                }
            }
            return IsFound;
        }
    }
}
