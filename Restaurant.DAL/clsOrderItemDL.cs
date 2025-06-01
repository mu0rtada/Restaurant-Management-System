using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class clsOrderItemDL
    {
        /// <summary>
        /// Retrieves all order items from the view
        /// </summary>
        /// <returns>Get All Order Items</returns>
        public static async Task<DataTable> GetAllOrderItems()
        {
            DataTable Table = new DataTable();
            string Query = "Select * from View_GetOrderItems";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    // Open connection and load data into DataTable
                    Connection.Open();
                    SqlDataReader Reader = await Command.ExecuteReaderAsync();
                    Table.Load(Reader);
                }
            }

            return Table;
        }

        /// <summary>
        /// Inserts a new order item and returns the generated OrderItemID
        /// </summary>
        public static async Task<int?> AddNewOrderItem(int? OrderID, int? MenuItemID, int? Quantity, decimal? Price)
        {
            int? OrderItemID = null;
            string Query = "SP_InsertOrderItem";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                await Connection.OpenAsync();
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    // Begin transaction for safe insert
                    using (SqlTransaction Transaction = Connection.BeginTransaction())
                    {
                        try
                        {
                            Command.CommandType = CommandType.StoredProcedure;
                            Command.Transaction = Transaction;

                            // Add parameters with null handling
                            Command.Parameters.AddWithValue("@OrderID", OrderID);
                            Command.Parameters.AddWithValue("@MenuItemID", MenuItemID);
                            Command.Parameters.AddWithValue("@Quantity", (object)Quantity ?? DBNull.Value);
                            Command.Parameters.AddWithValue("@Price", Price);

                            // Execute and retrieve new ID
                            object Result= await Command.ExecuteScalarAsync();

                            if (Result != null && int.TryParse(Result.ToString(), out int ID))
                                OrderItemID = ID;
                            // Commit transaction
                            Transaction.Commit();
                        }
                        catch
                        {
                            // Rollback on failure
                            Transaction.Rollback();
                        }
                    }
                }
            }

            return OrderItemID;
        }

        /// <summary>
        /// Calculates the total amount for all items in an order
        /// </summary>
        /// <param name="OrderID">Order ID from Orders </param>
        /// <returns></returns>
        public static decimal CaculateOrderItemTotal(int OrderID)
        {
            decimal TotalAmount = 0;
            string Query = "select dbo.CaculateOrderItemTotal(@OrderID)";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();
                    Command.Parameters.AddWithValue("@OrderID", OrderID);

                    // Execute the function and convert result safely
                    object Result = Command.ExecuteScalar();
                    if (Result != DBNull.Value)
                        TotalAmount = Convert.ToDecimal(Result);
                }
            }

            return TotalAmount;
        }

        /// <summary>
        /// Deletes an order item by ID and returns true if deleted, false if not, null if failed
        /// </summary>
        /// <param name="OrderItemID">Delete this orderitem</param>
        /// <returns></returns>
        public static Boolean? DeleteOrderItem(int OrderItemID)
        {
            int? RowsAffected = null;
            string Query = "DeleteOrderItem";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Connection.Open();
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@OrderItemID", OrderItemID);

                        // Execute delete and get affected rows count
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                    catch
                    {
                        // Return null in case of any exception
                        return null;
                    }
                }
            }

            // Return true if at least one row deleted, false otherwise
            return RowsAffected > 0;
        }

    }
}
