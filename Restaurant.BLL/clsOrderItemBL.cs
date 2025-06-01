using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public  class clsOrderItemBL
    {
        public int? OrderItemID { get; set; }
        public int? OrderID {  get; set; }
        public clsOrdersBL OrdersInfo { get; set; }
        public int? MenuItemID { get; set; }
        public clsMenuItemsBL OrderInfo { get; set; }
        public  int? Quantity {  get; set; }
        public decimal? Price { get; set; }

        public clsOrderItemBL(int? orderItemID, int? orderID, clsOrdersBL ordersInfo, int? menuItemID, clsMenuItemsBL orderInfo, int? quantity, decimal? price)
        {
            OrderItemID = orderItemID;
            OrderID = orderID;
            OrdersInfo = ordersInfo;
            MenuItemID = menuItemID;
            OrderInfo = orderInfo;
            Quantity = quantity;
            Price = price;
        }
    }
}
