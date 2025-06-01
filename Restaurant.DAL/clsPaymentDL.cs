using System;
using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class clsPaymentDL
    {
        /// <summary>
        /// Retrieves all payment records from the view
        /// </summary>
     
        public static async Task<DataTable> GetAllPayment()
        {
            string Query = "SELECT * FROM View_GetPayment";
            DataTable Table = new DataTable();

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    await Connection.OpenAsync(); // Open connection asynchronously
                    SqlDataReader Reader = await Command.ExecuteReaderAsync(); // Execute reader
                    Table.Load(Reader); // Load results into DataTable
                }
            }

            return Table;
        }

        /// <summary>
        /// Adds a new payment and returns the generated PaymentID
        /// </summary>


        public static async Task<int?> AddNewPayment(int? OrderID, decimal? Amount, string PaymentMethod)
        {
            int? PaymentID = null;
            string Query = "SP_MakePayment";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync(); // Open connection asynchronously
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    using (SqlTransaction Transaction = Connection.BeginTransaction())
                    {
                        try
                        {
                            Command.CommandType = CommandType.StoredProcedure;
                            Command.Transaction = Transaction;

                            // Add parameters and handle nulls
                            Command.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);
                            Command.Parameters.AddWithValue("@Amount", (object)Amount ?? DBNull.Value);
                            Command.Parameters.AddWithValue("@PaymentMethod", (object)PaymentMethod ?? DBNull.Value);

                            // Execute stored procedure and retrieve the inserted PaymentID
                            object Result = await Command.ExecuteScalarAsync();
                            if (Result != null && Result != DBNull.Value)
                                PaymentID = Convert.ToInt32(Result);

                            Transaction.Commit(); // Commit transaction on success
                        }
                        catch (Exception)
                        {
                            Transaction.Rollback(); // Rollback on failure
                        }
                    }
                }
            }

            return PaymentID;
        }
        //ابو حلك

        /// <summary>
        /// Updates payment status to refunded for a specific order
        /// </summary>
        public static async Task<Boolean> UpdateStatusRefundedPayment(int OrderID)
        {
            int RowsAffected = 0;
            string Query = "SP_RefoundPayment";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    await Connection.OpenAsync(); // Open connection asynchronously
                    Command.Parameters.AddWithValue("@OrderID", OrderID); // Add OrderID parameter

                    // Execute the command and get number of affected rows
                    RowsAffected = await Command.ExecuteNonQueryAsync();
                }
            }

            return RowsAffected > 0; // Return true if update succeeded
        }

    }
}
