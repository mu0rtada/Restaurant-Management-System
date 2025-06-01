using Restaurant.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
        public class clsMenuItemsBL
        {
            public int? MenuItemID { get; set; }
            public string MenuItemName { get; set; }
            public string Description { get; set; }
            public decimal? Price { get; set; }
            public int? CategoryID { get; set; }
            public clsMenuCategoryBL CategoryInfo {  get; set; }
            public string ImagePath { get; set; }

            private enum enMode { eAddNew=0,eUpdate}
            enMode _Mode = enMode.eAddNew;
            public clsMenuItemsBL()
            {
                this.MenuItemID = null;
                this.MenuItemName = null;
                this.Description = null;
                this.Price = null;
                this.CategoryID = null;
                this.ImagePath = null;
                //add new menu item
                _Mode = enMode.eAddNew;
            }

        public clsMenuItemsBL(int? menuItemID, string menuItemName,
                string description, decimal? price,
                int? categoryID, string imagePath)
            {
            MenuItemID = menuItemID;
                MenuItemName = menuItemName;
                Description = description;
                Price = price;
                CategoryID = categoryID;
                ImagePath = imagePath;
               //Update & Find
               _Mode= enMode.eUpdate;

            this.CategoryInfo = clsMenuCategoryBL.Find(categoryID);
            }

        public static async Task<DataTable>GetAllOrderItems()
        {
            return await clsMenuItemsDL.GetAllMenuItems();
        }

        public static async Task<DataTable> GetAllOrderItemsByCategory(int CategoryID)
        {
            return await clsMenuItemsDL.GetAllMenuItemsByCategoryID(CategoryID);
        }

        private async Task<Boolean>_AddNewMenuItem()
        {
            this.MenuItemID=await clsMenuItemsDL.AddNewMenuItem(
                this.MenuItemName,this.Description,this.Price,
                this.CategoryID,this.ImagePath);
          return  this.MenuItemID != null;
        }

        private async Task<Boolean> _UpdateMenuItem()
        {
            return await clsMenuItemsDL.UpdateMenuItem(this.MenuItemID,
                this.MenuItemName, this.Description, this.Price,
                this.CategoryID, this.ImagePath);
             
        }
   
        public static clsMenuItemsBL Find(int?MenuItemID)
        {
            string MenuItemName = null;
            string Description = null;
            decimal? Price = null;
            int ? categoryID = null;
            string imagePath = null;

            bool IsFound = clsMenuItemsDL.GetMenuItemInfoByID
                (MenuItemID, ref MenuItemName, ref Description, ref Price,
               ref categoryID, ref imagePath);

            if (IsFound)
                return new clsMenuItemsBL
                    (MenuItemID, MenuItemName, Description, Price
                    , categoryID, imagePath);
            else return null;
        }
        public static clsMenuItemsBL FindByCategory(int? CategoryID)
        {
            int? MenuItemID = null;
            string MenuItemName = null;
            string Description = null;
            decimal? Price = null;
            string imagePath = null;

            bool IsFound = clsMenuItemsDL.GetMenuItemInfoByCategoryID
                (CategoryID,ref MenuItemID, ref MenuItemName, ref Description, ref Price
             , ref imagePath);

            if (IsFound)
                return new clsMenuItemsBL
                    (MenuItemID, MenuItemName, Description, Price
                    , CategoryID, imagePath);
            else return null;
        }

        public async Task<bool>Save()
        {
            switch (_Mode)
            {
                case enMode.eAddNew:
                    if(await _AddNewMenuItem())
                        return true;
                    break;
                case enMode.eUpdate:
                    if(await _UpdateMenuItem()) return true;
                    break;
               

            }
            return false;
        }

    }
}
