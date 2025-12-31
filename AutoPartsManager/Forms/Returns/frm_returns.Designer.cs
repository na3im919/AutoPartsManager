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
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_add_returns = new DevExpress.XtraEditors.SimpleButton();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(115)))), ((int)(((byte)(221)))));
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(881, 69);
            this.panel5.TabIndex = 0;
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
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 69);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(881, 68);
            this.panel7.TabIndex = 1;
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
            // frm_returns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 450);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Name = "frm_returns";
            this.Text = "frm_returns";
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
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
    }
}