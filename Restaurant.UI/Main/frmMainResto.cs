using Guna.UI.WinForms;
using Restaurant.BLL;
using System;
using System.Drawing;
using System.Threading.Tasks;
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

            //Raises the System.Windows.Forms.Control.HandleDestroyed event.
            lblTime.Text = DateTime.Now.ToShortTimeString();
            tbHome.Appearance = TabAppearance.FlatButtons;
            tbHome.ItemSize = new Size(0, 1);
            tbHome.SizeMode = TabSizeMode.Fixed;
            label1.Text = "矃";
        }



        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            tbHome.SelectedIndex = 10;
            btnHome.Checked = true;
        }
        public void RemoveContolsInsideFlowTables()
        {

            foreach (UserControl Insided in flPnlTables.Controls)
            {
                flPnlTables.Controls.Remove(Insided);
            }

        }

        private void Btns_Click(object sender, EventArgs e)
        {
            var BtnPanels = sender as GunaAdvenceButton;
            if (BtnPanels?.TabIndex is int TabNumber)
                tbHome.SelectedIndex = TabNumber;

            switch (BtnPanels.Name)
            {
                case "btnTables":
                    RemoveContolsInsideFlowTables();
                    break;
            }


        }

        private void OnOrdersClick(object sender, EventArgs e)
        {
            GunaAdvenceButton BtnOrderAdd_Edit_remove = sender as GunaAdvenceButton;
            switch (BtnOrderAdd_Edit_remove.Name)
            {

                case "btnAddItemOrder":
                    //Add Order here
                    dgvRecentOrder.Rows.Add(1 + 1, "Murtada", 2343, DateTime.Now.ToShortDateString());
                    MessageBox.Show("click from:" + BtnOrderAdd_Edit_remove.Name);
                    break;
                case "btnEditItemOrder":
                    MessageBox.Show("click from:" + BtnOrderAdd_Edit_remove.Name);
                    //Edit order here
                    break;
                case "btnRemoveOrder":
                    MessageBox.Show("click from:" + BtnOrderAdd_Edit_remove.Name);
                    Task.FromResult(clsOrdersBL.IsOrderPaid(2));
                    break;


            }
        }

        private void tbHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl TbCtrl = sender as TabControl;

            if (TbCtrl != null)
            {
                // عندما تخرج من التاب، نقوم بإيقاف الـ Controls أو إخفائها
                if (TbCtrl.SelectedIndex > 0)
                {
                    TabPage previousTab = TbCtrl.TabPages[TbCtrl.SelectedIndex - 1];
                    foreach (Control control in previousTab.Controls)
                    {
                        control.Enabled = false; // تعطيل التفاعل مع الـ Controls
                        control.Visible = false; // إخفاء الـ Controls
                    }
                }

                // عندما تعود إلى التاب، نقوم بإرجاع الـ Controls كما كانت
                TabPage currentTab = TbCtrl.SelectedTab;
                if (currentTab != null)
                {
                    foreach (Control control in currentTab.Controls)
                    {
                        control.Enabled = true; // تمكين التفاعل مع الـ Controls
                        control.Visible = true; // إظهار الـ Controls
                    }
                }
            
            }
            
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
        
    
