namespace AutoPartsManager.Forms.Returns
{
    partial class frm_return_details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_return_details));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_products = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_submit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_products)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 86);
            this.panel1.TabIndex = 0;
            // 
            // dgv_products
            // 
            this.dgv_products.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_products.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_products.Location = new System.Drawing.Point(0, 86);
            this.dgv_products.Name = "dgv_products";
            this.dgv_products.RowHeadersWidth = 62;
            this.dgv_products.RowTemplate.Height = 28;
            this.dgv_products.Size = new System.Drawing.Size(800, 364);
            this.dgv_products.TabIndex = 1;
            this.dgv_products.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_products_CellBeginEdit);
            this.dgv_products.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_products_CellValidating);
            this.dgv_products.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_products_CellValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Controls.Add(this.btn_submit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 114);
            this.panel2.TabIndex = 2;
            // 
            // btn_submit
            // 
            this.btn_submit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_submit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_submit.Location = new System.Drawing.Point(33, 10);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_submit.Size = new System.Drawing.Size(119, 61);
            this.btn_submit.TabIndex = 0;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btn_cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(167, 10);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_cancel.Size = new System.Drawing.Size(119, 61);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // frm_return_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_products);
            this.Controls.Add(this.panel1);
            this.Name = "frm_return_details";
            this.Text = "frm_return_details";
            this.Load += new System.EventHandler(this.frm_return_details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_products)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_products;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
        private DevExpress.XtraEditors.SimpleButton btn_submit;
    }
}