using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class clsOrdersDL
    {
        /// <summary>
        /// Retrieves all orders from a database view.
        /// </summary>
        /// <returns>A DataTable containing all orders.</returns>
        public static async Task<DataTable> GetAllOrders()
        {
            DataTable Table = new DataTable();
            string Query = "select * from View_GetOrders";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    await Connection.OpenAsync(); // Open connection asynchronously
                    SqlDataReader Reader = await Command.ExecuteReaderAsync(); // Execute query and get data
                    Table.Load(Reader); // Load data into the DataTable
                }
            }

            return Table;
        }


        /// <summary>
        /// Adds a new order to the database using a stored procedure.
        /// </summary>
        /// <param name="TableID">ID of the table where the order is placed</param>
        /// <param name="UserID">ID of the user (cashier) creating the order</param>
        /// <param name="TotalAmount">Total amount of the order</param>
        /// <param name="Status">Order status (open/closed)</param>
        /// <param name="Notes">Additional notes for the order</param>
        /// <returns>The generated OrderID from the database</returns>
        public static async Task<int?> AddNewOrder(int ?TableID, int? UserID,
            decimal? TotalAmount, bool? Status, string Notes)
        {
            int? OrderID = null;
            string Query = "SP_InsertOpenOrder";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync(); // Open connection first

                using (SqlTransaction Transaction = Connection.BeginTransaction()) // Begin SQL transaction
                using (SqlCommand Command = new SqlCommand(Query, Connection, Transaction))
                {
                    try
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Transaction = Transaction;

                        // Add parameters to the stored procedure
                        Command.Parameters.AddWithValue("@TableID", TableID);
                        Command.Parameters.AddWithValue("@UserID", UserID);
                        Command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        Command.Parameters.AddWithValue("@Status", Status);
                        Command.Parameters.AddWithValue("@Notes", Notes);

                        // Execute the stored procedure and retrieve the newly inserted OrderID

                        object Result = await Command.ExecuteScalarAsync();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                            OrderID = ID;
                        else
                            OrderID = null;

                        Transaction.Commit(); // Commit the transaction if successful
                    }
                    catch (Exception)
                    {
                        Transaction.Rollback(); // Rollback transaction in case of error
                        throw; // Re-throw the exception to the calling method
                    }
                }
            }

            return OrderID;
        }

        /// <summary>
        /// Checks whether the specified order has been paid.
        /// </summary>
        /// <param name="OrderID">The ID of the order to check</param>
        /// <returns>True if paid, False otherwise</returns>
        public static async Task<bool> IsOrderPaid(int? OrderID)
        {
            bool IsPaid = false;
            string Query = "select dbo.IsOrderPaid(@OrderID)";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@OrderID", OrderID);
                    await Connection.OpenAsync();

                    object Result = await Command.ExecuteScalarAsync(); // Get the result from SQL function

                    if (Result != DBNull.Value)
                    {
                        IsPaid = Convert.ToBoolean(Result);
                    }
                }
            }

            return IsPaid;
        }

        /// <summary>
        /// Get Order Info by orderid 
        /// </summary>

        public static bool GetOrderInfoByID
            (int? OrderID, ref int? TableID, ref
            int? UserID, ref decimal? TotalAmount
            , ref bool? Status, ref string Notes)
        {
            bool IsFound = false;

            string Query = "SP_GetOrderByID";

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
                            TableID = (int)Reader["TableID"];
                            UserID = (int)Reader["UserID"];
                            TotalAmount = (decimal)Reader["TotalAmount"];
                            Status = (bool)Reader["Status"];
                            Notes = (string)Reader["Notes"];
                        }
                        else
                            IsFound = false;
                    }
                }
            }
            return IsFound;


        }
        /// <summary>
        /// Get Order Info by Tableid 
        /// </summary>

        public static bool GetOrderInfoByTableID
           (int? TableID, ref int? OrderID, ref
           int? UserID, ref decimal? TotalAmount
           , ref bool? Status, ref string Notes)
        {
            bool IsFound = false;

            string Query = "SP_GetOrderByTableID";

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
                            OrderID = (int)Reader["OrderID"];
                            UserID = (int)Reader["UserID"];
                            TotalAmount = (decimal)Reader["TotalAmount"];
                            Status = (bool)Reader["Status"];
                            Notes = (string)Reader["Notes"];
                        }
                        else
                            IsFound = false;
                    }
                }
            }
            return IsFound;


        }
        /// <summary>
        /// Get Order Info by Userid 
        /// </summary>

        public static bool GetOrderInfoByUserID
          (int? UserID, ref int? OrderID, ref
          int? TableID, ref decimal? TotalAmount
          , ref bool? Status, ref string Notes)
        {
            bool IsFound = false;

            string Query = "SP_GetOrderByUserID";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserID", TableID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;
                            OrderID = (int)Reader["OrderID"];
                            TableID = (int)Reader["TableID"];
                            TotalAmount = (decimal)Reader["TotalAmount"];
                            Status = (bool)Reader["Status"];
                            Notes = (string)Reader["Notes"];
                        }
                        else
                            IsFound = false;
                    }
                }
            }
            return IsFound;


        }

        /// <summary>
        /// Retrieves the textual status of an order (e.g. "Open", "Closed").
        /// </summary>
        /// <param name="OrderID">The ID of the order</param>
        /// <returns>Status text of the order</returns>
        public static async Task<string> GetStatusOrderText(int? OrderID)
        {
            string StatusText = "";
            string Query = "select OrderStatus from Orders where OrderID=@OrderID";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@OrderID", OrderID);
                    await Connection.OpenAsync();

                    SqlDataReader Reader = await Command.ExecuteReaderAsync();
                    if (Reader.Read())
                    {
                        StatusText = Reader["OrderStatus"].ToString(); // Read order status
                    }
                }
            }

            return StatusText;
        }




    }
}
