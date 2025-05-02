using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace Restaurant.DAL
{
    public class clsPeopleDAL
    {
        // Get all people from a view
        public static  DataTable GetPeopleActive()
        {
            string Query = "select * from View_People order by PersonID";
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
  
        public static int AddNewPerson(string FirstName, string LastName, 
            int Age, byte Gendor, int AreaID
            ,byte PersonType,string ImagePath)
        {
            int RowsAffected = 0;
            string Query = "SP_InsertPerson";
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
                        Command.Parameters.AddWithValue("@FirstName", FirstName);
                        Command.Parameters.AddWithValue("@LastName", LastName);
                        Command.Parameters.AddWithValue("@Age", Age);
                        Command.Parameters.AddWithValue("@Gendor", Gendor);
                        Command.Parameters.AddWithValue("@AreaID", AreaID);
                        Command.Parameters.AddWithValue("@PersonType", PersonType);
                        Command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        // Execute the command and get the number of rows affected

                        RowsAffected = Command.ExecuteNonQuery();
                        Transaction.Commit(); // Commit transaction
                    }
                    catch (Exception ex)
                    {
                        Transaction.Rollback(); // Rollback transaction on error
                        throw ex; // Rethrow the exception
                    }
                }
            }
            return RowsAffected;
        }

        // Update an existing person using stored procedure (SP_UpdatePerson)
        public static int UpdatePerson(int PersonID, string FirstName, string LastName,
            int Age, byte Gendor, int AreaID
            , byte PersonType, string ImagePath)
        {
            int RowsAffected = 0;
            string Query = "SP_UpdatePerson";
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
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        Command.Parameters.AddWithValue("@FirstName", FirstName);
                        Command.Parameters.AddWithValue("@LastName", LastName);
                        Command.Parameters.AddWithValue("@Age", Age);
                        Command.Parameters.AddWithValue("@Gendor", Gendor);
                        Command.Parameters.AddWithValue("@AreaID", AreaID);
                        Command.Parameters.AddWithValue("@PersonType", PersonType);
                        Command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        // Execute the command and get the number of rows affected
                        RowsAffected = Command.ExecuteNonQuery();
                        Transaction.Commit(); // Commit transaction
                    }
                    catch (Exception ex)
                    {
                        Transaction.Rollback(); // Rollback transaction on error
                        throw ex; // Rethrow the exception
                    }
                }
            }
            return RowsAffected;
        }

        // Delete a person by ID using stored procedure (SP_DeletePerson)
        public static async Task<Boolean> DeletePerson(int PersonID)
        {
            int RowsAffected = 0;
            string Query = "SP_DeletePerson";
            using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    connection.OpenAsync();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    RowsAffected =await Command.ExecuteNonQueryAsync(); // Execute delete
                }
            }
            return RowsAffected > 0; // Return true if delete succeeded
        }
        // Get a person by ID using Function ()
        public static DataTable GetPersonByID(int PersonID)
        {
            string Query = "select * from dbo.FN_GetPersonByID(@PersonID)";
            DataTable Table = new DataTable();
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    SqlDataReader Reade = Command.ExecuteReader();
                    Table.Load(Reade); // Load results into DataTable
                }
            }
            return Table;
        }

    }
}
