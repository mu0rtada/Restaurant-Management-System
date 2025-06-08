using Restaurant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public class clsPaymentBL
    {
        public int? PaymentID { get; set; }
        public int? OrderID { get; set; }
        public clsOrdersBL OrderInfo { get; set; }
        public decimal? Amount { get; set; }
        public string PaymentMethod { get; set; }
        public bool? IsRefounded { get; set; }

        private enum enMode { eAdd = 0, eUpdate = 1 }
        private enMode _Mode = enMode.eAdd;
        public clsPaymentBL()
        {
            this.PaymentID = null;
            this.OrderID = null;
            this.Amount = null;
            this.PaymentMethod = null;
            this.IsRefounded = false;
            _Mode = enMode.eAdd;
        }

        public clsPaymentBL(int? paymentID, int? orderID, decimal? amount, string paymentMethod, bool? isRefounded)
        {

            PaymentID = paymentID;
            OrderID = orderID;
            Amount = amount;
            PaymentMethod = paymentMethod;
            IsRefounded = isRefounded;
            //Update & get info order by ID
            _Mode = enMode.eUpdate;
            this.OrderInfo = clsOrdersBL.Find(this.OrderID);
        }

        public static clsPaymentBL Find(int? PaymentID)
        {
            int? OrderID = null;
            decimal? Amount = null;
            string PaymentMethod = null;
            bool? IsRefounded = null;
            bool IsFound = Restaurant.
                DAL.clsPaymentDL.GetOrderInfoByPaymentID
                (PaymentID, ref OrderID, ref Amount,
                ref PaymentMethod, ref IsRefounded);

            if (IsFound)
                return new clsPaymentBL(PaymentID, OrderID, Amount, PaymentMethod, IsRefounded);
            else
                return null; // Not found
        }

        public static clsPaymentBL FindByOrder(int? OrderID) {
            int? PaymentID = null;
            decimal? Amount = null;
            string PaymentMethod = null;
            bool? IsRefounded = null;
            bool IsFound = Restaurant.
                DAL.clsPaymentDL.GetOrderInfoByOrderID
                (OrderID, ref PaymentID, ref Amount,
                ref PaymentMethod, ref IsRefounded);
            if (IsFound)
                return new clsPaymentBL(PaymentID, OrderID, Amount, PaymentMethod, IsRefounded);
            else
                return null; // Not found

            
        }
        private async  Task<bool> _AddNewPayment()
        {
            // Add new payment to database
            this.PaymentID=await clsPaymentDL.AddNewPayment(
                this.OrderID, this.Amount, this.PaymentMethod);
            return this.PaymentID != null;
        }
        private async Task <Boolean>_UpdatePaymentStatus()
        {
            // Update payment status to refunded
            return await clsPaymentDL.UpdateStatusRefundedPayment(this.OrderID.Value);
        }



        public async Task<bool> Save()
        {
            switch(_Mode)
            {
                case enMode.eAdd:
                    if (await _AddNewPayment())
                        return true;
                    break;
                case enMode.eUpdate:
                    await _UpdatePaymentStatus();
                    return true;
                    

            }
            return false;
        }
    
    }

}

