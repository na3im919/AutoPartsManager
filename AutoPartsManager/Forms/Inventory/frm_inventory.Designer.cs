namespace AutoPartsManager.Forms.Inventory
{
    partial class frm_inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_inventory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_recomended = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_import_excel = new DevExpress.XtraEditors.SimpleButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chk_non_active_product = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_non_zero = new System.Windows.Forms.RadioButton();
            this.rad_zero = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_add_new_product = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbl_products_number = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnl_bottm = new System.Windows.Forms.Panel();
            this.pnl_total_cost = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbl_total_cost = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pnl_cost_title = new System.Windows.Forms.Label();
            this.pnl_total_price = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lbl_total_price = new System.Windows.Forms.Label();
            this.pnl_price_title = new System.Windows.Forms.Panel();
            this.lbl_price_title = new System.Windows.Forms.Label();
            this.dgv_inventory = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.Restore = new System.Windows.Forms.DataGridViewImageColumn();
            this.Recomendation = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel12 = new System.Windows.Forms.Panel();
            this.chk_low_quantity = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).BeginInit();
            this.pnl_bottm.SuspendLayout();
            this.pnl_total_cost.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.pnl_total_price.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnl_price_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventory)).BeginInit();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel12);
            this.panelControl1.Controls.Add(this.panel5);
            this.panelControl1.Controls.Add(this.panel4);
            this.panelControl1.Controls.Add(this.panel6);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1798, 88);
            this.panelControl1.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_recomended);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1197, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 84);
            this.panel5.TabIndex = 15;
            // 
            // btn_recomended
            // 
            this.btn_recomended.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.btn_recomended.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_recomended.Appearance.Options.UseBackColor = true;
            this.btn_recomended.Appearance.Options.UseFont = true;
            this.btn_recomended.Appearance.Options.UseTextOptions = true;
            this.btn_recomended.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btn_recomended.AppearancePressed.Options.UseBackColor = true;
            this.btn_recomended.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_recomended.ImageOptions.Image")));
            this.btn_recomended.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_recomended.Location = new System.Drawing.Point(18, 10);
            this.btn_recomended.Name = "btn_recomended";
            this.btn_recomended.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_recomended.Size = new System.Drawing.Size(166, 66);
            this.btn_recomended.TabIndex = 4;
            this.btn_recomended.Text = "توصيات";
            this.btn_recomended.Click += new System.EventHandler(this.btn_recomended_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_import_excel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1397, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 84);
            this.panel4.TabIndex = 14;
            // 
            // btn_import_excel
            // 
            this.btn_import_excel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.btn_import_excel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_import_excel.Appearance.Options.UseBackColor = true;
            this.btn_import_excel.Appearance.Options.UseFont = true;
            this.btn_import_excel.AppearancePressed.Options.UseBackColor = true;
            this.btn_import_excel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_import_excel.ImageOptions.Image")));
            this.btn_import_excel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_import_excel.Location = new System.Drawing.Point(6, 9);
            this.btn_import_excel.Name = "btn_import_excel";
            this.btn_import_excel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_import_excel.Size = new System.Drawing.Size(202, 66);
            this.btn_import_excel.TabIndex = 4;
            this.btn_import_excel.Text = "إستيراد EXCEL";
            this.btn_import_excel.Click += new System.EventHandler(this.btn_import_excel_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.chk_non_active_product);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(434, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(238, 84);
            this.panel6.TabIndex = 13;
            // 
            // chk_non_active_product
            // 
            this.chk_non_active_product.AutoSize = true;
            this.chk_non_active_product.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_non_active_product.Location = new System.Drawing.Point(10, 20);
            this.chk_non_active_product.Name = "chk_non_active_product";
            this.chk_non_active_product.Size = new System.Drawing.Size(214, 33);
            this.chk_non_active_product.TabIndex = 0;
            this.chk_non_active_product.Text = "منتجات محذوفة";
            this.chk_non_active_product.UseVisualStyleBackColor = true;
            this.chk_non_active_product.CheckedChanged += new System.EventHandler(this.chk_non_active_product_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_non_zero);
            this.groupBox1.Controls.Add(this.rad_zero);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 84);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // rad_non_zero
            // 
            this.rad_non_zero.AutoSize = true;
            this.rad_non_zero.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_non_zero.Location = new System.Drawing.Point(209, 19);
            this.rad_non_zero.Name = "rad_non_zero";
            this.rad_non_zero.Size = new System.Drawing.Size(215, 33);
            this.rad_non_zero.TabIndex = 1;
            this.rad_non_zero.TabStop = true;
            this.rad_non_zero.Text = "كمية غير صفرية";
            this.rad_non_zero.UseVisualStyleBackColor = true;
            // 
            // rad_zero
            // 
            this.rad_zero.AutoSize = true;
            this.rad_zero.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_zero.Location = new System.Drawing.Point(10, 19);
            this.rad_zero.Name = "rad_zero";
            this.rad_zero.Size = new System.Drawing.Size(171, 33);
            this.rad_zero.TabIndex = 0;
            this.rad_zero.TabStop = true;
            this.rad_zero.Text = "كمية صفرية";
            this.rad_zero.UseVisualStyleBackColor = true;
            this.rad_zero.CheckedChanged += new System.EventHandler(this.rad_zero_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_add_new_product);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1604, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 84);
            this.panel2.TabIndex = 6;
            // 
            // btn_add_new_product
            // 
            this.btn_add_new_product.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_add_new_product.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_new_product.Appearance.Options.UseBackColor = true;
            this.btn_add_new_product.Appearance.Options.UseFont = true;
            this.btn_add_new_product.AppearancePressed.Options.UseBackColor = true;
            this.btn_add_new_product.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_new_product.ImageOptions.Image")));
            this.btn_add_new_product.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btn_add_new_product.Location = new System.Drawing.Point(6, 10);
            this.btn_add_new_product.Name = "btn_add_new_product";
            this.btn_add_new_product.Size = new System.Drawing.Size(181, 66);
            this.btn_add_new_product.TabIndex = 4;
            this.btn_add_new_product.Text = "إضافة منتج";
            this.btn_add_new_product.Click += new System.EventHandler(this.btn_add_new_product_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1798, 39);
            this.panel1.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lbl_products_number);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(1521, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(155, 37);
            this.panel8.TabIndex = 9;
            // 
            // lbl_products_number
            // 
            this.lbl_products_number.AutoSize = true;
            this.lbl_products_number.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_products_number.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_products_number.Location = new System.Drawing.Point(126, 0);
            this.lbl_products_number.Name = "lbl_products_number";
            this.lbl_products_number.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_products_number.Size = new System.Drawing.Size(29, 19);
            this.lbl_products_number.TabIndex = 7;
            this.lbl_products_number.Text = "00";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1676, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(120, 37);
            this.panel7.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "عدد المنتجات: ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.svgImageBox1);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(541, 37);
            this.panel3.TabIndex = 6;
            // 
            // svgImageBox1
            // 
            this.svgImageBox1.Location = new System.Drawing.Point(1, 3);
            this.svgImageBox1.Name = "svgImageBox1";
            this.svgImageBox1.Size = new System.Drawing.Size(53, 32);
            this.svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            this.svgImageBox1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox1.SvgImage")));
            this.svgImageBox1.TabIndex = 5;
            this.svgImageBox1.Text = "svgImageBox1";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(60, 5);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(439, 30);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pnl_bottm
            // 
            this.pnl_bottm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_bottm.Controls.Add(this.pnl_total_cost);
            this.pnl_bottm.Controls.Add(this.pnl_total_price);
            this.pnl_bottm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_bottm.Location = new System.Drawing.Point(0, 428);
            this.pnl_bottm.Name = "pnl_bottm";
            this.pnl_bottm.Size = new System.Drawing.Size(1798, 117);
            this.pnl_bottm.TabIndex = 4;
            // 
            // pnl_total_cost
            // 
            this.pnl_total_cost.Controls.Add(this.panel9);
            this.pnl_total_cost.Controls.Add(this.panel11);
            this.pnl_total_cost.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_total_cost.Location = new System.Drawing.Point(972, 0);
            this.pnl_total_cost.Name = "pnl_total_cost";
            this.pnl_total_cost.Size = new System.Drawing.Size(415, 115);
            this.pnl_total_cost.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lbl_total_cost);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 59);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(415, 56);
            this.panel9.TabIndex = 4;
            // 
            // lbl_total_cost
            // 
            this.lbl_total_cost.AutoSize = true;
            this.lbl_total_cost.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_total_cost.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_cost.Location = new System.Drawing.Point(328, 0);
            this.lbl_total_cost.Name = "lbl_total_cost";
            this.lbl_total_cost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_total_cost.Size = new System.Drawing.Size(87, 39);
            this.lbl_total_cost.TabIndex = 2;
            this.lbl_total_cost.Text = "0.00";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.pnl_cost_title);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(415, 59);
            this.panel11.TabIndex = 3;
            // 
            // pnl_cost_title
            // 
            this.pnl_cost_title.AutoSize = true;
            this.pnl_cost_title.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_cost_title.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_cost_title.Location = new System.Drawing.Point(99, 0);
            this.pnl_cost_title.Name = "pnl_cost_title";
            this.pnl_cost_title.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnl_cost_title.Size = new System.Drawing.Size(316, 39);
            this.pnl_cost_title.TabIndex = 0;
            this.pnl_cost_title.Text = "إجمالي سعر الشراء";
            // 
            // pnl_total_price
            // 
            this.pnl_total_price.Controls.Add(this.panel10);
            this.pnl_total_price.Controls.Add(this.pnl_price_title);
            this.pnl_total_price.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_total_price.Location = new System.Drawing.Point(1387, 0);
            this.pnl_total_price.Name = "pnl_total_price";
            this.pnl_total_price.Size = new System.Drawing.Size(409, 115);
            this.pnl_total_price.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lbl_total_price);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 59);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(409, 56);
            this.panel10.TabIndex = 2;
            // 
            // lbl_total_price
            // 
            this.lbl_total_price.AutoSize = true;
            this.lbl_total_price.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_total_price.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_price.Location = new System.Drawing.Point(322, 0);
            this.lbl_total_price.Name = "lbl_total_price";
            this.lbl_total_price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_total_price.Size = new System.Drawing.Size(87, 39);
            this.lbl_total_price.TabIndex = 2;
            this.lbl_total_price.Text = "0.00";
            // 
            // pnl_price_title
            // 
            this.pnl_price_title.Controls.Add(this.lbl_price_title);
            this.pnl_price_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_price_title.Location = new System.Drawing.Point(0, 0);
            this.pnl_price_title.Name = "pnl_price_title";
            this.pnl_price_title.Size = new System.Drawing.Size(409, 59);
            this.pnl_price_title.TabIndex = 0;
            // 
            // lbl_price_title
            // 
            this.lbl_price_title.AutoSize = true;
            this.lbl_price_title.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_price_title.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_price_title.Location = new System.Drawing.Point(123, 0);
            this.lbl_price_title.Name = "lbl_price_title";
            this.lbl_price_title.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_price_title.Size = new System.Drawing.Size(286, 39);
            this.lbl_price_title.TabIndex = 0;
            this.lbl_price_title.Text = "إجمالي سعر البيع";
            // 
            // dgv_inventory
            // 
            this.dgv_inventory.AllowUserToAddRows = false;
            this.dgv_inventory.AllowUserToDeleteRows = false;
            this.dgv_inventory.AllowUserToOrderColumns = true;
            this.dgv_inventory.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_inventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Reference,
            this.ProductName,
            this.ProductBrand,
            this.Cost,
            this.Price,
            this.Quantity,
            this.Edit,
            this.Delete,
            this.Restore,
            this.Recomendation});
            this.dgv_inventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_inventory.EnableHeadersVisualStyles = false;
            this.dgv_inventory.Location = new System.Drawing.Point(0, 127);
            this.dgv_inventory.MultiSelect = false;
            this.dgv_inventory.Name = "dgv_inventory";
            this.dgv_inventory.ReadOnly = true;
            this.dgv_inventory.RowHeadersVisible = false;
            this.dgv_inventory.RowHeadersWidth = 62;
            this.dgv_inventory.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgv_inventory.RowTemplate.Height = 28;
            this.dgv_inventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_inventory.Size = new System.Drawing.Size(1798, 301);
            this.dgv_inventory.TabIndex = 5;
            this.dgv_inventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_inventory_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 150;
            // 
            // Reference
            // 
            this.Reference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reference.DefaultCellStyle = dataGridViewCellStyle9;
            this.Reference.HeaderText = "كود المنتج";
            this.Reference.MinimumWidth = 8;
            this.Reference.Name = "Reference";
            this.Reference.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductName.DefaultCellStyle = dataGridViewCellStyle10;
            this.ProductName.HeaderText = "إسم المنتج";
            this.ProductName.MinimumWidth = 8;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // ProductBrand
            // 
            this.ProductBrand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductBrand.DefaultCellStyle = dataGridViewCellStyle11;
            this.ProductBrand.HeaderText = "العلامة التجارية";
            this.ProductBrand.MinimumWidth = 8;
            this.ProductBrand.Name = "ProductBrand";
            this.ProductBrand.ReadOnly = true;
            this.ProductBrand.Width = 145;
            // 
            // Cost
            // 
            this.Cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cost.DefaultCellStyle = dataGridViewCellStyle12;
            this.Cost.HeaderText = "سعر الشراء";
            this.Cost.MinimumWidth = 8;
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Width = 124;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.DefaultCellStyle = dataGridViewCellStyle13;
            this.Price.HeaderText = "سعر البيع";
            this.Price.MinimumWidth = 8;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 111;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle14;
            this.Quantity.HeaderText = "الكمية";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 88;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit.HeaderText = "";
            this.Edit.MinimumWidth = 8;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 8;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.MinimumWidth = 8;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 8;
            // 
            // Restore
            // 
            this.Restore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Restore.HeaderText = "";
            this.Restore.MinimumWidth = 8;
            this.Restore.Name = "Restore";
            this.Restore.ReadOnly = true;
            this.Restore.Visible = false;
            this.Restore.Width = 150;
            // 
            // Recomendation
            // 
            this.Recomendation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Recomendation.HeaderText = "";
            this.Recomendation.MinimumWidth = 8;
            this.Recomendation.Name = "Recomendation";
            this.Recomendation.ReadOnly = true;
            this.Recomendation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Recomendation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Recomendation.Width = 29;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.chk_low_quantity);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(672, 2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(253, 84);
            this.panel12.TabIndex = 14;
            // 
            // chk_low_quantity
            // 
            this.chk_low_quantity.AutoSize = true;
            this.chk_low_quantity.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_low_quantity.Location = new System.Drawing.Point(10, 20);
            this.chk_low_quantity.Name = "chk_low_quantity";
            this.chk_low_quantity.Size = new System.Drawing.Size(242, 33);
            this.chk_low_quantity.TabIndex = 0;
            this.chk_low_quantity.Text = "الكميات المنخفضة";
            this.chk_low_quantity.UseVisualStyleBackColor = true;
            this.chk_low_quantity.CheckedChanged += new System.EventHandler(this.chk_low_quantity_CheckedChanged);
            // 
            // frm_inventory
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1798, 545);
            this.Controls.Add(this.dgv_inventory);
            this.Controls.Add(this.pnl_bottm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frm_inventory";
            this.Text = "frm_inventory";
            this.Load += new System.EventHandler(this.frm_inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).EndInit();
            this.pnl_bottm.ResumeLayout(false);
            this.pnl_total_cost.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.pnl_total_price.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.pnl_price_title.ResumeLayout(false);
            this.pnl_price_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventory)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btn_add_new_product;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        protected System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbl_products_number;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel pnl_bottm;
        private System.Windows.Forms.DataGridView dgv_inventory;
        private System.Windows.Forms.Panel pnl_total_cost;
        private System.Windows.Forms.Panel pnl_total_price;
        private System.Windows.Forms.Panel pnl_price_title;
        private System.Windows.Forms.Label lbl_price_title;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lbl_total_price;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbl_total_cost;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label pnl_cost_title;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox chk_non_active_product;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad_non_zero;
        private System.Windows.Forms.RadioButton rad_zero;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.SimpleButton btn_import_excel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewImageColumn Restore;
        private System.Windows.Forms.DataGridViewImageColumn Recomendation;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraEditors.SimpleButton btn_recomended;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.CheckBox chk_low_quantity;
    }
}