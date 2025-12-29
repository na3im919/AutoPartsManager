namespace AutoPartsManager.Forms
{
    partial class frm_discount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_discount));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_confirm_discount = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel_discount = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 77);
            this.panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(113, 137);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 109);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btn_confirm_discount
            // 
            this.btn_confirm_discount.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.btn_confirm_discount.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm_discount.Appearance.Options.UseBackColor = true;
            this.btn_confirm_discount.Appearance.Options.UseFont = true;
            this.btn_confirm_discount.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm_discount.AppearanceHovered.Options.UseFont = true;
            this.btn_confirm_discount.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm_discount.AppearancePressed.Options.UseFont = true;
            this.btn_confirm_discount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_confirm_discount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_confirm_discount.ImageOptions.Image")));
            this.btn_confirm_discount.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btn_confirm_discount.Location = new System.Drawing.Point(0, 262);
            this.btn_confirm_discount.Name = "btn_confirm_discount";
            this.btn_confirm_discount.Size = new System.Drawing.Size(450, 137);
            this.btn_confirm_discount.TabIndex = 1;
            this.btn_confirm_discount.Text = "خصم";
            this.btn_confirm_discount.Click += new System.EventHandler(this.btn_confirm_discount_Click);
            // 
            // btn_cancel_discount
            // 
            this.btn_cancel_discount.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btn_cancel_discount.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel_discount.Appearance.Options.UseBackColor = true;
            this.btn_cancel_discount.Appearance.Options.UseFont = true;
            this.btn_cancel_discount.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel_discount.AppearanceHovered.Options.UseFont = true;
            this.btn_cancel_discount.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel_discount.AppearancePressed.Options.UseFont = true;
            this.btn_cancel_discount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_cancel_discount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel_discount.ImageOptions.Image")));
            this.btn_cancel_discount.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btn_cancel_discount.Location = new System.Drawing.Point(0, 399);
            this.btn_cancel_discount.Name = "btn_cancel_discount";
            this.btn_cancel_discount.Size = new System.Drawing.Size(450, 137);
            this.btn_cancel_discount.TabIndex = 0;
            this.btn_cancel_discount.Text = "إزالة الخصم";
            this.btn_cancel_discount.Click += new System.EventHandler(this.btn_cancel_discount_Click);
            // 
            // frm_discount
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 536);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_confirm_discount);
            this.Controls.Add(this.btn_cancel_discount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_discount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_discount";
            this.Shown += new System.EventHandler(this.frm_discount_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_cancel_discount;
        private DevExpress.XtraEditors.SimpleButton btn_confirm_discount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
    }
}