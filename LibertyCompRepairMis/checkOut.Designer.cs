namespace LibertyCompRepairMis
{
    partial class checkOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(checkOut));
            this.txtid = new MaterialSkin.Controls.MaterialTextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblname = new Bunifu.UI.WinForms.BunifuLabel();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.txtamount = new MaterialSkin.Controls.MaterialTextBox();
            this.bunifuDatePicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.SuspendLayout();
            // 
            // txtid
            // 
            this.txtid.AnimateReadOnly = false;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtid.Depth = 0;
            this.txtid.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtid.Hint = "Cust ID";
            this.txtid.LeadingIcon = null;
            this.txtid.Location = new System.Drawing.Point(12, 26);
            this.txtid.MaxLength = 50;
            this.txtid.MouseState = MaterialSkin.MouseState.OUT;
            this.txtid.Multiline = false;
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(123, 50);
            this.txtid.TabIndex = 0;
            this.txtid.Text = "";
            this.txtid.TrailingIcon = null;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(142, 32);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(64, 36);
            this.materialButton1.TabIndex = 1;
            this.materialButton1.Text = "Find";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.Location = new System.Drawing.Point(251, 47);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(45, 21);
            this.bunifuLabel1.TabIndex = 2;
            this.bunifuLabel1.Text = "Name:";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblname
            // 
            this.lblname.AllowParentOverrides = false;
            this.lblname.AutoEllipsis = false;
            this.lblname.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(251, 74);
            this.lblname.Name = "lblname";
            this.lblname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblname.Size = new System.Drawing.Size(39, 21);
            this.lblname.TabIndex = 3;
            this.lblname.Text = "NULL";
            this.lblname.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblname.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblname.Click += new System.EventHandler(this.bunifuLabel2_Click);
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(82, 163);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(101, 36);
            this.materialButton2.TabIndex = 5;
            this.materialButton2.Text = "check out";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // txtamount
            // 
            this.txtamount.AnimateReadOnly = false;
            this.txtamount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtamount.Depth = 0;
            this.txtamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtamount.Hint = "Amount(KES)";
            this.txtamount.LeadingIcon = null;
            this.txtamount.Location = new System.Drawing.Point(23, 104);
            this.txtamount.MaxLength = 50;
            this.txtamount.MouseState = MaterialSkin.MouseState.OUT;
            this.txtamount.Multiline = false;
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(194, 50);
            this.txtamount.TabIndex = 4;
            this.txtamount.Text = "";
            this.txtamount.TrailingIcon = null;
            // 
            // bunifuDatePicker1
            // 
            this.bunifuDatePicker1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDatePicker1.BorderColor = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.BorderRadius = 1;
            this.bunifuDatePicker1.Color = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.bunifuDatePicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuDatePicker1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.DisplayWeekNumbers = false;
            this.bunifuDatePicker1.DPHeight = 0;
            this.bunifuDatePicker1.FillDatePicker = false;
            this.bunifuDatePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuDatePicker1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker1.Icon")));
            this.bunifuDatePicker1.IconColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuDatePicker1.LeftTextMargin = 5;
            this.bunifuDatePicker1.Location = new System.Drawing.Point(249, 178);
            this.bunifuDatePicker1.MinimumSize = new System.Drawing.Size(0, 32);
            this.bunifuDatePicker1.Name = "bunifuDatePicker1";
            this.bunifuDatePicker1.Size = new System.Drawing.Size(132, 32);
            this.bunifuDatePicker1.TabIndex = 6;
            // 
            // checkOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 222);
            this.Controls.Add(this.bunifuDatePicker1);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.txtid);
            this.MaximizeBox = false;
            this.Name = "checkOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "checkOut";
            this.Load += new System.EventHandler(this.checkOut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtid;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuLabel lblname;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialTextBox txtamount;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuDatePicker1;
    }
}