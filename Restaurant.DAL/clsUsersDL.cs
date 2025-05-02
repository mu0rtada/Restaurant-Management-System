// Data Access Layer class for handling user-related operations
using Restaurant.DAL;
using System.Data.SqlClient;
using System.Data;
using System;

public class clsUsersDL
{
    // Get all active users from a view
    public static DataTable GetUsersActive()
    {
        string Query = "Select * from View_UsersActive";
        DataTable Table = new DataTable();
        using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Connection.Open();
                SqlDataReader Reade = Command.ExecuteReader();
                Table.Load(Reade); // Load results into DataTable
            }
        }
        return Table;
    }

    // Get all inactive users from a view
    public static DataTable GetUsers_Not_active()
    {
        string Query = "Select * from View_Users_Not_active";
        DataTable Table = new DataTable();
        using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Connection.Open();
                SqlDataReader Reade = Command.ExecuteReader();
                Table.Load(Reade); // Load results into DataTable
            }
        }
        return Table;
    }

    // Add a new user using stored procedure (SP_InsertUser)
    public static int AddNewUser(string UserName, string Password, int Person, byte Role)
    {
        int RowsAffected = 0;
        string Query = "SP_InsertUser";

        using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Connection.Open();
                SqlTransaction Transaction = Connection.BeginTransaction(); // Begin transaction
                try
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Transaction = Transaction;
                    Command.Parameters.AddWithValue("@UserName", UserName);
                    Command.Parameters.AddWithValue("@Password", Password);
                    Command.Parameters.AddWithValue("@PersonID", Person);
                    Command.Parameters.AddWithValue("@Role", Role);
                    RowsAffected = Command.ExecuteNonQuery(); // Execute insert
                    Transaction.Commit(); // Commit changes
                }
                catch
                {
                    Transaction.Rollback(); // Rollback if error
                    throw;
                }
            }
        }
        return RowsAffected;
    }

    // Update the password for a user using SP
    public static Boolean UpdatePasswordUser(int UserID, string NewPassword)
    {
        int RowsAffected = 0;
        string Query = "SP_ChangePassword";
        using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, connection))
            {
                connection.Open();
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@UserID", UserID);
                Command.Parameters.AddWithValue("@NewPassword", NewPassword);
                RowsAffected = Command.ExecuteNonQuery(); // Execute update
            }
        }
        return RowsAffected > 0; // Return true if update succeeded
    }

    // Delete a user by ID using stored procedure
    public static Boolean DeleteUser(int UserID)
    {
        int RowsAffected = 0;
        string Query = "SP_DeleteUser";
        using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, connection))
            {
                connection.Open();
                SqlTransaction Transaction = connection.BeginTransaction(); // Begin transaction
                try
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Transaction = Transaction;
                    Command.Parameters.AddWithValue("@UserID", UserID);
                    RowsAffected = Command.ExecuteNonQuery(); // Execute delete
                    Transaction.Commit(); // Commit changes
                }
                catch
                {
                    Transaction.Rollback(); // Rollback if error
                    throw;
                }
            }
        }
        return RowsAffected > 0; // Return true if deletion succeeded
    }

    // Check if a user exists by ID using a SQL function
    public static Boolean IsUserExist(int UserID)
    {
        Boolean IsFound = false;
        string Query = "select dbo.CheckUserExists(@UserID)";
        using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, connection))
            {
                connection.Open();
                Command.Parameters.AddWithValue("@UserID", UserID);
                object Result = Command.ExecuteScalar(); // Execute function
                if (Result != null)
                {
                    IsFound = Convert.ToBoolean(Result); // Convert result to boollllll
                }
            }
        }
        return IsFound;
    }

    // Check if the given password exists for the user
    public static Boolean IsPasswordExists(int UserID, string Password)
    {
        Boolean IsFound = false;
        string Query = "select dbo.CheckPasswordExists(@UserID,@Password)";
        using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, connection))
            {
                connection.Open();
                Command.Parameters.AddWithValue("@UserID", UserID);
                Command.Parameters.AddWithValue("@Password", Password);
                object Result = Command.ExecuteScalar(); // Execute function
                if (Result != null)
                {
                    IsFound = Convert.ToBoolean(Result); // Convert result to bool!
                }
            }
        }

        return IsFound;
    }
}
