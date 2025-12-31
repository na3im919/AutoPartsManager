namespace AutoPartsManager.Forms
{
    partial class frm_Clients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Clients));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chk_non_active_clients = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_add_client = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgv_clients = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clients)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(135)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 70);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chk_non_active_clients);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(580, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 70);
            this.panel4.TabIndex = 2;
            // 
            // chk_non_active_clients
            // 
            this.chk_non_active_clients.AutoSize = true;
            this.chk_non_active_clients.Location = new System.Drawing.Point(3, 24);
            this.chk_non_active_clients.Name = "chk_non_active_clients";
            this.chk_non_active_clients.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_non_active_clients.Size = new System.Drawing.Size(229, 28);
            this.chk_non_active_clients.TabIndex = 0;
            this.chk_non_active_clients.Text = "قائمة الزبائن المحذوفين";
            this.chk_non_active_clients.UseVisualStyleBackColor = true;
            this.chk_non_active_clients.CheckedChanged += new System.EventHandler(this.chk_non_active_clients_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.svgImageBox1);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(534, 70);
            this.panel3.TabIndex = 1;
            // 
            // svgImageBox1
            // 
            this.svgImageBox1.Location = new System.Drawing.Point(11, 24);
            this.svgImageBox1.Name = "svgImageBox1";
            this.svgImageBox1.Size = new System.Drawing.Size(53, 32);
            this.svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            this.svgImageBox1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox1.SvgImage")));
            this.svgImageBox1.TabIndex = 7;
            this.svgImageBox1.Text = "svgImageBox1";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(70, 26);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(439, 30);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_add_client);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(855, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(127, 70);
            this.panel2.TabIndex = 0;
            // 
            // btn_add_client
            // 
            this.btn_add_client.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_add_client.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_client.ImageOptions.Image")));
            this.btn_add_client.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_add_client.Location = new System.Drawing.Point(3, 0);
            this.btn_add_client.Name = "btn_add_client";
            this.btn_add_client.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_add_client.Size = new System.Drawing.Size(124, 70);
            this.btn_add_client.TabIndex = 2;
            this.btn_add_client.Click += new System.EventHandler(this.btn_add_client_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(135)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 409);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(982, 41);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // dgv_clients
            // 
            this.dgv_clients.AllowUserToAddRows = false;
            this.dgv_clients.AllowUserToDeleteRows = false;
            this.dgv_clients.AllowUserToOrderColumns = true;
            this.dgv_clients.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_clients.Location = new System.Drawing.Point(0, 70);
            this.dgv_clients.Name = "dgv_clients";
            this.dgv_clients.ReadOnly = true;
            this.dgv_clients.RowHeadersWidth = 62;
            this.dgv_clients.RowTemplate.Height = 28;
            this.dgv_clients.Size = new System.Drawing.Size(982, 339);
            this.dgv_clients.TabIndex = 2;
            // 
            // frm_Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 450);
            this.Controls.Add(this.dgv_clients);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Clients";
            this.Text = "frm_Clients";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btn_add_client;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        protected System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv_clients;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chk_non_active_clients;
    }
}