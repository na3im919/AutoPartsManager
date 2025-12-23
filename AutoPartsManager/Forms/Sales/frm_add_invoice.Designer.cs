namespace AutoPartsManager.Forms.Sales
{
    partial class frm_add_invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_add_invoice));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_total = new DevExpress.XtraEditors.TextEdit();
            this.txt_discount = new DevExpress.XtraEditors.TextEdit();
            this.txt_net_amount = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lbl_total = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbl_discount = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbl_net = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_add_invoice = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.chk_cash_or_not = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cmb_client_name = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_total.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_discount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_net_amount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_discount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_net)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_cash_or_not.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_client_name.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_total);
            this.layoutControl1.Controls.Add(this.txt_discount);
            this.layoutControl1.Controls.Add(this.txt_net_amount);
            this.layoutControl1.Controls.Add(this.chk_cash_or_not);
            this.layoutControl1.Controls.Add(this.cmb_client_name);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1050, 247);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_total
            // 
            this.txt_total.Location = new System.Drawing.Point(12, 12);
            this.txt_total.Name = "txt_total";
            this.txt_total.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.Properties.Appearance.Options.UseFont = true;
            this.txt_total.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_total.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_total.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txt_total.Size = new System.Drawing.Size(809, 40);
            this.txt_total.StyleController = this.layoutControl1;
            this.txt_total.TabIndex = 4;
            // 
            // txt_discount
            // 
            this.txt_discount.Location = new System.Drawing.Point(12, 56);
            this.txt_discount.Name = "txt_discount";
            this.txt_discount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_discount.Properties.Appearance.Options.UseFont = true;
            this.txt_discount.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_discount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_discount.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txt_discount.Size = new System.Drawing.Size(809, 40);
            this.txt_discount.StyleController = this.layoutControl1;
            this.txt_discount.TabIndex = 5;
            // 
            // txt_net_amount
            // 
            this.txt_net_amount.Location = new System.Drawing.Point(12, 100);
            this.txt_net_amount.Name = "txt_net_amount";
            this.txt_net_amount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_net_amount.Properties.Appearance.Options.UseFont = true;
            this.txt_net_amount.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_net_amount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_net_amount.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txt_net_amount.Size = new System.Drawing.Size(809, 40);
            this.txt_net_amount.StyleController = this.layoutControl1;
            this.txt_net_amount.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lbl_total,
            this.lbl_discount,
            this.lbl_net,
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1050, 247);
            this.Root.TextVisible = false;
            // 
            // lbl_total
            // 
            this.lbl_total.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.AppearanceItemCaption.Options.UseFont = true;
            this.lbl_total.Control = this.txt_total;
            this.lbl_total.Location = new System.Drawing.Point(0, 0);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(1030, 44);
            this.lbl_total.Text = "المبلغ الإجمالي";
            this.lbl_total.TextLocation = DevExpress.Utils.Locations.Right;
            this.lbl_total.TextSize = new System.Drawing.Size(205, 34);
            // 
            // lbl_discount
            // 
            this.lbl_discount.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_discount.AppearanceItemCaption.Options.UseFont = true;
            this.lbl_discount.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lbl_discount.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbl_discount.Control = this.txt_discount;
            this.lbl_discount.Location = new System.Drawing.Point(0, 44);
            this.lbl_discount.Name = "lbl_discount";
            this.lbl_discount.Size = new System.Drawing.Size(1030, 44);
            this.lbl_discount.Text = "الخصم";
            this.lbl_discount.TextLocation = DevExpress.Utils.Locations.Right;
            this.lbl_discount.TextSize = new System.Drawing.Size(205, 34);
            // 
            // lbl_net
            // 
            this.lbl_net.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_net.AppearanceItemCaption.Options.UseFont = true;
            this.lbl_net.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lbl_net.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbl_net.Control = this.txt_net_amount;
            this.lbl_net.Location = new System.Drawing.Point(0, 88);
            this.lbl_net.Name = "lbl_net";
            this.lbl_net.Size = new System.Drawing.Size(1030, 44);
            this.lbl_net.Text = "المبلغ الصافي";
            this.lbl_net.TextLocation = DevExpress.Utils.Locations.Right;
            this.lbl_net.TextSize = new System.Drawing.Size(205, 34);
            // 
            // btn_add_invoice
            // 
            this.btn_add_invoice.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(138)))), ((int)(((byte)(71)))));
            this.btn_add_invoice.Appearance.Options.UseBackColor = true;
            this.btn_add_invoice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_invoice.ImageOptions.Image")));
            this.btn_add_invoice.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_add_invoice.Location = new System.Drawing.Point(71, 338);
            this.btn_add_invoice.Name = "btn_add_invoice";
            this.btn_add_invoice.Size = new System.Drawing.Size(185, 87);
            this.btn_add_invoice.TabIndex = 1;
            this.btn_add_invoice.Click += new System.EventHandler(this.btn_add_invoice_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btn_cancel.Appearance.Options.UseBackColor = true;
            this.btn_cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.ImageOptions.Image")));
            this.btn_cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(279, 338);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(185, 87);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // chk_cash_or_not
            // 
            this.chk_cash_or_not.Location = new System.Drawing.Point(12, 188);
            this.chk_cash_or_not.Name = "chk_cash_or_not";
            this.chk_cash_or_not.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_cash_or_not.Properties.Appearance.Options.UseFont = true;
            this.chk_cash_or_not.Properties.Caption = "دفع مؤجل؟";
            this.chk_cash_or_not.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_cash_or_not.Size = new System.Drawing.Size(1026, 33);
            this.chk_cash_or_not.StyleController = this.layoutControl1;
            this.chk_cash_or_not.TabIndex = 9;
            this.chk_cash_or_not.CheckedChanged += new System.EventHandler(this.chk_cash_or_not_CheckedChanged);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chk_cash_or_not;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 176);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1030, 51);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.cmb_client_name;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 132);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1030, 44);
            this.layoutControlItem2.Text = "إسم الزبون";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Right;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(205, 34);
            // 
            // cmb_client_name
            // 
            this.cmb_client_name.Location = new System.Drawing.Point(12, 144);
            this.cmb_client_name.Name = "cmb_client_name";
            this.cmb_client_name.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_client_name.Properties.Appearance.Options.UseFont = true;
            this.cmb_client_name.Properties.Appearance.Options.UseTextOptions = true;
            this.cmb_client_name.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmb_client_name.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_client_name.Size = new System.Drawing.Size(809, 40);
            this.cmb_client_name.StyleController = this.layoutControl1;
            this.cmb_client_name.TabIndex = 8;
            // 
            // frm_add_invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 488);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add_invoice);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_add_invoice";
            this.Text = "frm_add_invoice";
            this.Load += new System.EventHandler(this.frm_add_invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_total.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_discount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_net_amount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_discount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_net)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_cash_or_not.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_client_name.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txt_total;
        private DevExpress.XtraEditors.TextEdit txt_discount;
        private DevExpress.XtraEditors.TextEdit txt_net_amount;
        private DevExpress.XtraLayout.LayoutControlItem lbl_total;
        private DevExpress.XtraLayout.LayoutControlItem lbl_discount;
        private DevExpress.XtraLayout.LayoutControlItem lbl_net;
        private DevExpress.XtraEditors.SimpleButton btn_add_invoice;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
        private DevExpress.XtraEditors.CheckEdit chk_cash_or_not;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_client_name;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}