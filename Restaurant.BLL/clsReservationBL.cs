using Restaurant.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public class clsReservationBL
    {

        public int? ReservationID { get; set; }
        public int? PersonID { get; set; }
        public clsPersonBL PersonInfo { get; set; }
        public int? TableID { get; set; }
        public clsTablesBL TableInfo { get; set; }
        public DateTime? ReservationDate { get; set; }
        public bool? ReservationStatus { get; set; }
        private enum enMode
        {
            eAdd = 0,
            eUpdate = 1
        }
        enMode _Mode = enMode.eAdd;

        public clsReservationBL()
        {
            this.ReservationID = null;
            this.PersonID = null;
            this.TableID = null;
            this.ReservationDate = null;
            this.ReservationStatus = null;
            _Mode = enMode.eAdd;
        }
        public clsReservationBL(int? reservationID, int? personID, int? tableID, DateTime? reservationDate, bool? reservationStatus)
        {
            this.ReservationID = reservationID;
            this.PersonID = personID;
            this.TableID = tableID;
            this.ReservationDate = reservationDate;
            this.ReservationStatus = reservationStatus;
            _Mode = enMode.eUpdate;
        }
        public static async Task<DataTable> GetAllReservations()
        {
            return await clsReservationDL.GetAllReservation();
        }
        public static async Task<DataTable> GetAllTodayReservations()
        {
            return await clsReservationDL.GetAll_Today_Reservation();
        }
        public async Task<bool> AddNewReservation()
        {
            this.ReservationID = await clsReservationDL.AddNewReservation(
                this.PersonID, this.TableID, this.ReservationDate, this.ReservationStatus);
            return this.ReservationID != null;
        }
        public async Task<bool> UpdateReservationDate()
        {
            return await clsReservationDL.UpdateReservationDate(
                this.ReservationID, this.ReservationDate);
        }
        public async Task<bool> UpdateReservationStatus()
        {
            return await clsReservationDL.UpdateReservationStatus(
                this.ReservationID, this.ReservationStatus);
        }
        public clsReservationBL FindTest(int? ReservationID)
        {
            DataTable Table = clsReservationDL.GetAllReservation().Result;
            if (Table != null && Table.Rows.Count > 0)
            {
                DataRow Row = Table.AsEnumerable().FirstOrDefault(r => r.Field<int?>("ReservationID") == ReservationID);
                if (Row != null)
                {
                    return new clsReservationBL(
                        Row.Field<int?>("ReservationID"),
                        Row.Field<int?>("PersonID"),
                        Row.Field<int?>("TableID"),
                        Row.Field<DateTime?>("ReservationDate"),
                        Row.Field<bool?>("Status")
                        
                        
                    );
                }
            }
            return null;


        }

        public async Task<bool>Save()

        {
            switch (_Mode)
            {
                case enMode.eAdd:
                    return await AddNewReservation();
                case enMode.eUpdate:
                    if (this.ReservationID != null)
                    {
                        return await UpdateReservationDate()||await UpdateReservationStatus();
                    }
                    break;
            }

                    return false;
        }

    }
}
