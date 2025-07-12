namespace Restaurant.UI
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.كلبسة = new Guna.UI.WinForms.GunaElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxUserName = new Guna.UI.WinForms.GunaLineTextBox();
            this.tbxPassword = new Guna.UI.WinForms.GunaLineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new Guna.UI.WinForms.GunaAdvenceButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // كلبسة
            // 
            this.كلبسة.Radius = 14;
            this.كلبسة.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Restaurant.UI.Properties.Resources.COME;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOG IN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Animated = true;
            this.tbxUserName.BackColor = System.Drawing.SystemColors.Control;
            this.tbxUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxUserName.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tbxUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUserName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbxUserName.LineColor = System.Drawing.Color.DimGray;
            this.tbxUserName.LineSize = 1;
            this.tbxUserName.Location = new System.Drawing.Point(26, 226);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.PasswordChar = '\0';
            this.tbxUserName.Size = new System.Drawing.Size(237, 30);
            this.tbxUserName.TabIndex = 4;
            this.tbxUserName.TextOffsetX = 3;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Animated = true;
            this.tbxPassword.BackColor = System.Drawing.SystemColors.Control;
            this.tbxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxPassword.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tbxPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbxPassword.LineColor = System.Drawing.Color.DimGray;
            this.tbxPassword.LineSize = 1;
            this.tbxPassword.Location = new System.Drawing.Point(26, 286);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '●';
            this.tbxPassword.Size = new System.Drawing.Size(237, 30);
            this.tbxPassword.TabIndex = 6;
            this.tbxPassword.TextOffsetX = 3;
            this.tbxPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.AnimationHoverSpeed = 0.07F;
            this.btnLogin.AnimationSpeed = 0.03F;
            this.btnLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnLogin.BorderColor = System.Drawing.Color.Black;
            this.btnLogin.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnLogin.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnLogin.CheckedForeColor = System.Drawing.Color.White;
            this.btnLogin.CheckedImage = null;
            this.btnLogin.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = null;
            this.btnLogin.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLogin.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnLogin.Location = new System.Drawing.Point(102, 328);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnLogin.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLogin.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLogin.OnHoverImage = null;
            this.btnLogin.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnLogin.OnPressedColor = System.Drawing.Color.Black;
            this.btnLogin.Radius = 11;
            this.btnLogin.Size = new System.Drawing.Size(88, 36);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "LOG IN";
            this.btnLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 372);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse كلبسة;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaLineTextBox tbxUserName;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaLineTextBox tbxPassword;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaAdvenceButton btnLogin;
    }
}