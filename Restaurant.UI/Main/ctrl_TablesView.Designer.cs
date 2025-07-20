namespace Restaurant.UI.Main
{
    partial class ctrl_TablesView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTableName = new System.Windows.Forms.Label();
            this.gunaElipsePanel1 = new Guna.UI.WinForms.GunaElipsePanel();
            this.lblStatusTable = new System.Windows.Forms.Label();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblCapCityNum = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetResevedOrFree = new Guna.UI.WinForms.GunaButton();
            this.gunaElipsePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold);
            this.lblTableName.Location = new System.Drawing.Point(37, 9);
            this.lblTableName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(95, 28);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Table 1";
            // 
            // gunaElipsePanel1
            // 
            this.gunaElipsePanel1.BaseColor = System.Drawing.Color.MediumSeaGreen;
            this.gunaElipsePanel1.Controls.Add(this.lblStatusTable);
            this.gunaElipsePanel1.Location = new System.Drawing.Point(19, 40);
            this.gunaElipsePanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gunaElipsePanel1.Name = "gunaElipsePanel1";
            this.gunaElipsePanel1.Radius = 10;
            this.gunaElipsePanel1.Size = new System.Drawing.Size(130, 32);
            this.gunaElipsePanel1.TabIndex = 1;
            // 
            // lblStatusTable
            // 
            this.lblStatusTable.AutoSize = true;
            this.lblStatusTable.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusTable.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusTable.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatusTable.Location = new System.Drawing.Point(14, 2);
            this.lblStatusTable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusTable.Name = "lblStatusTable";
            this.lblStatusTable.Size = new System.Drawing.Size(102, 27);
            this.lblStatusTable.TabIndex = 1;
            this.lblStatusTable.Text = "Available";
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 7;
            this.gunaElipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(14, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Capcity :";
            // 
            // lblCapCityNum
            // 
            this.lblCapCityNum.AutoSize = true;
            this.lblCapCityNum.BackColor = System.Drawing.Color.Transparent;
            this.lblCapCityNum.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold);
            this.lblCapCityNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCapCityNum.Location = new System.Drawing.Point(76, 129);
            this.lblCapCityNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCapCityNum.Name = "lblCapCityNum";
            this.lblCapCityNum.Size = new System.Drawing.Size(18, 19);
            this.lblCapCityNum.TabIndex = 3;
            this.lblCapCityNum.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Restaurant.UI.Properties.Resources.chair;
            this.pictureBox1.Location = new System.Drawing.Point(16, 75);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(102, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(100, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Table A";
            // 
            // btnSetResevedOrFree
            // 
            this.btnSetResevedOrFree.Animated = true;
            this.btnSetResevedOrFree.AnimationHoverSpeed = 0.07F;
            this.btnSetResevedOrFree.AnimationSpeed = 0.03F;
            this.btnSetResevedOrFree.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnSetResevedOrFree.BorderColor = System.Drawing.Color.Black;
            this.btnSetResevedOrFree.Font = new System.Drawing.Font("Microsoft YaHei", 9.3F, System.Drawing.FontStyle.Bold);
            this.btnSetResevedOrFree.ForeColor = System.Drawing.Color.White;
            this.btnSetResevedOrFree.Image = null;
            this.btnSetResevedOrFree.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSetResevedOrFree.Location = new System.Drawing.Point(98, 124);
            this.btnSetResevedOrFree.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSetResevedOrFree.Name = "btnSetResevedOrFree";
            this.btnSetResevedOrFree.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnSetResevedOrFree.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSetResevedOrFree.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSetResevedOrFree.OnHoverImage = null;
            this.btnSetResevedOrFree.OnPressedColor = System.Drawing.Color.Black;
            this.btnSetResevedOrFree.Radius = 10;
            this.btnSetResevedOrFree.Size = new System.Drawing.Size(65, 27);
            this.btnSetResevedOrFree.TabIndex = 7;
            this.btnSetResevedOrFree.Text = "Set Free";
            this.btnSetResevedOrFree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctrl_TablesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.btnSetResevedOrFree);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCapCityNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gunaElipsePanel1);
            this.Controls.Add(this.lblTableName);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ctrl_TablesView";
            this.Size = new System.Drawing.Size(169, 160);
            this.gunaElipsePanel1.ResumeLayout(false);
            this.gunaElipsePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTableName;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private System.Windows.Forms.Label lblStatusTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCapCityNum;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaButton btnSetResevedOrFree;
    }
}
