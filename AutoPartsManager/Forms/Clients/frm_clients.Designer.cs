namespace AutoPartsManager.Forms.Clients
{
    partial class frm_clients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_clients));
            this.pnl_cost_title = new System.Windows.Forms.Label();
            this.pnl_total_price = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lbl_total_price = new System.Windows.Forms.Label();
            this.pnl_price_title = new System.Windows.Forms.Panel();
            this.lbl_price_title = new System.Windows.Forms.Label();
            this.lbl_total_cost = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgv_clients = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.Restore = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_non_active = new System.Windows.Forms.RadioButton();
            this.rad_active = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_add_new_client = new DevExpress.XtraEditors.SimpleButton();
            this.pnl_total_cost = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pnl_bottm = new System.Windows.Forms.Panel();
            this.lbl_clients_number = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_total_price.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnl_price_title.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clients)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnl_total_cost.SuspendLayout();
            this.panel11.SuspendLayout();
            this.pnl_bottm.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.pnl_total_price.Location = new System.Drawing.Point(967, 0);
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
            // panel9
            // 
            this.panel9.Controls.Add(this.lbl_total_cost);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 59);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(415, 56);
            this.panel9.TabIndex = 4;
            // 
            // dgv_clients
            // 
            this.dgv_clients.AllowUserToAddRows = false;
            this.dgv_clients.AllowUserToDeleteRows = false;
            this.dgv_clients.AllowUserToOrderColumns = true;
            this.dgv_clients.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_clients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ClientName,
            this.ClientPhone,
            this.ClientAddress,
            this.Edit,
            this.Delete,
            this.Restore});
            this.dgv_clients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_clients.EnableHeadersVisualStyles = false;
            this.dgv_clients.Location = new System.Drawing.Point(0, 127);
            this.dgv_clients.MultiSelect = false;
            this.dgv_clients.Name = "dgv_clients";
            this.dgv_clients.ReadOnly = true;
            this.dgv_clients.RowHeadersVisible = false;
            this.dgv_clients.RowHeadersWidth = 62;
            this.dgv_clients.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgv_clients.RowTemplate.Height = 28;
            this.dgv_clients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_clients.Size = new System.Drawing.Size(1378, 301);
            this.dgv_clients.TabIndex = 9;
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
            // ClientName
            // 
            this.ClientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ClientName.HeaderText = "إسم الزبون";
            this.ClientName.MinimumWidth = 8;
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // ClientPhone
            // 
            this.ClientPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientPhone.DefaultCellStyle = dataGridViewCellStyle3;
            this.ClientPhone.HeaderText = "رقم الهاتف";
            this.ClientPhone.MinimumWidth = 8;
            this.ClientPhone.Name = "ClientPhone";
            this.ClientPhone.ReadOnly = true;
            // 
            // ClientAddress
            // 
            this.ClientAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientAddress.DefaultCellStyle = dataGridViewCellStyle4;
            this.ClientAddress.HeaderText = "العنوان";
            this.ClientAddress.MinimumWidth = 8;
            this.ClientAddress.Name = "ClientAddress";
            this.ClientAddress.ReadOnly = true;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_non_active);
            this.groupBox1.Controls.Add(this.rad_active);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 84);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // rad_non_active
            // 
            this.rad_non_active.AutoSize = true;
            this.rad_non_active.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_non_active.Location = new System.Drawing.Point(211, 27);
            this.rad_non_active.Name = "rad_non_active";
            this.rad_non_active.Size = new System.Drawing.Size(302, 33);
            this.rad_non_active.TabIndex = 1;
            this.rad_non_active.TabStop = true;
            this.rad_non_active.Text = "قائمة الزبائن المحذوفين";
            this.rad_non_active.UseVisualStyleBackColor = true;
            this.rad_non_active.CheckedChanged += new System.EventHandler(this.rad_non_active_CheckedChanged);
            // 
            // rad_active
            // 
            this.rad_active.AutoSize = true;
            this.rad_active.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_active.Location = new System.Drawing.Point(12, 27);
            this.rad_active.Name = "rad_active";
            this.rad_active.Size = new System.Drawing.Size(184, 33);
            this.rad_active.TabIndex = 0;
            this.rad_active.TabStop = true;
            this.rad_active.Text = "قائمة الزبائن ";
            this.rad_active.UseVisualStyleBackColor = true;
            this.rad_active.CheckedChanged += new System.EventHandler(this.rad_active_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_add_new_client);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1148, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 84);
            this.panel2.TabIndex = 6;
            // 
            // btn_add_new_client
            // 
            this.btn_add_new_client.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_add_new_client.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_new_client.Appearance.Options.UseBackColor = true;
            this.btn_add_new_client.Appearance.Options.UseFont = true;
            this.btn_add_new_client.AppearancePressed.Options.UseBackColor = true;
            this.btn_add_new_client.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_new_client.ImageOptions.Image")));
            this.btn_add_new_client.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btn_add_new_client.Location = new System.Drawing.Point(16, 9);
            this.btn_add_new_client.Name = "btn_add_new_client";
            this.btn_add_new_client.Size = new System.Drawing.Size(181, 66);
            this.btn_add_new_client.TabIndex = 4;
            this.btn_add_new_client.Text = "إضافة زبون";
            this.btn_add_new_client.Click += new System.EventHandler(this.btn_add_new_client_Click);
            // 
            // pnl_total_cost
            // 
            this.pnl_total_cost.Controls.Add(this.panel9);
            this.pnl_total_cost.Controls.Add(this.panel11);
            this.pnl_total_cost.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_total_cost.Location = new System.Drawing.Point(552, 0);
            this.pnl_total_cost.Name = "pnl_total_cost";
            this.pnl_total_cost.Size = new System.Drawing.Size(415, 115);
            this.pnl_total_cost.TabIndex = 1;
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
            // pnl_bottm
            // 
            this.pnl_bottm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_bottm.Controls.Add(this.pnl_total_cost);
            this.pnl_bottm.Controls.Add(this.pnl_total_price);
            this.pnl_bottm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_bottm.Location = new System.Drawing.Point(0, 428);
            this.pnl_bottm.Name = "pnl_bottm";
            this.pnl_bottm.Size = new System.Drawing.Size(1378, 117);
            this.pnl_bottm.TabIndex = 8;
            // 
            // lbl_clients_number
            // 
            this.lbl_clients_number.AutoSize = true;
            this.lbl_clients_number.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_clients_number.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_clients_number.Location = new System.Drawing.Point(126, 0);
            this.lbl_clients_number.Name = "lbl_clients_number";
            this.lbl_clients_number.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_clients_number.Size = new System.Drawing.Size(29, 19);
            this.lbl_clients_number.TabIndex = 7;
            this.lbl_clients_number.Text = "00";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1256, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(120, 37);
            this.panel7.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "عدد الزبائن: ";
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 39);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1378, 88);
            this.panelControl1.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lbl_clients_number);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(1101, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(155, 37);
            this.panel8.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1378, 39);
            this.panel1.TabIndex = 7;
            // 
            // frm_clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 545);
            this.Controls.Add(this.dgv_clients);
            this.Controls.Add(this.pnl_bottm);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_clients";
            this.Text = "fr_clients";
            this.Load += new System.EventHandler(this.frm_clients_Load);
            this.pnl_total_price.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.pnl_price_title.ResumeLayout(false);
            this.pnl_price_title.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clients)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnl_total_cost.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.pnl_bottm.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label pnl_cost_title;
        private System.Windows.Forms.Panel pnl_total_price;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lbl_total_price;
        private System.Windows.Forms.Panel pnl_price_title;
        private System.Windows.Forms.Label lbl_price_title;
        private System.Windows.Forms.Label lbl_total_cost;
        private DevExpress.XtraEditors.SimpleButton btn_add_new_client;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgv_clients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad_non_active;
        private System.Windows.Forms.RadioButton rad_active;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnl_total_cost;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel pnl_bottm;
        private System.Windows.Forms.Label lbl_clients_number;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        protected System.Windows.Forms.TextBox txtSearch;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientAddress;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewImageColumn Restore;
    }
}