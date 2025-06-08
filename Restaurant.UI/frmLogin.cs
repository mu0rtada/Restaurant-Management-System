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

        private  async void btmSAVE_Click(object sender, EventArgs e)
        {
             clsMenuItemsBL menuItemsBL = new clsMenuItemsBL();
           menuItemsBL= clsMenuItemsBL.Find(1);
                menuItemsBL.MenuItemName = "XNXX    ";
            menuItemsBL.Description = "Drink human";
            menuItemsBL.Price = 12;
            menuItemsBL.CategoryID = 1;
            
            if(await menuItemsBL.Save())
                MessageBox.Show("Done");
        }
    }
}
