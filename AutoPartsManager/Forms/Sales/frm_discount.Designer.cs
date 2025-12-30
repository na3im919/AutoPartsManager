namespace AutoPartsManager.Forms
{
    partial class frm_discount
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lbl_productName;
        private System.Windows.Forms.TextBox txt_product_name;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_discount));
            this.lbl_productName = new System.Windows.Forms.Label();
            this.txt_product_name = new System.Windows.Forms.TextBox();
            this.txt_discount = new System.Windows.Forms.TextBox();
            this.btn_delete_discount = new DevExpress.XtraEditors.SimpleButton();
            this.btn_confirm_discount = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lbl_productName
            // 
            this.lbl_productName.AutoSize = true;
            this.lbl_productName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_productName.Location = new System.Drawing.Point(284, 8);
            this.lbl_productName.Name = "lbl_productName";
            this.lbl_productName.Size = new System.Drawing.Size(89, 29);
            this.lbl_productName.TabIndex = 0;
            this.lbl_productName.Text = "اسم المنتج";
            // 
            // txt_product_name
            // 
            this.txt_product_name.BackColor = System.Drawing.Color.White;
            this.txt_product_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product_name.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product_name.Location = new System.Drawing.Point(1, 40);
            this.txt_product_name.Multiline = true;
            this.txt_product_name.Name = "txt_product_name";
            this.txt_product_name.ReadOnly = true;
            this.txt_product_name.Size = new System.Drawing.Size(372, 55);
            this.txt_product_name.TabIndex = 5;
            // 
            // txt_discount
            // 
            this.txt_discount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_discount.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_discount.Location = new System.Drawing.Point(1, 101);
            this.txt_discount.Multiline = true;
            this.txt_discount.Name = "txt_discount";
            this.txt_discount.Size = new System.Drawing.Size(372, 82);
            this.txt_discount.TabIndex = 1;
            this.txt_discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_discount.Click += new System.EventHandler(this.txt_discount_Click);
            this.txt_discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_discount_KeyPress);
            // 
            // btn_delete_discount
            // 
            this.btn_delete_discount.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(59)))), ((int)(((byte)(31)))));
            this.btn_delete_discount.Appearance.Options.UseBackColor = true;
            this.btn_delete_discount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_delete_discount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete_discount.ImageOptions.Image")));
            this.btn_delete_discount.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_delete_discount.Location = new System.Drawing.Point(0, 281);
            this.btn_delete_discount.Name = "btn_delete_discount";
            this.btn_delete_discount.Size = new System.Drawing.Size(375, 72);
            this.btn_delete_discount.TabIndex = 6;
            this.btn_delete_discount.Click += new System.EventHandler(this.btn_delete_discount_Click_1);
            // 
            // btn_confirm_discount
            // 
            this.btn_confirm_discount.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(86)))), ((int)(((byte)(243)))));
            this.btn_confirm_discount.Appearance.Options.UseBackColor = true;
            this.btn_confirm_discount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_confirm_discount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_confirm_discount.ImageOptions.Image")));
            this.btn_confirm_discount.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_confirm_discount.Location = new System.Drawing.Point(0, 209);
            this.btn_confirm_discount.Name = "btn_confirm_discount";
            this.btn_confirm_discount.Size = new System.Drawing.Size(375, 72);
            this.btn_confirm_discount.TabIndex = 7;
            this.btn_confirm_discount.Click += new System.EventHandler(this.btn_confirm_discount_Click_);
            // 
            // frm_discount
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(375, 353);
            this.Controls.Add(this.btn_confirm_discount);
            this.Controls.Add(this.btn_delete_discount);
            this.Controls.Add(this.txt_discount);
            this.Controls.Add(this.txt_product_name);
            this.Controls.Add(this.lbl_productName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_discount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تطبيق الخصم على المنتج";
            this.Load += new System.EventHandler(this.frm_discount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txt_discount;
        private DevExpress.XtraEditors.SimpleButton btn_delete_discount;
        private DevExpress.XtraEditors.SimpleButton btn_confirm_discount;
    }
}
