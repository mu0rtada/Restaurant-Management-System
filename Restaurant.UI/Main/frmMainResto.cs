using Guna.UI.WinForms;
using System;
using System.Drawing;

using System.Windows.Forms;

namespace Restaurant.UI.Main
{
    public partial class frmMainResto : Form
    {
        public frmMainResto()
        {
            InitializeComponent();
        }

        

        private void frmMainResto_Load(object sender, EventArgs e)
        {
            StartupFeature();
            //Hello
            dgvRecentOrder.Rows.Add(1, "Murtada", 2343, DateTime.Now.ToShortDateString());
            dgvRecentOrder.Rows.Add(2, "Abbas", 536, DateTime.Now.ToShortDateString());
            dgvRecentOrder.Rows.Add(3, "Saif", 536, DateTime.Now.ToShortDateString());

        }

       

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?",
                "Log out", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Hide();
                frmLogin AginLogin = new frmLogin();
                AginLogin.ShowDialog();
            }
           

            
        }
        private void StartupFeature()
        {
            lblTime.Text =  DateTime.Now.ToShortTimeString();
            tbHome.Appearance = TabAppearance.FlatButtons;
            tbHome.ItemSize = new Size(0, 1);
            tbHome.SizeMode = TabSizeMode.Fixed;
            label1.Text= "矃";
        }

       

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            tbHome.SelectedIndex = 10;
            btnHome.Checked = true;
        }

        private void Btns_Click(object sender, EventArgs e)
        {
            var BtnPanels = sender as GunaAdvenceButton;
            if(BtnPanels?.TabIndex is int TabNumber)
                tbHome.SelectedIndex=TabNumber;
            
        }
    }
}
