namespace Restaurant.UI.Main
{
    partial class ctrl_MenuItemView
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
            this.lblMenuItemID = new System.Windows.Forms.Label();
            this.lblMenuItemName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPriceItem = new System.Windows.Forms.Label();
            this.btnSelect = new Guna.UI.WinForms.GunaButton();
            this.pbMenuItem = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMenuItemID
            // 
            this.lblMenuItemID.AutoSize = true;
            this.lblMenuItemID.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuItemID.ForeColor = System.Drawing.Color.Gray;
            this.lblMenuItemID.Location = new System.Drawing.Point(6, 8);
            this.lblMenuItemID.Name = "lblMenuItemID";
            this.lblMenuItemID.Size = new System.Drawing.Size(28, 21);
            this.lblMenuItemID.TabIndex = 1;
            this.lblMenuItemID.Text = "#1";
            // 
            // lblMenuItemName
            // 
            this.lblMenuItemName.AutoSize = true;
            this.lblMenuItemName.Font = new System.Drawing.Font("Simplified Arabic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuItemName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblMenuItemName.Location = new System.Drawing.Point(3, 38);
            this.lblMenuItemName.Name = "lblMenuItemName";
            this.lblMenuItemName.Size = new System.Drawing.Size(114, 35);
            this.lblMenuItemName.TabIndex = 2;
            this.lblMenuItemName.Text = "Item Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Simplified Arabic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblDescription.Location = new System.Drawing.Point(7, 71);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 20);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // lblPriceItem
            // 
            this.lblPriceItem.AutoSize = true;
            this.lblPriceItem.Font = new System.Drawing.Font("Simplified Arabic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceItem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblPriceItem.Location = new System.Drawing.Point(80, 112);
            this.lblPriceItem.Name = "lblPriceItem";
            this.lblPriceItem.Size = new System.Drawing.Size(69, 35);
            this.lblPriceItem.TabIndex = 4;
            this.lblPriceItem.Text = "9.99$";
            // 
            // btnSelect
            // 
            this.btnSelect.Animated = true;
            this.btnSelect.AnimationHoverSpeed = 0.07F;
            this.btnSelect.AnimationSpeed = 0.03F;
            this.btnSelect.BaseColor = System.Drawing.Color.Transparent;
            this.btnSelect.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelect.BorderSize = 1;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft YaHei", 10.3F, System.Drawing.FontStyle.Bold);
            this.btnSelect.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.Image = null;
            this.btnSelect.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSelect.Location = new System.Drawing.Point(16, 161);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnSelect.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSelect.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSelect.OnHoverImage = null;
            this.btnSelect.OnPressedColor = System.Drawing.Color.Black;
            this.btnSelect.Radius = 10;
            this.btnSelect.Size = new System.Drawing.Size(197, 36);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbMenuItem
            // 
            this.pbMenuItem.BaseColor = System.Drawing.Color.Transparent;
            this.pbMenuItem.Image = global::Restaurant.UI.Properties.Resources.Cake;
            this.pbMenuItem.Location = new System.Drawing.Point(143, 13);
            this.pbMenuItem.Name = "pbMenuItem";
            this.pbMenuItem.Radius = 11;
            this.pbMenuItem.Size = new System.Drawing.Size(75, 75);
            this.pbMenuItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMenuItem.TabIndex = 0;
            this.pbMenuItem.TabStop = false;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 7;
            this.gunaElipse1.TargetControl = this;
            // 
            // ctrl_MenuItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblPriceItem);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblMenuItemName);
            this.Controls.Add(this.lblMenuItemID);
            this.Controls.Add(this.pbMenuItem);
            this.Name = "ctrl_MenuItemView";
            this.Size = new System.Drawing.Size(229, 212);
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox pbMenuItem;
        private System.Windows.Forms.Label lblMenuItemID;
        private System.Windows.Forms.Label lblMenuItemName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPriceItem;
        private Guna.UI.WinForms.GunaButton btnSelect;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}
