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
                            else
                                PaymentID = null;
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

        public static bool GetOrderInfoByPaymentID
          (int? PaymentID, ref int? OrderID,
           ref decimal? Amount, ref string PaymentMethod,
            ref bool? IsRefounded)
        {
            bool IsFound = false;

            string Query = "SP_GetPaymentInfoByID";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PaymentID", PaymentID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;
                            OrderID = (int)Reader["OrderID"];
                            Amount = (decimal)Reader["TableName"];
                            PaymentMethod = (string)Reader["PaymentMethod"];
                            IsRefounded = (bool)Reader["IsRefounded"];


                        }
                        else
                            IsFound = false;
                    }
                }
            }
            return IsFound;


        }
        public static bool GetOrderInfoByOrderID
         (int? OrderID, ref int? PaymentID,
           ref decimal? Amount, ref string PaymentMethod,
            ref bool? IsRefounded)
        {
            bool IsFound = false;

            string Query = "SP_GetPaymentInfoByOrderID";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@OrderID", OrderID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;
                            PaymentID = (int)Reader["PaymentID"];
                            Amount = (decimal)Reader["TableName"];
                            PaymentMethod = (string)Reader["PaymentMethod"];
                            IsRefounded = (bool)Reader["IsRefounded"];


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
