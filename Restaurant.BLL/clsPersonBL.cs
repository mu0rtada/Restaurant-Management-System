using Restaurant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public class clsPersonBL
    {
        public int? PersonID { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public int? Age {  get; set; }
        public byte? Gendor { get; set; } = 0;
        public int? AreaID { get; set; }
        public string Email { get; set; }
        public clsAreasBL AreaInfo { get; set; }
       public byte? PersonType { get; set; }
       public string ImagePath { get; set; }

        public enum enModeEdit
        {
            AddPerson=0,
            UpdatePerson=1
        }
        private enModeEdit _Mode=enModeEdit.AddPerson;

       public enum _enPersonType
        {
            Admin=0,
            Customer=1,
        }
        public _enPersonType enPersonType
        {
            get
            {
                return this.PersonType == 0 ? _enPersonType.Admin : _enPersonType.Customer;
            }
           
        }

        


        public clsPersonBL()
        {
            PersonID = null;
            FirstName = null;
            LastName = null;
            Age = 0;
            Gendor = 0;
            AreaID = 0;
            Email = null;
            PersonType = null;
            ImagePath = null;
            _Mode = enModeEdit.AddPerson;
        }

        public clsPersonBL(int? personID, string firstName,
            string lastName, int? age, byte? gendor,
            int? areaID,string Email, byte? personType, string imagePath)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Gendor = gendor;
            this.AreaID = areaID;
            this.Email = Email;
            this.PersonType = personType;
            this.ImagePath = imagePath;
          this.AreaInfo= clsAreasBL.FindAreaByID(areaID);
           _Mode=enModeEdit.UpdatePerson;
          
        }

        private async Task<bool> _AddNewPerson()
        {
            this.PersonID =await clsPeopleDL.AddNewPerson(this.FirstName, this.LastName,
                this.Age, this.Gendor, this.AreaID,this.Email,
                this.PersonType, this.ImagePath)??null;
           return PersonID != null;
        }
        private async Task<bool> _UpdatePerson()
        {
            return await clsPeopleDL.UpdatePerson(this.PersonID,
                this.FirstName, this.LastName, this.AreaID,
                this.PersonType, this.ImagePath);
        }
        public static async Task<bool>DeletePerson(int PersonID)
        {
            return await clsPeopleDL.DeletePerson(PersonID);
        }
        public static async Task<bool>IsPersonExist(int PersonID)
        {
            return await clsPeopleDL.IsPersonExists(PersonID);
        }
        /// <summary>
        /// Find By PersonID
        /// </summary>
       
        public   clsPersonBL Find(int?PersonID)
        {
            string FirstName = null;
            string LastName = null;
            int? Age=null;
            byte ? Gendor=null;
            int? AreaID=null;
            string Email=null;
            byte? PersonType=null;
            string ImagePath=null;


            bool ISFound = clsPeopleDL.
                GetPersonInfoByID(PersonID,
                ref FirstName,ref LastName,ref Age,
                ref Gendor,ref AreaID,ref Email,
                ref PersonType,ref ImagePath);

            if (ISFound)
                return new clsPersonBL(PersonID, FirstName, LastName,
                    Age,Gendor,AreaID,Email,PersonType,
                    ImagePath);
            else
                return null;
        }
       /// <summary>
       /// Find By <paramref name="FullName"/> Person
       /// </summary>


        public clsPersonBL Find(string FirstName)
        {
            int? PersonID = null;
            string LastName = null;
            int? Age = null;
            byte? Gendor = null;
            int? AreaID = null;
            string Email = null;
            byte? PersonType = null;
            string ImagePath = null;

            bool ISFound = clsPeopleDL.GetPersonInfoByName(FirstName,
                ref PersonID, ref LastName, ref Age,
                ref Gendor, ref AreaID, ref Email,
                ref PersonType, ref ImagePath);

            if (ISFound)
                return new clsPersonBL(PersonID, FirstName, LastName,
                                   Age, Gendor, AreaID, Email, PersonType,
                                   ImagePath);
            else
                return null;
        }
        /// <summary>
        /// Find By person type
        /// </summary>
        /// <param name="PersonType"></param>
        /// <returns></returns>
        public clsPersonBL FindEmail(string Email)
        {
            int? PersonID = null;
            string FirstName = null;
            string LastName = null;
            int? Age = null;
            byte? Gendor = null;
            int? AreaID = null;
            string ImagePath = null;
            byte? PersonType = null;
            bool ISFound = clsPeopleDL.GetPersonInfoByEmail
                (Email,ref PersonID,ref FirstName,
                ref LastName, ref Age,
                ref Gendor, ref AreaID,
                ref PersonType, ref ImagePath);

            if (ISFound)
                return new clsPersonBL(PersonID, FirstName, LastName,
                                   Age, Gendor, AreaID, Email, PersonType,
                                   ImagePath);
            else
                return null;
        }

        public bool CheckAccessType(_enPersonType PersonTyp)
        {
            if (this.PersonType == 0)
                return true;
            if (((byte)PersonTyp & this.PersonType) == (short)PersonTyp)
                return true ;

            return false;
        }
       
        public  async Task<Boolean> Save()
        {
            switch(_Mode)
            {
                case enModeEdit.AddPerson:
                    if (await _AddNewPerson())

                        return true;
                    else
                        return false;
                   
                   
                   case enModeEdit.UpdatePerson:
                    if (await _UpdatePerson())
                        return true;
                    break;
            }
            return false;
        }

       
    }
}
