namespace AutoPartsManager.Forms
{
    partial class frm_discount
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lbl_productName;
        private System.Windows.Forms.TextBox txt_product_name;
        private System.Windows.Forms.Button btn_confirm_discount;
        private System.Windows.Forms.Button btn_delete_discount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lbl_productName = new System.Windows.Forms.Label();
            this.txt_product_name = new System.Windows.Forms.TextBox();
            this.btn_confirm_discount = new System.Windows.Forms.Button();
            this.btn_delete_discount = new System.Windows.Forms.Button();
            this.txt_discount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_productName
            // 
            this.lbl_productName.AutoSize = true;
            this.lbl_productName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbl_productName.Location = new System.Drawing.Point(254, 5);
            this.lbl_productName.Name = "lbl_productName";
            this.lbl_productName.Size = new System.Drawing.Size(119, 32);
            this.lbl_productName.TabIndex = 0;
            this.lbl_productName.Text = "اسم المنتج";
            // 
            // txt_product_name
            // 
            this.txt_product_name.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_product_name.Location = new System.Drawing.Point(16, 40);
            this.txt_product_name.Name = "txt_product_name";
            this.txt_product_name.Size = new System.Drawing.Size(357, 39);
            this.txt_product_name.TabIndex = 1;
            // 
            // btn_confirm_discount
            // 
            this.btn_confirm_discount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btn_confirm_discount.Location = new System.Drawing.Point(48, 245);
            this.btn_confirm_discount.Name = "btn_confirm_discount";
            this.btn_confirm_discount.Size = new System.Drawing.Size(130, 82);
            this.btn_confirm_discount.TabIndex = 2;
            this.btn_confirm_discount.Text = "تأكيد";
            this.btn_confirm_discount.UseVisualStyleBackColor = true;
            this.btn_confirm_discount.Click += new System.EventHandler(this.btn_confirm_discount_Click);
            // 
            // btn_delete_discount
            // 
            this.btn_delete_discount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btn_delete_discount.Location = new System.Drawing.Point(184, 245);
            this.btn_delete_discount.Name = "btn_delete_discount";
            this.btn_delete_discount.Size = new System.Drawing.Size(130, 82);
            this.btn_delete_discount.TabIndex = 3;
            this.btn_delete_discount.Text = "حذف الخصم";
            this.btn_delete_discount.UseVisualStyleBackColor = true;
            this.btn_delete_discount.Click += new System.EventHandler(this.btn_delete_discount_Click);
            // 
            // txt_discount
            // 
            this.txt_discount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_discount.Location = new System.Drawing.Point(85, 111);
            this.txt_discount.Multiline = true;
            this.txt_discount.Name = "txt_discount";
            this.txt_discount.Size = new System.Drawing.Size(204, 82);
            this.txt_discount.TabIndex = 4;
            this.txt_discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_discount.Click += new System.EventHandler(this.txt_discount_Click);
            this.txt_discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_discount_KeyPress);
            // 
            // frm_discount
            // 
            this.ClientSize = new System.Drawing.Size(375, 353);
            this.Controls.Add(this.txt_discount);
            this.Controls.Add(this.btn_delete_discount);
            this.Controls.Add(this.btn_confirm_discount);
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
    }
}
