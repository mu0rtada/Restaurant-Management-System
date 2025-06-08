using Restaurant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public class clsFeedBackBL
    {
        public int ? FeedBackID {  get; set; }
        public int? PersonID { get; set; }
        public clsPersonBL PersonInfo {  get; set; }
        public int? OrderID { get; set; }
        public clsOrdersBL OrderInfo { get; set; }
        public byte? Rating { get; set; }

        private enum enMode
        {
            eAdd = 0,
            eUpdate = 1
        }
        private enMode _Mode = enMode.eAdd;
        public clsFeedBackBL()
        {
            this.FeedBackID = null;
            this.PersonID = null;
            this.OrderID = null;
            this.Rating = null;
            _Mode = enMode.eAdd;
        }
        public clsFeedBackBL(int? FeedBackID, int? PersonID, int? OrderID, byte? Rating)
        {
            this.FeedBackID = FeedBackID;
            this.PersonID = PersonID;
            this.OrderID = OrderID;
            this.Rating = Rating;
            _Mode = enMode.eUpdate;
            // Update & get info person by ID
            this.PersonInfo = clsPersonBL.Find(this.PersonID);
            // Update & get info order by ID
            this.OrderInfo = clsOrdersBL.Find(this.OrderID);
        }

        protected async Task<Boolean>_AddNewFeedBack()
        {
            this.FeedBackID = await clsFeedBack.AddNewFeedBack(
                this.PersonID, this.OrderID, this.Rating);
            return FeedBackID != null;
        }
        private async Task<bool>_UpdateRating()
        {
            return await clsFeedBack.UpdateRating(this.OrderID, Rating);
        }

        public static int ManyRatingThisPerson(int PersonID)
        {
            return clsFeedBack.ManyRatingThisPerson(PersonID);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.eAdd:
                    if (await _AddNewFeedBack())
                        return true;
                    break;
                case enMode.eUpdate:
                    await _UpdateRating();
                    return true;


            }
            return false;
        }
    }
}
