using Restaurant.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
      
        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }
        public  void FillProgress()
        {
            for(int i=0;i<progressBar1.Maximum;i++)
            {
                progressBar1.Value = (int)i;
                Task.Delay(10);

            }
        }

        private async void btmSAVE_Click(object sender, EventArgs e)
        {

            clsPersonBL Person = new clsPersonBL();
            Person.FirstName = "Murtada";
            Person.LastName = "Al-Janabi";
            Person.Age = 26;
            Person.Gendor = 1;
            Person.AreaID = 2;
            Person.Email = "aso494572@gmail.com";
            Person.PersonType = 1;
            Person.ImagePath = "C:\\Users\\aso49\\OneDrive\\Pictures\\MyPicture.png";

            await Task.WhenAll(Person.Save());
            FillProgress();

        }
    }
}
