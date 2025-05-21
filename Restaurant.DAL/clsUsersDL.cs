using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class clsUsersDL
    {
        /// <summary>
        /// Retrieves all active users from the database view
        /// </summary>
       
        public static async Task<DataTable> GetUsersActiveAsync()
        {
            string Query = "Select * from View_UsersActive";
            DataTable Table = new DataTable();

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    await Connection.OpenAsync(); // Open the connection asynchronously
                    SqlDataReader Reader = await Command.ExecuteReaderAsync(); // Execute the reader
                    Table.Load(Reader); // Load the result into the DataTable
                }
            }

            return Table;
        }

        /// <summary>
        /// Retrieves all inactive users from the database view
        /// </summary>
    
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

        /// <summary>
        /// Inserts a new user using a stored procedure and transaction
        /// </summary>

        public static async Task<int?> AddNewUserAsync(string UserName, string Password, int? Person, short? Role)
        {
            int? UserID = null;
            string Query = "SP_InsertUser";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                SqlTransaction Transaction = Connection.BeginTransaction(); // Begin a database transaction

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection, Transaction))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Transaction = Transaction;
                        Command.Parameters.AddWithValue("@UserName", UserName);
                        Command.Parameters.AddWithValue("@Password", Password);
                        Command.Parameters.AddWithValue("@PersonID", Person);
                        Command.Parameters.AddWithValue("@Role", 1);

                        object Result = Command.ExecuteScalarAsync();   // Execute insert command
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            UserID = ID;
                        else
                            UserID = null;
                    }

                    Transaction.Commit(); // Commit the transaction if success
                }
                catch
                {
                    Transaction.Rollback(); // Rollback in case of error
                    UserID= null;
                    throw;
                }
            }
            
            return UserID;
        }

        /// <summary>
        /// Updates the password of a user using a stored procedure
        /// </summary>
  
        public static async Task<bool> UpdatePasswordUserAsync(int ?UserID, string NewPassword)
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

                    RowsAffected = await Command.ExecuteNonQueryAsync(); // Execute update
                }
            }

            return RowsAffected > 0; // Return true if update succeeded
        }
        public static async Task<bool> UpdateRoleOrPermisstionUserAsync(int? UserID, short? Role)
        {
            int RowsAffected = 0;
            string Query = "SP_UpdateRole";

            using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    await connection.OpenAsync();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserID", UserID);
                    Command.Parameters.AddWithValue("@Role", Role);

                    RowsAffected = await Command.ExecuteNonQueryAsync(); // Execute update
                }
            }

            return RowsAffected > 0; // Return true if update succeeded
        }

        /// <summary>
        /// Deletes a user using a stored procedure and transaction
        /// </summary>

        public static async Task<bool> DeleteUserAsync(int? UserID)
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
                        Command.Transaction = Transaction;
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

        /// <summary>
        /// Checks if a user exists by calling a scalar function
        /// </summary>

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

                    object Result = await Command.ExecuteScalarAsync(); // Execute scalar function
                    if (Result != null)
                    {
                        IsFound = Convert.ToBoolean(Result);
                    }
                }
            }

            return IsFound;
        }

        /// <summary>
        /// Checks if the given password exists for the specified user
        /// </summary>
 
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

        /// <summary>
        /// Gets the role text (e.g., Admin, Staff) for the user
        /// </summary>

        public static async Task<string> GetRoleUserText(int? UserID)
        {
            string RoleText = string.Empty;
            string Query = "select dbo.GetRoleTextUser(@UserID)";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    await Connection.OpenAsync();
                    Command.Parameters.AddWithValue("@UserID", UserID);

                    object Result = await Command.ExecuteScalarAsync();
                    if (Result != null)
                    {
                        RoleText = Result.ToString();
                    }
                }
            }

            return RoleText;
        }
    }
}
