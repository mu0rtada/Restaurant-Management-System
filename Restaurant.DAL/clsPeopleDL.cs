using Microsoft.SqlServer.Server;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace Restaurant.DAL
{
    public class clsPeopleDL
    {
        /// <summary>
        /// Get all people from a view
        /// </summary>
      
        public static async Task <DataTable> GetPeopleActive()
        {
            string Query = "select * from View_People order by PersonID";
            DataTable Table = new DataTable();
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                   await Connection.OpenAsync();
                    SqlDataReader Reade =await Command.ExecuteReaderAsync();
                    Table.Load(Reade); // Load results into DataTable
                }
            }
            return Table;
        }
  /// <summary>
  /// Add New Person Info
  /// </summary>

        public static async  Task<int?> AddNewPerson(string FirstName, string LastName, 
            int Age, byte Gendor, int AreaID,string Email
            ,byte PersonType,string ImagePath)
        {
            int? RowsAffected = 0;
            string Query = "SP_InsertPerson";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                   await Connection.OpenAsync();
                    using (SqlTransaction Transaction = Connection.BeginTransaction())// Begin transaction
                    {
                        try
                        {
                            Command.CommandType = CommandType.StoredProcedure;
                            Command.Transaction = Transaction;
                            Command.Parameters.AddWithValue("@FirstName", FirstName);
                            Command.Parameters.AddWithValue("@LastName", LastName);
                            Command.Parameters.AddWithValue("@Age", Age);
                            Command.Parameters.AddWithValue("@Gendor", Gendor);
                            Command.Parameters.AddWithValue("@AreaID", AreaID);
                            Command.Parameters.AddWithValue("@Email",(object) Email??DBNull.Value);
                            Command.Parameters.AddWithValue("@PersonType", PersonType);
                            Command.Parameters.AddWithValue("@ImagePath", (object)ImagePath??DBNull.Value);
                            // Execute the command and get the number of rows affected

                            object Result = await Command.ExecuteScalarAsync();
                            if(Result!=null&&int.TryParse(Result.ToString(),out int ID))
                            {
                                RowsAffected = ID;
                            }
                            Transaction.Commit(); // Commit transaction
                        }
                        catch (Exception)
                        {
                            Transaction.Rollback(); // Rollback transaction on error
                            throw; // Rethrow the exception
                        }
                    }
                }
            }
            return RowsAffected;
        }

        /// <summary>
        /// Update an existing person using 
        /// stored procedure (SP_UpdatePerson)
        /// </summary>

        public static async Task<bool> UpdatePerson(int? PersonID, string FirstName, string LastName,
             int AreaID
            , byte PersonType, string ImagePath)
        {
            int RowsAffected = 0;
            string Query = "SP_UpdatePerson";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                   await Connection.OpenAsync();
                    using (SqlTransaction Transaction = Connection.BeginTransaction()) // Begin transaction
                    {
                        try
                        {
                            Command.CommandType = CommandType.StoredProcedure;
                            Command.Transaction = Transaction;
                            Command.Parameters.AddWithValue("@PersonID", PersonID);
                            Command.Parameters.AddWithValue("@FirstName", FirstName);
                            Command.Parameters.AddWithValue("@LastName", LastName);
                            Command.Parameters.AddWithValue("@AreaID", AreaID);
                            Command.Parameters.AddWithValue("@PersonType", PersonType);
                            Command.Parameters.AddWithValue("@ImagePath",(object) ImagePath??DBNull.Value);
                            // Execute the command and get the number of rows affected
                            RowsAffected = await Command.ExecuteNonQueryAsync();
                            Transaction.Commit(); // Commit transaction
                        }
                        catch (Exception )
                        {
                            Transaction.Rollback(); // Rollback transaction on error
                            throw; // Rethrow the exception
                        }
                    }
                }
            }
            return RowsAffected>0;
        }

        /// <summary>
        /// Delete a person by ID using stored procedure (SP_DeletePerson)
        /// </summary>

        public static async Task<Boolean> DeletePerson(int PersonID)
        {
            int RowsAffected = 0;
            string Query = "SP_DeletePerson";
            using (SqlConnection connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                  await connection.OpenAsync();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    RowsAffected =await Command.ExecuteNonQueryAsync(); // Execute delete
                }
            }
            return RowsAffected > 0; // Return true if delete succeeded
        }
        /// <summary>
        /// Get Function FullName Person By ID (GetFullNamePerson)
        /// </summary>


        public static string GetFullNamePersonByID(int PersonID)
        {
            string FullName = string.Empty;
            string Query = "select dbo.GetFullNamePerson(@PersonID)";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                     Connection.Open();
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    object Result =  Command.ExecuteScalar(); // Execute the query
                    if (Result != DBNull.Value)
                    {
                        FullName = Result.ToString(); // Convert result to string
                    }

                }
            }
                return FullName; // Return full name

        }
        /// <summary>
        /// Get Exitst for person by ID
        /// </summary>

        public static async Task<Boolean>IsPersonExists(int PersonID)
        {
            bool IsFound = false;
            string Query = "select dbo.IsPersonExists(@PersonID)";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    await Connection.OpenAsync();
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    object Result = await Command.ExecuteScalarAsync(); // Execute the query
                    if (Result != DBNull.Value)
                    {
                        IsFound = Convert.ToBoolean(Result); // Convert result to boolean
                    }
                }
            }
            return IsFound; // Return true if person exists
        }

    }
}
