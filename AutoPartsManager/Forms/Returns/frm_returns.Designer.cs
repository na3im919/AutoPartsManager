namespace AutoPartsManager.Forms.Returns
{
    partial class frm_returns
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rad_sale = new System.Windows.Forms.RadioButton();
            this.rad_purchase = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_add_returns = new DevExpress.XtraEditors.SimpleButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgv_returns = new System.Windows.Forms.DataGridView();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_returns)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(135)))));
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(881, 69);
            this.panel5.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rad_sale);
            this.panel8.Controls.Add(this.rad_purchase);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(405, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(304, 69);
            this.panel8.TabIndex = 4;
            // 
            // rad_sale
            // 
            this.rad_sale.AutoSize = true;
            this.rad_sale.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_sale.Location = new System.Drawing.Point(48, 12);
            this.rad_sale.Name = "rad_sale";
            this.rad_sale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rad_sale.Size = new System.Drawing.Size(91, 28);
            this.rad_sale.TabIndex = 2;
            this.rad_sale.TabStop = true;
            this.rad_sale.Text = "مبيعات";
            this.rad_sale.UseVisualStyleBackColor = true;
            this.rad_sale.CheckedChanged += new System.EventHandler(this.rad_sale_CheckedChanged);
            // 
            // rad_purchase
            // 
            this.rad_purchase.AutoSize = true;
            this.rad_purchase.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_purchase.Location = new System.Drawing.Point(182, 12);
            this.rad_purchase.Name = "rad_purchase";
            this.rad_purchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rad_purchase.Size = new System.Drawing.Size(109, 28);
            this.rad_purchase.TabIndex = 3;
            this.rad_purchase.TabStop = true;
            this.rad_purchase.Text = "مشتريات";
            this.rad_purchase.UseVisualStyleBackColor = true;
            this.rad_purchase.CheckedChanged += new System.EventHandler(this.rad_purchase_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_add_returns);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(709, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(172, 69);
            this.panel6.TabIndex = 1;
            // 
            // btn_add_returns
            // 
            this.btn_add_returns.Location = new System.Drawing.Point(15, 8);
            this.btn_add_returns.Name = "btn_add_returns";
            this.btn_add_returns.Size = new System.Drawing.Size(145, 55);
            this.btn_add_returns.TabIndex = 0;
            this.btn_add_returns.Text = "simpleButton1";
            this.btn_add_returns.Click += new System.EventHandler(this.btn_add_returns_Click);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 69);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(881, 68);
            this.panel7.TabIndex = 1;
            // 
            // dgv_returns
            // 
            this.dgv_returns.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_returns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_returns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_returns.Location = new System.Drawing.Point(0, 137);
            this.dgv_returns.Name = "dgv_returns";
            this.dgv_returns.RowHeadersWidth = 62;
            this.dgv_returns.RowTemplate.Height = 28;
            this.dgv_returns.Size = new System.Drawing.Size(881, 313);
            this.dgv_returns.TabIndex = 2;
            this.dgv_returns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_returns_CellClick);
            // 
            // frm_returns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 450);
            this.Controls.Add(this.dgv_returns);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Name = "frm_returns";
            this.Text = "frm_returns";
            this.Load += new System.EventHandler(this.frm_returns_Load);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_returns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad_sales;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton rad_purchases;
        private DevExpress.XtraEditors.SimpleButton btn_add_return;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgv_invoices;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private DevExpress.XtraEditors.SimpleButton btn_add_returns;
        private System.Windows.Forms.RadioButton rad_sale;
        private System.Windows.Forms.RadioButton rad_purchase;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgv_returns;
    }
}