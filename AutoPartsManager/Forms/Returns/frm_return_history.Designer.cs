namespace AutoPartsManager.Forms.Returns
{
    partial class frm_return_history
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_return_history));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_return_detail = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityPurchased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityAlreadyReturned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableToReturn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectProduct = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save_return = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_return_detail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 65);
            this.panel1.TabIndex = 0;
            // 
            // dgv_return_detail
            // 
            this.dgv_return_detail.AllowUserToAddRows = false;
            this.dgv_return_detail.AllowUserToDeleteRows = false;
            this.dgv_return_detail.AllowUserToOrderColumns = true;
            this.dgv_return_detail.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_return_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_return_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.InvoiceDetailID,
            this.ProductName,
            this.ProductPrice,
            this.QuantityPurchased,
            this.QuantityAlreadyReturned,
            this.AvailableToReturn,
            this.Quantity,
            this.SelectProduct,
            this.Notes});
            this.dgv_return_detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_return_detail.Location = new System.Drawing.Point(0, 65);
            this.dgv_return_detail.Name = "dgv_return_detail";
            this.dgv_return_detail.RowHeadersVisible = false;
            this.dgv_return_detail.RowHeadersWidth = 62;
            this.dgv_return_detail.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_return_detail.RowTemplate.Height = 28;
            this.dgv_return_detail.Size = new System.Drawing.Size(912, 385);
            this.dgv_return_detail.TabIndex = 1;
            this.dgv_return_detail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_return_detail_CellValueChanged);
            this.dgv_return_detail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_return_detail_CurrentCellDirtyStateChanged);
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.MinimumWidth = 8;
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = false;
            this.ProductID.Width = 150;
            // 
            // InvoiceDetailID
            // 
            this.InvoiceDetailID.HeaderText = "InvoiceDetailID ";
            this.InvoiceDetailID.MinimumWidth = 8;
            this.InvoiceDetailID.Name = "InvoiceDetailID";
            this.InvoiceDetailID.Visible = false;
            this.InvoiceDetailID.Width = 150;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductName.DefaultCellStyle = dataGridViewCellStyle7;
            this.ProductName.HeaderText = "إسم المنتج";
            this.ProductName.MinimumWidth = 8;
            this.ProductName.Name = "ProductName";
            // 
            // ProductPrice
            // 
            this.ProductPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.ProductPrice.HeaderText = "سعر المنتج";
            this.ProductPrice.MinimumWidth = 8;
            this.ProductPrice.Name = "ProductPrice";
            this.ProductPrice.Width = 114;
            // 
            // QuantityPurchased
            // 
            this.QuantityPurchased.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityPurchased.DefaultCellStyle = dataGridViewCellStyle9;
            this.QuantityPurchased.HeaderText = "الكمية المباعة";
            this.QuantityPurchased.MinimumWidth = 8;
            this.QuantityPurchased.Name = "QuantityPurchased";
            this.QuantityPurchased.Width = 130;
            // 
            // QuantityAlreadyReturned
            // 
            this.QuantityAlreadyReturned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityAlreadyReturned.DefaultCellStyle = dataGridViewCellStyle10;
            this.QuantityAlreadyReturned.HeaderText = "الكمية المعادة مسبقا";
            this.QuantityAlreadyReturned.MinimumWidth = 8;
            this.QuantityAlreadyReturned.Name = "QuantityAlreadyReturned";
            this.QuantityAlreadyReturned.Width = 173;
            // 
            // AvailableToReturn
            // 
            this.AvailableToReturn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableToReturn.DefaultCellStyle = dataGridViewCellStyle11;
            this.AvailableToReturn.HeaderText = "متاح للإرجاع";
            this.AvailableToReturn.MinimumWidth = 8;
            this.AvailableToReturn.Name = "AvailableToReturn";
            this.AvailableToReturn.Width = 117;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle12;
            this.Quantity.HeaderText = "كمية الإرجاع الحالي";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 165;
            // 
            // SelectProduct
            // 
            this.SelectProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SelectProduct.HeaderText = "إختيار المنتجات";
            this.SelectProduct.MinimumWidth = 8;
            this.SelectProduct.Name = "SelectProduct";
            this.SelectProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectProduct.Width = 106;
            // 
            // Notes
            // 
            this.Notes.HeaderText = "ملاحظات";
            this.Notes.MinimumWidth = 8;
            this.Notes.Name = "Notes";
            this.Notes.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Controls.Add(this.btn_save_return);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 104);
            this.panel2.TabIndex = 2;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Appearance.Options.UseFont = true;
            this.btn_cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.ImageOptions.Image")));
            this.btn_cancel.Location = new System.Drawing.Point(210, 24);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 66);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "إلغاء";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save_return
            // 
            this.btn_save_return.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_return.Appearance.Options.UseFont = true;
            this.btn_save_return.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save_return.ImageOptions.Image")));
            this.btn_save_return.Location = new System.Drawing.Point(33, 24);
            this.btn_save_return.Name = "btn_save_return";
            this.btn_save_return.Size = new System.Drawing.Size(150, 66);
            this.btn_save_return.TabIndex = 0;
            this.btn_save_return.Text = "إرجاع";
            this.btn_save_return.Click += new System.EventHandler(this.btn_save_return_Click);
            // 
            // frm_return_history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_return_detail);
            this.Controls.Add(this.panel1);
            this.Name = "frm_return_history";
            this.Text = "frm_return_deatails";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_return_deatails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_return_detail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_return_detail;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btn_save_return;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityPurchased;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityAlreadyReturned;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableToReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
    }
}