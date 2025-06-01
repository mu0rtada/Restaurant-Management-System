using Restaurant.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Restaurant.BLL.clsPersonBL;

namespace Restaurant.BLL
{
    public class clsTestUserBL
    {
        public int? TestUserID { get; set; }
        public string TestUserName { get; set; }
        public string TestPassword { get; set; }
        public int? TestPersonID { get; set; }
        public clsPersonBL TestPersonInfo { get; set; }
        public short? TestRole { get; set; }
        public bool? TestIsActive { get; set; }

        private enum enMode { eAdd = 0, eUpdate = 1 }
        private enMode _Mode = enMode.eAdd;

        private static List<clsTestUserBL> _testUsersList = new List<clsTestUserBL>();
        private static Dictionary<int, clsTestUserBL> _testUsersByID = new Dictionary<int, clsTestUserBL>();
        private static Dictionary<string, clsTestUserBL> _testUsersByUserName =
            new Dictionary<string, clsTestUserBL>(StringComparer.OrdinalIgnoreCase);

        public static async Task LoadTestUsersCacheAsync()
        {
            _testUsersList.Clear();
            _testUsersByID.Clear();
            _testUsersByUserName.Clear();

            DataTable dt = await clsUsersDL.GetUsersActiveAsync();
            foreach (DataRow row in dt.Rows)
            {
                var testUser = new clsTestUserBL(
                    testUserID: row.Field<int?>("UserID"),
                    testUserName: row.Field<string>("UserName"),
                    testPassword: null,
                    testPersonID: row.Field<int?>("PersonID"),
                    testRole: row.Field<short?>("Role"),
                    testIsActive: row.Field<bool?>("IsActive")
                );

                _testUsersList.Add(testUser);

                if (testUser.TestUserID.HasValue)
                    _testUsersByID[testUser.TestUserID.Value] = testUser;
                if (!string.IsNullOrEmpty(testUser.TestUserName))
                    _testUsersByUserName[testUser.TestUserName] = testUser;
            }
        }

        public static List<clsTestUserBL> GetAllTestUsersFromCache() =>
            new List<clsTestUserBL>(_testUsersList);

        public static clsTestUserBL GetTestUserByIDFromCache(int id) =>
            _testUsersByID.TryGetValue(id, out var u) ? u : null;

        public static clsTestUserBL GetTestUserByUserNameFromCache(string username) =>
            _testUsersByUserName.TryGetValue(username, out var u) ? u : null;

        private async Task<bool> _AddNewTestUserAsync()
        {
            this.TestPersonID = await clsUsersDL.AddNewUserAsync(
                this.TestUserName, this.TestPassword, this.TestPersonID, this.TestRole);
            bool ok = this.TestPersonID != null;
            if (ok)
                await LoadTestUsersCacheAsync();
            return ok;
        }

        private async Task<bool> _UpdateTestUserAsync()
        {
            bool ok = await clsUsersDL.UpdateRoleOrPermisstionUserAsync(
                this.TestUserID, this.TestRole);
            if (ok)
            {
                // بدل LoadActiveUsersToCacheAsync()، حدث العنصر فقط:
                if (_Mode == enMode.eAdd)
                    _testUsersList.Add(this); // أو حسب القيمة الجديدة
                else if (_Mode == enMode.eUpdate)
                    _testUsersByID[this.TestUserID.Value] = this;
            }
            return ok;
}

        
       

        public async Task<bool> SaveTestAsync()
        {
            switch (_Mode)
            {
                case enMode.eAdd:
                    if (await _AddNewTestUserAsync())
                        return true;
                    else return false;
                case enMode.eUpdate:
                    if (await _UpdateTestUserAsync())
                        return true;
                    else return false;

            }
            return false;
        }

        public static async Task<bool> DeleteTestUserAsync(int userID)
        {
            bool ok = await clsUsersDL.DeleteUserAsync(userID);
            if (ok)
                await LoadTestUsersCacheAsync();
            return ok;
        }

        public clsTestUserBL() { _Mode = enMode.eAdd; }

        public clsTestUserBL(int? testUserID, string testUserName, string testPassword,
                             int? testPersonID, short? testRole, bool? testIsActive)
        {
            TestUserID = testUserID;
            TestUserName = testUserName;
            TestPassword = testPassword;
            TestPersonID = testPersonID;
            TestRole = testRole;
            TestIsActive = testIsActive;
            _Mode = enMode.eUpdate;
            TestPersonInfo = clsPersonBL.Find(testPersonID);
        }
    }
}
