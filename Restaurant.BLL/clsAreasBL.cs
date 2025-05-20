using Restaurant.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public class clsAreasBL
    {
        public int AreaID { get; set; }
        public string AreaName { get;}

        public clsAreasBL()
        {
            AreaID = 0;
            AreaName = "";
        }
        public clsAreasBL(int areaID,string AreaName)
        {
            AreaID = areaID;
            AreaName = this.AreaName;
        }
        /// <summary>
        /// Get All Areas (Baghdad) from DataBase
        /// </summary>
       
        public static async Task<DataTable> GetAllAreas()
        {
            
          
            return await clsAreasBL.GetAllAreas();
            
        }
        /// <summary>
        /// Find Area By ID...............CLR
        /// </summary>
        /// <param name="AreaID">Area ID</param>
        
        public  static clsAreasBL FindAreaByID(int AreaID)
        {
            
            string AreaName = "";
            AreaName = clsAreasDL.GetAreaByID(AreaID);
            return  new clsAreasBL(AreaID, AreaName);
        }

    }
}
