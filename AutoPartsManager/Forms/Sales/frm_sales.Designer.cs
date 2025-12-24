namespace AutoPartsManager.Forms
{
    partial class frm_sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_sales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_discount = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_edit_quantity = new DevExpress.XtraEditors.SimpleButton();
            this.btn_discount = new DevExpress.XtraEditors.SimpleButton();
            this.btn_clear_invoice = new DevExpress.XtraEditors.SimpleButton();
            this.btn_delete_product = new DevExpress.XtraEditors.SimpleButton();
            this.btn_add_invoice = new DevExpress.XtraEditors.SimpleButton();
            this.dgv_invoice_list = new System.Windows.Forms.DataGridView();
            this.dgv_suggest = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_invoice_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_suggest)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(135)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.svgImageBox1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 108);
            this.panel1.TabIndex = 0;
            // 
            // svgImageBox1
            // 
            this.svgImageBox1.Location = new System.Drawing.Point(11, 50);
            this.svgImageBox1.Name = "svgImageBox1";
            this.svgImageBox1.Size = new System.Drawing.Size(53, 32);
            this.svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            this.svgImageBox1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox1.SvgImage")));
            this.svgImageBox1.TabIndex = 1;
            this.svgImageBox1.Text = "svgImageBox1";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(70, 55);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(466, 41);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 853);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1045, 155);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(318, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(378, 155);
            this.panel6.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 43);
            this.label4.TabIndex = 6;
            this.label4.Text = "المبلغ الإجمالي";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 34);
            this.label3.TabIndex = 5;
            this.label3.Text = "-----------------------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 43);
            this.label2.TabIndex = 4;
            this.label2.Text = "الخصم";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(135)))));
            this.panel5.Controls.Add(this.lbl_discount);
            this.panel5.Controls.Add(this.lbl_total);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(696, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(349, 155);
            this.panel5.TabIndex = 0;
            // 
            // lbl_discount
            // 
            this.lbl_discount.AutoSize = true;
            this.lbl_discount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_discount.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_discount.ForeColor = System.Drawing.Color.White;
            this.lbl_discount.Location = new System.Drawing.Point(0, 0);
            this.lbl_discount.Name = "lbl_discount";
            this.lbl_discount.Size = new System.Drawing.Size(90, 43);
            this.lbl_discount.TabIndex = 1;
            this.lbl_discount.Text = "0.00";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_total.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.ForeColor = System.Drawing.Color.White;
            this.lbl_total.Location = new System.Drawing.Point(0, 112);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(90, 43);
            this.lbl_total.TabIndex = 0;
            this.lbl_total.Text = "0.00";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.btn_add_invoice);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(698, 108);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 745);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.btn_edit_quantity);
            this.panel4.Controls.Add(this.btn_discount);
            this.panel4.Controls.Add(this.btn_clear_invoice);
            this.panel4.Controls.Add(this.btn_delete_product);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(345, 593);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 60);
            this.label1.TabIndex = 5;
            this.label1.Text = "إدارة المبيعات";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(51, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btn_edit_quantity
            // 
            this.btn_edit_quantity.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.btn_edit_quantity.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit_quantity.Appearance.Options.UseBackColor = true;
            this.btn_edit_quantity.Appearance.Options.UseFont = true;
            this.btn_edit_quantity.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit_quantity.ImageOptions.Image")));
            this.btn_edit_quantity.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_edit_quantity.Location = new System.Drawing.Point(5, 233);
            this.btn_edit_quantity.Name = "btn_edit_quantity";
            this.btn_edit_quantity.Size = new System.Drawing.Size(161, 163);
            this.btn_edit_quantity.TabIndex = 8;
            this.btn_edit_quantity.Text = "الكمية";
            this.btn_edit_quantity.Click += new System.EventHandler(this.btn_edit_quantity_Click);
            // 
            // btn_discount
            // 
            this.btn_discount.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.btn_discount.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_discount.Appearance.Options.UseBackColor = true;
            this.btn_discount.Appearance.Options.UseFont = true;
            this.btn_discount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_discount.ImageOptions.Image")));
            this.btn_discount.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_discount.Location = new System.Drawing.Point(172, 233);
            this.btn_discount.Name = "btn_discount";
            this.btn_discount.Size = new System.Drawing.Size(161, 163);
            this.btn_discount.TabIndex = 7;
            this.btn_discount.Text = "خصم";
            this.btn_discount.Click += new System.EventHandler(this.btn_discount_Click);
            // 
            // btn_clear_invoice
            // 
            this.btn_clear_invoice.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btn_clear_invoice.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear_invoice.Appearance.Options.UseBackColor = true;
            this.btn_clear_invoice.Appearance.Options.UseFont = true;
            this.btn_clear_invoice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_clear_invoice.BackgroundImage")));
            this.btn_clear_invoice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_clear_invoice.ImageOptions.Image")));
            this.btn_clear_invoice.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_clear_invoice.Location = new System.Drawing.Point(5, 402);
            this.btn_clear_invoice.Name = "btn_clear_invoice";
            this.btn_clear_invoice.Size = new System.Drawing.Size(161, 163);
            this.btn_clear_invoice.TabIndex = 6;
            this.btn_clear_invoice.Text = "مسح القائمة";
            this.btn_clear_invoice.Click += new System.EventHandler(this.btn_clear_invoice_Click);
            // 
            // btn_delete_product
            // 
            this.btn_delete_product.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btn_delete_product.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete_product.Appearance.Options.UseBackColor = true;
            this.btn_delete_product.Appearance.Options.UseFont = true;
            this.btn_delete_product.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete_product.ImageOptions.Image")));
            this.btn_delete_product.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_delete_product.Location = new System.Drawing.Point(172, 402);
            this.btn_delete_product.Name = "btn_delete_product";
            this.btn_delete_product.Size = new System.Drawing.Size(161, 163);
            this.btn_delete_product.TabIndex = 5;
            this.btn_delete_product.Text = "حذف منتج";
            this.btn_delete_product.Click += new System.EventHandler(this.btn_delete_product_Click);
            // 
            // btn_add_invoice
            // 
            this.btn_add_invoice.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(138)))), ((int)(((byte)(71)))));
            this.btn_add_invoice.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_invoice.Appearance.Options.UseBackColor = true;
            this.btn_add_invoice.Appearance.Options.UseFont = true;
            this.btn_add_invoice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_add_invoice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_invoice.ImageOptions.Image")));
            this.btn_add_invoice.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_add_invoice.Location = new System.Drawing.Point(0, 598);
            this.btn_add_invoice.Name = "btn_add_invoice";
            this.btn_add_invoice.Size = new System.Drawing.Size(345, 145);
            this.btn_add_invoice.TabIndex = 0;
            this.btn_add_invoice.Text = "دفع";
            this.btn_add_invoice.Click += new System.EventHandler(this.btn_add_invoice_Click);
            // 
            // dgv_invoice_list
            // 
            this.dgv_invoice_list.AllowUserToAddRows = false;
            this.dgv_invoice_list.AllowUserToDeleteRows = false;
            this.dgv_invoice_list.AllowUserToOrderColumns = true;
            this.dgv_invoice_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_invoice_list.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_invoice_list.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_invoice_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_invoice_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Reference,
            this.ProductName,
            this.ProductBrand,
            this.Quantity,
            this.Price,
            this.Total,
            this.IsNew});
            this.dgv_invoice_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_invoice_list.Location = new System.Drawing.Point(0, 108);
            this.dgv_invoice_list.MultiSelect = false;
            this.dgv_invoice_list.Name = "dgv_invoice_list";
            this.dgv_invoice_list.ReadOnly = true;
            this.dgv_invoice_list.RowHeadersVisible = false;
            this.dgv_invoice_list.RowHeadersWidth = 62;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_invoice_list.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_invoice_list.RowTemplate.Height = 28;
            this.dgv_invoice_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_invoice_list.Size = new System.Drawing.Size(698, 745);
            this.dgv_invoice_list.TabIndex = 3;
            // 
            // dgv_suggest
            // 
            this.dgv_suggest.AllowUserToAddRows = false;
            this.dgv_suggest.AllowUserToDeleteRows = false;
            this.dgv_suggest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_suggest.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_suggest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_suggest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_suggest.Location = new System.Drawing.Point(318, 108);
            this.dgv_suggest.Name = "dgv_suggest";
            this.dgv_suggest.ReadOnly = true;
            this.dgv_suggest.RowHeadersWidth = 62;
            this.dgv_suggest.RowTemplate.Height = 28;
            this.dgv_suggest.Size = new System.Drawing.Size(468, 182);
            this.dgv_suggest.TabIndex = 4;
            this.dgv_suggest.Visible = false;
            this.dgv_suggest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_suggest_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Reference
            // 
            this.Reference.HeaderText = "كود المنتج";
            this.Reference.MinimumWidth = 8;
            this.Reference.Name = "Reference";
            this.Reference.ReadOnly = true;
            this.Reference.Visible = false;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductName.DefaultCellStyle = dataGridViewCellStyle1;
            this.ProductName.HeaderText = "إسم المنتج";
            this.ProductName.MinimumWidth = 8;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 123;
            // 
            // ProductBrand
            // 
            this.ProductBrand.HeaderText = "العلامة التجارية";
            this.ProductBrand.MinimumWidth = 8;
            this.ProductBrand.Name = "ProductBrand";
            this.ProductBrand.ReadOnly = true;
            this.ProductBrand.Visible = false;
            // 
            // Quantity
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantity.HeaderText = "الكمية";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Price
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Price.HeaderText = "السعر";
            this.Price.MinimumWidth = 8;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Total
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.DefaultCellStyle = dataGridViewCellStyle4;
            this.Total.HeaderText = "الإجمالي";
            this.Total.MinimumWidth = 8;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // IsNew
            // 
            this.IsNew.HeaderText = "";
            this.IsNew.MinimumWidth = 8;
            this.IsNew.Name = "IsNew";
            this.IsNew.ReadOnly = true;
            this.IsNew.Visible = false;
            // 
            // frm_sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 1008);
            this.Controls.Add(this.dgv_suggest);
            this.Controls.Add(this.dgv_invoice_list);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frm_sales";
            this.Text = "frm_sales";
            this.Load += new System.EventHandler(this.frm_sales_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sales_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_sales_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_invoice_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_suggest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btn_clear_invoice;
        private DevExpress.XtraEditors.SimpleButton btn_delete_product;
        private DevExpress.XtraEditors.SimpleButton btn_add_invoice;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.PictureBox pictureBox1;
        protected DevExpress.XtraEditors.SimpleButton btn_discount;
        protected System.Windows.Forms.TextBox txtSearch;
        protected System.Windows.Forms.DataGridView dgv_invoice_list;
        protected System.Windows.Forms.DataGridView dgv_suggest;
        protected System.Windows.Forms.Label lbl_discount;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        protected DevExpress.XtraEditors.SimpleButton btn_edit_quantity;
        protected System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsNew;
    }
}