using Restaurant.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    // Business Logic class for Orders
    public class clsOrdersBL
    {
        // Properties representing order fields
        public int? OrderID { get; set; }
        public int? TableID { get; set; }
        public int? UserID { get; set; }
        public clsUsersBL UserInfo { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? OrderStatus { get; set; }
        public string Notes { get; set; }

        // Property for order status as text (incorrectly implemented, see below)
        public string OrderStatusTEXT
        {
            set
            {
                OrderStatusTEXT = value;
                if (OrderStatus == true)
                    OrderStatusTEXT = "f";
                else
                    return;
            }
        }

        /// <summary>
        /// Default constructor initializes all properties to null
        /// </summary>
        public clsOrdersBL()
        {
            this.OrderID = null;
            this.TableID = null;
            this.UserID = null;
            this.TotalAmount = null;
            this.OrderStatus = null;
            this.Notes = null;
        }

        /// <summary>
        /// Parameterized constructor for initializing all properties
        /// </summary>

        public clsOrdersBL(int? OrderID, int? TableID, int? UserID,
            decimal? TotalAmount, bool? OrderStatus, string Notes)
        {
            this.OrderID = OrderID;
            this.TableID = TableID;
            this.UserID = UserID;
            this.TotalAmount = TotalAmount;
            this.OrderStatus = OrderStatus;
            this.Notes = Notes;
            // Initialize UserInfo if UserID is provided
            
        }

        /// <summary>
        /// Asynchronously retrieves all orders from the data layer
        /// </summary>
        /// <returns></returns>
        public async Task<DataTable> GetAllOrders()
        {
            return await clsOrdersDL.GetAllOrders();
        }

        /// <summary>
        /// Private method to add a new order using the data layer
        /// </summary>

        private async Task<Boolean> _AddNewOrder()
        {
            // Calls DAL to add a new order and sets the OrderID
            this.OrderID = await clsOrdersDL.AddNewOrder(
                this.TableID, this.UserID,
                this.TotalAmount, this.OrderStatus,
                this.Notes);
            // Returns true if OrderID was set (order added successfully)
            return this.OrderID != null;
        }

        /// <summary>
        /// Finds an order by OrderID and returns a new clsOrdersBL object if found
        /// </summary>

        public static clsOrdersBL Find(int? OrderID)
        {
            int? TableID = null;
            int? UserID = null;
            decimal? TotalAmount = null;
            bool? OrderStatus = null;
            string Notes = null;

            // Calls DAL to get order info by ID
            bool IsFound = clsOrdersDL.GetOrderInfoByID(
                OrderID, ref TableID, ref UserID,
                ref TotalAmount, ref OrderStatus,
                ref Notes);

            if (IsFound)
                return new clsOrdersBL(OrderID, TableID, UserID,
                    TotalAmount, OrderStatus, Notes);
            else
                return null;
        }

        /// <summary>
        /// Finds an order by TableID
        /// </summary>

        public static clsOrdersBL FindByTable(int? TableID)
        {
            int? OrderID = null;
            int? UserID = null;
            decimal? TotalAmount = null;
            bool? OrderStatus = null;
            string Notes = null;
            // Calls DAL to get order info by TableID
            bool IsFound = clsOrdersDL.GetOrderInfoByTableID(
                TableID, ref OrderID, ref UserID,
                ref TotalAmount, ref OrderStatus,
                ref Notes);
            if (IsFound)
                return new clsOrdersBL(OrderID, TableID, UserID,
                    TotalAmount, OrderStatus, Notes);
            else
                return null;
        }

        /// <summary>
        /// Finds an order by UserID
        /// </summary>
        /// <param name="UserID">User from User</param>
        /// <returns></returns>
        public static clsOrdersBL FindByUser(int? UserID)
        {
            int? OrderID = null;
            int? TableID = null;
            decimal? TotalAmount = null;
            bool? OrderStatus = null;
            string Notes = null;
            // Calls DAL to get order info by UserID
            bool IsFound = clsOrdersDL.GetOrderInfoByUserID(
                UserID, ref OrderID, ref TableID,
                ref TotalAmount, ref OrderStatus,
                ref Notes);
            if (IsFound)
                return new clsOrdersBL(OrderID, TableID, UserID,
                    TotalAmount, OrderStatus, Notes);
            else
                return null;
        }

        // Static method to check if an order is paid
        public static async Task<Boolean> IsOrderPaid(int? OrderID)
        {
            return await clsOrdersDL.IsOrderPaid(OrderID);
        }

        // Public method to save (add) a new order
        public async Task<Boolean> Save()
        {
            if (await _AddNewOrder())
                return true;

            return false;
        }
    }
}
