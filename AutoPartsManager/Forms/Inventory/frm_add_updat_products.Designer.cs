namespace AutoPartsManager.Forms.Inventory
{
    partial class frm_add_updat_products
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_add_updat_products));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_name = new DevExpress.XtraEditors.TextEdit();
            this.txt_reffrence = new DevExpress.XtraEditors.TextEdit();
            this.txt_brand = new DevExpress.XtraEditors.TextEdit();
            this.txt_cost = new DevExpress.XtraEditors.TextEdit();
            this.txt_price = new DevExpress.XtraEditors.TextEdit();
            this.txt_qty = new DevExpress.XtraEditors.TextEdit();
            this.txt_qty_min = new DevExpress.XtraEditors.TextEdit();
            this.lay_ctrl_name = new DevExpress.XtraLayout.LayoutControlItem();
            this.ly_ctrl_refference = new DevExpress.XtraLayout.LayoutControlItem();
            this.lay_ctrl_brand = new DevExpress.XtraLayout.LayoutControlItem();
            this.lay_ctrl_cost = new DevExpress.XtraLayout.LayoutControlItem();
            this.lay_ctrl_price = new DevExpress.XtraLayout.LayoutControlItem();
            this.lay_ctrl_quantity = new DevExpress.XtraLayout.LayoutControlItem();
            this.lay_ctrl_min_quantity = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_reffrence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_brand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_price.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_qty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_qty_min.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ly_ctrl_refference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_brand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_cost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_min_quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_name);
            this.layoutControl1.Controls.Add(this.txt_reffrence);
            this.layoutControl1.Controls.Add(this.txt_brand);
            this.layoutControl1.Controls.Add(this.txt_cost);
            this.layoutControl1.Controls.Add(this.txt_price);
            this.layoutControl1.Controls.Add(this.txt_qty);
            this.layoutControl1.Controls.Add(this.txt_qty_min);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.QuickModeLoadIndicatorSize = new System.Drawing.Size(7, 30);
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(782, 307);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lay_ctrl_name,
            this.ly_ctrl_refference,
            this.lay_ctrl_brand,
            this.lay_ctrl_cost,
            this.lay_ctrl_price,
            this.lay_ctrl_quantity,
            this.lay_ctrl_min_quantity});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(782, 307);
            this.Root.TextVisible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.ImageOptions.Image")));
            this.btn_cancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btn_cancel.Location = new System.Drawing.Point(166, 313);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(90, 65);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.ImageOptions.Image")));
            this.btn_save.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btn_save.Location = new System.Drawing.Point(56, 313);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(90, 65);
            this.btn_save.TabIndex = 1;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(12, 12);
            this.txt_name.Name = "txt_name";
            this.txt_name.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Properties.Appearance.Options.UseFont = true;
            this.txt_name.Size = new System.Drawing.Size(520, 36);
            this.txt_name.StyleController = this.layoutControl1;
            this.txt_name.TabIndex = 4;
            // 
            // txt_reffrence
            // 
            this.txt_reffrence.Location = new System.Drawing.Point(12, 52);
            this.txt_reffrence.Name = "txt_reffrence";
            this.txt_reffrence.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reffrence.Properties.Appearance.Options.UseFont = true;
            this.txt_reffrence.Size = new System.Drawing.Size(520, 36);
            this.txt_reffrence.StyleController = this.layoutControl1;
            this.txt_reffrence.TabIndex = 5;
            // 
            // txt_brand
            // 
            this.txt_brand.Location = new System.Drawing.Point(12, 92);
            this.txt_brand.Name = "txt_brand";
            this.txt_brand.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_brand.Properties.Appearance.Options.UseFont = true;
            this.txt_brand.Size = new System.Drawing.Size(520, 36);
            this.txt_brand.StyleController = this.layoutControl1;
            this.txt_brand.TabIndex = 6;
            // 
            // txt_cost
            // 
            this.txt_cost.Location = new System.Drawing.Point(12, 132);
            this.txt_cost.Name = "txt_cost";
            this.txt_cost.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cost.Properties.Appearance.Options.UseFont = true;
            this.txt_cost.Size = new System.Drawing.Size(520, 36);
            this.txt_cost.StyleController = this.layoutControl1;
            this.txt_cost.TabIndex = 7;
            // 
            // txt_price
            // 
            this.txt_price.Location = new System.Drawing.Point(12, 172);
            this.txt_price.Name = "txt_price";
            this.txt_price.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price.Properties.Appearance.Options.UseFont = true;
            this.txt_price.Size = new System.Drawing.Size(520, 36);
            this.txt_price.StyleController = this.layoutControl1;
            this.txt_price.TabIndex = 8;
            // 
            // txt_qty
            // 
            this.txt_qty.Location = new System.Drawing.Point(12, 212);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qty.Properties.Appearance.Options.UseFont = true;
            this.txt_qty.Size = new System.Drawing.Size(520, 36);
            this.txt_qty.StyleController = this.layoutControl1;
            this.txt_qty.TabIndex = 9;
            // 
            // txt_qty_min
            // 
            this.txt_qty_min.Location = new System.Drawing.Point(12, 252);
            this.txt_qty_min.Name = "txt_qty_min";
            this.txt_qty_min.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qty_min.Properties.Appearance.Options.UseFont = true;
            this.txt_qty_min.Size = new System.Drawing.Size(520, 36);
            this.txt_qty_min.StyleController = this.layoutControl1;
            this.txt_qty_min.TabIndex = 10;
            // 
            // lay_ctrl_name
            // 
            this.lay_ctrl_name.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lay_ctrl_name.AppearanceItemCaption.Options.UseFont = true;
            this.lay_ctrl_name.Control = this.txt_name;
            this.lay_ctrl_name.Location = new System.Drawing.Point(0, 0);
            this.lay_ctrl_name.Name = "lay_ctrl_name";
            this.lay_ctrl_name.Size = new System.Drawing.Size(762, 40);
            this.lay_ctrl_name.Text = "إسم المنتج";
            this.lay_ctrl_name.TextSize = new System.Drawing.Size(226, 29);
            // 
            // ly_ctrl_refference
            // 
            this.ly_ctrl_refference.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ly_ctrl_refference.AppearanceItemCaption.Options.UseFont = true;
            this.ly_ctrl_refference.Control = this.txt_reffrence;
            this.ly_ctrl_refference.Location = new System.Drawing.Point(0, 40);
            this.ly_ctrl_refference.Name = "ly_ctrl_refference";
            this.ly_ctrl_refference.Size = new System.Drawing.Size(762, 40);
            this.ly_ctrl_refference.Text = "كود المنتج";
            this.ly_ctrl_refference.TextSize = new System.Drawing.Size(226, 29);
            // 
            // lay_ctrl_brand
            // 
            this.lay_ctrl_brand.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lay_ctrl_brand.AppearanceItemCaption.Options.UseFont = true;
            this.lay_ctrl_brand.Control = this.txt_brand;
            this.lay_ctrl_brand.Location = new System.Drawing.Point(0, 80);
            this.lay_ctrl_brand.Name = "lay_ctrl_brand";
            this.lay_ctrl_brand.Size = new System.Drawing.Size(762, 40);
            this.lay_ctrl_brand.Text = "العلامة التجارية";
            this.lay_ctrl_brand.TextSize = new System.Drawing.Size(226, 29);
            // 
            // lay_ctrl_cost
            // 
            this.lay_ctrl_cost.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lay_ctrl_cost.AppearanceItemCaption.Options.UseFont = true;
            this.lay_ctrl_cost.Control = this.txt_cost;
            this.lay_ctrl_cost.Location = new System.Drawing.Point(0, 120);
            this.lay_ctrl_cost.Name = "lay_ctrl_cost";
            this.lay_ctrl_cost.Size = new System.Drawing.Size(762, 40);
            this.lay_ctrl_cost.Text = "سعر الشراء";
            this.lay_ctrl_cost.TextSize = new System.Drawing.Size(226, 29);
            // 
            // lay_ctrl_price
            // 
            this.lay_ctrl_price.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lay_ctrl_price.AppearanceItemCaption.Options.UseFont = true;
            this.lay_ctrl_price.Control = this.txt_price;
            this.lay_ctrl_price.Location = new System.Drawing.Point(0, 160);
            this.lay_ctrl_price.Name = "lay_ctrl_price";
            this.lay_ctrl_price.Size = new System.Drawing.Size(762, 40);
            this.lay_ctrl_price.Text = "سعر البيع";
            this.lay_ctrl_price.TextSize = new System.Drawing.Size(226, 29);
            // 
            // lay_ctrl_quantity
            // 
            this.lay_ctrl_quantity.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lay_ctrl_quantity.AppearanceItemCaption.Options.UseFont = true;
            this.lay_ctrl_quantity.Control = this.txt_qty;
            this.lay_ctrl_quantity.Location = new System.Drawing.Point(0, 200);
            this.lay_ctrl_quantity.Name = "lay_ctrl_quantity";
            this.lay_ctrl_quantity.Size = new System.Drawing.Size(762, 40);
            this.lay_ctrl_quantity.Text = "الكمية";
            this.lay_ctrl_quantity.TextSize = new System.Drawing.Size(226, 29);
            // 
            // lay_ctrl_min_quantity
            // 
            this.lay_ctrl_min_quantity.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lay_ctrl_min_quantity.AppearanceItemCaption.Options.UseFont = true;
            this.lay_ctrl_min_quantity.Control = this.txt_qty_min;
            this.lay_ctrl_min_quantity.Location = new System.Drawing.Point(0, 240);
            this.lay_ctrl_min_quantity.Name = "lay_ctrl_min_quantity";
            this.lay_ctrl_min_quantity.Size = new System.Drawing.Size(762, 47);
            this.lay_ctrl_min_quantity.Text = "الحد الأدنى للمخزون";
            this.lay_ctrl_min_quantity.TextSize = new System.Drawing.Size(226, 29);
            // 
            // frm_add_updat_products
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 397);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_add_updat_products";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_add_updat_products";
            this.Load += new System.EventHandler(this.frm_add_updat_products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_reffrence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_brand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_price.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_qty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_qty_min.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ly_ctrl_refference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_brand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_cost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay_ctrl_min_quantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txt_name;
        private DevExpress.XtraEditors.TextEdit txt_reffrence;
        private DevExpress.XtraEditors.TextEdit txt_brand;
        private DevExpress.XtraEditors.TextEdit txt_cost;
        private DevExpress.XtraEditors.TextEdit txt_price;
        private DevExpress.XtraEditors.TextEdit txt_qty;
        private DevExpress.XtraLayout.LayoutControlItem lay_ctrl_name;
        private DevExpress.XtraLayout.LayoutControlItem ly_ctrl_refference;
        private DevExpress.XtraLayout.LayoutControlItem lay_ctrl_brand;
        private DevExpress.XtraLayout.LayoutControlItem lay_ctrl_cost;
        private DevExpress.XtraLayout.LayoutControlItem lay_ctrl_price;
        private DevExpress.XtraLayout.LayoutControlItem lay_ctrl_quantity;
        private DevExpress.XtraEditors.TextEdit txt_qty_min;
        private DevExpress.XtraLayout.LayoutControlItem lay_ctrl_min_quantity;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
    }
}