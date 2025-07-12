using Restaurant.BLL;
using Restaurant.UI.Main;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Restaurant.UI
{
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            InitializeComponent();
        }
        clsUsersBL Users=new clsUsersBL();

      
        private void frmLogin_Load(object sender, EventArgs e)
        {
           

        }
        public async void FillProgress()
        {

        }

        private   void btmSAVE_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMainResto mainResto = new frmMainResto();
            mainResto.ShowDialog();
        }
    }
}
