using Restaurant.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public class clsMenuCategoryBL
    {
        public int? CategoryID {  get; set; }
        public string CategoryName { get; set; }
        public bool IsAvailable { get; set; }

        private enum enMode { eAdd=0,eUpdate=1}
        private enMode _Mode = enMode.eAdd;

        public clsMenuCategoryBL()
        {
            this.CategoryID = null;
            this.CategoryName = null;
            this.IsAvailable = false;
        }
        public clsMenuCategoryBL(int? categoryID, string categoryName, bool isAvailable)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            IsAvailable = isAvailable;
            
        }

        public static async Task<DataTable> GetAllPeople() =>
           await clsMenuCategoriesDL.GetAllMenuItems();

        private async Task<bool>_AddNewMenuCategory()
        {
            this.CategoryID =await clsMenuCategoriesDL.AddNewCategory
                (this.CategoryName);
            return CategoryID != null;
        }
        private async Task<bool> _UpdateMenuCategory()
            => await clsMenuCategoriesDL.UpdateCategoryStatus
            (this.CategoryID, this.IsAvailable);

        public static async Task<Boolean> DeleteMenuCategory(int? MenuCategoryID)
          =>await clsMenuCategoriesDL.DeleteCategory(MenuCategoryID);

        public static clsMenuCategoryBL Find(int? menuCategoryID)
        {
            string CategoryName = null;
            bool IsAvailable = false;

            bool IsFound = clsMenuCategoriesDL.GetMenuCategoryByID
                (menuCategoryID, ref CategoryName, ref IsAvailable);

            
          return  IsFound ? new clsMenuCategoryBL(menuCategoryID, CategoryName, IsAvailable) : null;
        }

        public static async Task<bool> IsMenuCategoryExists(string CategoryName)
            =>await clsMenuCategoriesDL.IsCategoryNameExists(CategoryName);

        public async Task<Boolean>Save()
        {
            switch (_Mode)
            {
                case enMode.eAdd:
                    if (await _AddNewMenuCategory())
                        return true;
                    else return false;
                case enMode.eUpdate:
                    if (await _UpdateMenuCategory())
                        return true;
                    else return false;

            }
            return false;
        }


    }
}
