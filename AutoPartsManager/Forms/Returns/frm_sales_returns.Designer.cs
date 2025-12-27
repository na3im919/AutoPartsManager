namespace AutoPartsManager.Forms.Returns
{
    partial class frm_sales_returns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_sales_returns));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_returns = new System.Windows.Forms.DataGridView();
            this.btn_add_return = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_client_returns = new System.Windows.Forms.RadioButton();
            this.rb_supplier_returns = new System.Windows.Forms.RadioButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_returns)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 105);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_add_return);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(850, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 105);
            this.panel2.TabIndex = 1;
            // 
            // dgv_returns
            // 
            this.dgv_returns.AllowUserToAddRows = false;
            this.dgv_returns.AllowUserToDeleteRows = false;
            this.dgv_returns.AllowUserToOrderColumns = true;
            this.dgv_returns.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_returns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_returns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.InvoiceID,
            this.Date,
            this.ClientID,
            this.ClientName,
            this.SupplierID,
            this.SupplierName,
            this.Status,
            this.TotalAmount,
            this.Details});
            this.dgv_returns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_returns.Location = new System.Drawing.Point(0, 105);
            this.dgv_returns.MultiSelect = false;
            this.dgv_returns.Name = "dgv_returns";
            this.dgv_returns.ReadOnly = true;
            this.dgv_returns.RowHeadersVisible = false;
            this.dgv_returns.RowHeadersWidth = 62;
            this.dgv_returns.RowTemplate.Height = 28;
            this.dgv_returns.Size = new System.Drawing.Size(1094, 345);
            this.dgv_returns.TabIndex = 1;
            this.dgv_returns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_returns_CellClick);
            // 
            // btn_add_return
            // 
            this.btn_add_return.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_return.Appearance.Options.UseFont = true;
            this.btn_add_return.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_add_return.Location = new System.Drawing.Point(24, 3);
            this.btn_add_return.Name = "btn_add_return";
            this.btn_add_return.Size = new System.Drawing.Size(190, 87);
            this.btn_add_return.TabIndex = 0;
            this.btn_add_return.Text = "إضافة مرتجع";
            this.btn_add_return.Click += new System.EventHandler(this.btn_add_return_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_supplier_returns);
            this.groupBox1.Controls.Add(this.rb_client_returns);
            this.groupBox1.Location = new System.Drawing.Point(476, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // rb_client_returns
            // 
            this.rb_client_returns.AutoSize = true;
            this.rb_client_returns.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_client_returns.Location = new System.Drawing.Point(36, 34);
            this.rb_client_returns.Name = "rb_client_returns";
            this.rb_client_returns.Size = new System.Drawing.Size(101, 28);
            this.rb_client_returns.TabIndex = 0;
            this.rb_client_returns.TabStop = true;
            this.rb_client_returns.Text = "مبيعات";
            this.rb_client_returns.UseVisualStyleBackColor = true;
            this.rb_client_returns.CheckedChanged += new System.EventHandler(this.rb_client_returns_CheckedChanged);
            // 
            // rb_supplier_returns
            // 
            this.rb_supplier_returns.AutoSize = true;
            this.rb_supplier_returns.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_supplier_returns.Location = new System.Drawing.Point(203, 34);
            this.rb_supplier_returns.Name = "rb_supplier_returns";
            this.rb_supplier_returns.Size = new System.Drawing.Size(121, 28);
            this.rb_supplier_returns.TabIndex = 1;
            this.rb_supplier_returns.TabStop = true;
            this.rb_supplier_returns.Text = "مشتريات";
            this.rb_supplier_returns.UseVisualStyleBackColor = true;
            this.rb_supplier_returns.CheckedChanged += new System.EventHandler(this.rb_supplier_returns_CheckedChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 150;
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "";
            this.InvoiceID.MinimumWidth = 8;
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.ReadOnly = true;
            this.InvoiceID.Visible = false;
            this.InvoiceID.Width = 150;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.HeaderText = "التاريخ";
            this.Date.MinimumWidth = 8;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // ClientID
            // 
            this.ClientID.HeaderText = "";
            this.ClientID.MinimumWidth = 8;
            this.ClientID.Name = "ClientID";
            this.ClientID.ReadOnly = true;
            this.ClientID.Visible = false;
            this.ClientID.Width = 150;
            // 
            // ClientName
            // 
            this.ClientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientName.HeaderText = "إسم الزبون";
            this.ClientName.MinimumWidth = 8;
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // SupplierID
            // 
            this.SupplierID.HeaderText = "";
            this.SupplierID.MinimumWidth = 8;
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.ReadOnly = true;
            this.SupplierID.Visible = false;
            this.SupplierID.Width = 150;
            // 
            // SupplierName
            // 
            this.SupplierName.HeaderText = "إسم المورد";
            this.SupplierName.MinimumWidth = 8;
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            this.SupplierName.Width = 150;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "الحالة";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalAmount.HeaderText = "المبلغ الإجمالي";
            this.TotalAmount.MinimumWidth = 8;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // Details
            // 
            this.Details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Details.HeaderText = "";
            this.Details.MinimumWidth = 8;
            this.Details.Name = "Details";
            this.Details.ReadOnly = true;
            this.Details.Width = 8;
            // 
            // frm_sales_returns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 450);
            this.Controls.Add(this.dgv_returns);
            this.Controls.Add(this.panel1);
            this.Name = "frm_sales_returns";
            this.Text = "frm_sales_returns";
            this.Load += new System.EventHandler(this.frm_sales_returns_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_returns)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btn_add_return;
        private System.Windows.Forms.DataGridView dgv_returns;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_supplier_returns;
        private System.Windows.Forms.RadioButton rb_client_returns;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewImageColumn Details;
    }
}