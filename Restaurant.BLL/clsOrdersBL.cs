using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public class clsOrdersBL
    {
        public int? OrderID { get; set; }
        public int? TableID { get; set; }
        public int ?UserID { get; set; }
       public decimal? TotalAmount { get; set; }
       public bool? OrderStatus { get; set; }
        public string Notes {  get; set; }

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
        

    }
}
