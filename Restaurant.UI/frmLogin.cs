using Restaurant.BLL;
using System;
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
        public async void FillProgress()
        {
            for(int i=0;i<progressBar1.Maximum;i++)
            {
                progressBar1.Value = (int)i;
              await  Task.Delay(10);

            }
        }

        private  void btmSAVE_Click(object sender, EventArgs e)
        {

            clsPersonBL Person = new clsPersonBL();
            Person.Find(12);


          
            if (string.IsNullOrEmpty(Person.ImagePath))
                label1.Text = "من كبر حتى كبر";
            else
                label1.Text = "عاشت الايادي";
           
            
        }
    }
}
