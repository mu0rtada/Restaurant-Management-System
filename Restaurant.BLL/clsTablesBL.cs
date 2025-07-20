using Restaurant.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public class clsTablesBL
    {
        public int? TableID {  get; set; }
        public string TableName { get; set; }
        public short? TableCapcity { get; set; }
        public bool? TableStatus { get; set; }

        private enum enMode { eAdd=0,eUpdate=1}
        private enMode _Mode { get; set; }
        public clsTablesBL()
        {
            TableID = null;
            TableName = null;
            TableCapcity = null;
            TableStatus = null;
            _Mode = enMode.eAdd;
        }
        public clsTablesBL(int? tableID, string tableName, short? capcity, bool? status)
        {
            TableID = tableID;
            TableName = tableName;
            TableCapcity = capcity;
            TableStatus = status;
            _Mode = enMode.eUpdate;
        }

        public static async Task<DataTable>GetAllTable()
        {
            return await clsTableDL.GetTables();
        }

        public static async Task<DataTable> GetAvailableTables()
        {
            return await clsTableDL.GetAvailableTables();
        }

       


        private async Task<bool>_AddNewTable()
        {
            this.TableID= await clsTableDL.AddNewTable(this.TableName,
                this.TableCapcity) ;
           return TableID != null;
        }
        private async Task<bool> _UpdateTable()
        {
            return await clsTableDL.UpdateTableStatus(this.TableID,
                this.TableStatus) ;
        }

        public clsTablesBL Find(int? TableID)
        {
            string TableName = null;
          short  ?TableCapcity = null;
           bool? TableStatus = null;

            bool IsFound = clsTableDL.GetTableInfoByID
                  (TableID, ref TableName, ref TableCapcity,
                  ref TableStatus);

            if (IsFound)
                return new clsTablesBL(TableID, TableName, TableCapcity, TableStatus);
            else
                return null;
        }

        public static async Task<bool>IsTableAvailable(int?TableID)
        {
            return await clsTableDL.IsTableAvailable(TableID);
        }
        
    }
}
