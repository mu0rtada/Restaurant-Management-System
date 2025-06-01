using Restaurant.DAL;
using System;
using System.Data;
using System.Threading.Tasks;
using static Restaurant.BLL.clsPersonBL;

namespace Restaurant.BLL
{
    public class clsUsersBL
    {
     public int? UserID {  get; set; }
     public string UserName { get; set; }
     public string Password { get; set; }
     public int? PersonID {  get; set; }
     public clsPersonBL PersonInfo { get; set; }
     public short? Role { get; set; } //Role User 
     public bool? IsActive {  get; set; }
     private enum enMode { eAdd=0,eUpdate=1}
     enMode _Mode = enMode.eAdd;

        //Permisstion
        [Flags]
        public enum enPermisstion
        {
            ePeople=2,
            eUsers=4,
            eOrders=8,
            eOrderItem=16,
            eTables=32,
            eMenuItems=64,
            ePayments=128,
            eMenuCategory=256,
            eReservations=512,
            eFeedBack=1024,
            eAll=-1,//Leader (Murtadaa)

        }
        public enum enUserRole { Leader=1,Assistant=2}
        public enUserRole UserRoleText
        {
            get
            {
                return this.Role == -1 ? enUserRole.Leader : enUserRole.Assistant;

            }
        }
        public clsUsersBL()
        {
            this.UserID = null;
            this.UserName = null;
            this.Password = null;
            this.PersonID = null;
            this.Role = null;
            this.IsActive = false;

            _Mode = enMode.eAdd;
        }
        public clsUsersBL(int? userID, string userName, string password, int? personID, short? role, bool? isActive)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            PersonID = personID;
                        Role = role;
            IsActive = isActive;
            _Mode = enMode.eUpdate;
            //find person
            this.PersonInfo=clsPersonBL.Find(personID);

        }

        public static async Task<DataTable>GetUsers_Active()
        {
            return await DAL.clsUsersDL.GetUsersActiveAsync();
        }

        public static async Task<DataTable> GetUsers_Not_Active()
        {
            return await DAL.clsUsersDL.GetUsers_Not_activeAsync();
        }

        private async Task<bool> _AddNewUser()
        {
            this.PersonID= await Restaurant.DAL.clsUsersDL.AddNewUserAsync(
                this.UserName, this.Password,
                this.PersonID, this.Role
                );
            return PersonID != null;
        }
        private async Task<bool>_UpdateRoleUser()
        {
            return await Restaurant.
                DAL.clsUsersDL.
                UpdateRoleOrPermisstionUserAsync
                (this.UserID, this.Role);
            
        }
        public static async Task<bool>UpdatePasswordUser(int?UserID,string NewPassword)
        {
            return await Restaurant.DAL.clsUsersDL
                .UpdatePasswordUserAsync
                (UserID, NewPassword);
        }

        public static clsUsersBL Find(int?UserID)
        {
            int? personID = null;
            string userName = null;
            string password = null;
            short? Role = null;
            bool? isActive = null;
            // Calls DAL to get user info by ID
            bool isFound = clsUsersDL.GetUserInfoByID(UserID,
                ref userName, ref personID, ref Role, ref isActive);
            if (isFound)
                return new clsUsersBL(UserID, userName, password,
                    personID, Role, isActive);
            else
                return null;
        }
        public static clsUsersBL FindByUserName(string UserName)
        {
            int? userID = null;
            int? personID = null;
            string password = null;
            short? Role = null;
            bool? isActive = null;
            // Calls DAL to get user info by UserName
            bool isFound = clsUsersDL.GetUserInfoByUserName(UserName,
                ref userID, ref personID, ref Role, ref isActive);
            if (isFound)
                return new clsUsersBL(userID, UserName, password,
                    personID, Role, isActive);
            else
                return null;
        }
        public static clsUsersBL FindByPerson(int? PersonID)
        {
            int? userID = null;
            string userName = null;
            string password = null;
            short? Role = null;
            bool? isActive = null;
            // Calls DAL to get user info by PersonID
            bool isFound = clsUsersDL.GetUserInfoByPersonID(PersonID,
                ref userID, ref userName, ref Role, ref isActive);
            if (isFound)
                return new clsUsersBL(userID, userName, password,
                    PersonID, Role, isActive);
            else
                return null;
        }

        public static async Task<bool>DeleteUser(int?UserID)
        {
            return await Restaurant.DAL.clsUsersDL.
                DeleteUserAsync(UserID);
        }
        public static async Task<Boolean> IsUserExists(int UserID, string Password)
        {
            return await clsUsersDL.IsUserExistAsync(UserID);

        }

        public static async Task<Boolean>IsPasswordExists(int UserID,string Password)
        {
            return await clsUsersDL.IsPasswordExistsAsync(UserID, Password);

        }
        public bool CheckAccessPermission(enPermisstion permisstionRole)
        {
            if (this.Role == -1)
                return true;
            if (((short)permisstionRole & Role) == (short)permisstionRole)
                return true;
            
            return false;
        }

        public async Task<string>GetRoleText()
        {
            return await Restaurant.DAL.clsUsersDL.
                GetRoleUserText(this.UserID);
        }

        public async Task<Boolean>Save()
        {
            switch (_Mode)
            {
                case enMode.eAdd:
                    if (await _AddNewUser())
                        return true;
                    else return false;
                case enMode.eUpdate:
                    if (await _UpdateRoleUser())
                        return true;
                    else return false;

            }
            return false;
        }
    }
}
