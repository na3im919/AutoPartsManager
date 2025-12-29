namespace AutoPartsManager.Forms.frm_reports
{
    partial class frm_reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_reports));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_monthly = new DevExpress.XtraEditors.SimpleButton();
            this.btn_yearly = new DevExpress.XtraEditors.SimpleButton();
            this.btn_weekly = new DevExpress.XtraEditors.SimpleButton();
            this.btn_daily = new DevExpress.XtraEditors.SimpleButton();
            this.dtp_startDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_endDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_add_report = new DevExpress.XtraEditors.SimpleButton();
            this.chk_reportes = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_main_content = new System.Windows.Forms.Label();
            this.lbl_main_title = new System.Windows.Forms.Label();
            this.pnl_reports = new System.Windows.Forms.Panel();
            this.pnl_main_lbl = new System.Windows.Forms.Panel();
            this.pnl_sub_lbl = new System.Windows.Forms.Panel();
            this.lbl_sub_content = new System.Windows.Forms.Label();
            this.lbl_sub_title = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnl_main_lbl.SuspendLayout();
            this.pnl_sub_lbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 144);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_monthly);
            this.panel3.Controls.Add(this.btn_yearly);
            this.panel3.Controls.Add(this.btn_weekly);
            this.panel3.Controls.Add(this.btn_daily);
            this.panel3.Controls.Add(this.dtp_startDate);
            this.panel3.Controls.Add(this.dtp_endDate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(649, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(610, 144);
            this.panel3.TabIndex = 2;
            // 
            // btn_monthly
            // 
            this.btn_monthly.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_monthly.Appearance.Options.UseFont = true;
            this.btn_monthly.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_monthly.ImageOptions.Image")));
            this.btn_monthly.Location = new System.Drawing.Point(57, 70);
            this.btn_monthly.Name = "btn_monthly";
            this.btn_monthly.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_monthly.Size = new System.Drawing.Size(148, 61);
            this.btn_monthly.TabIndex = 6;
            this.btn_monthly.Text = "شهري";
            this.btn_monthly.Click += new System.EventHandler(this.btn_monthly_Click);
            // 
            // btn_yearly
            // 
            this.btn_yearly.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_yearly.Appearance.Options.UseFont = true;
            this.btn_yearly.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_yearly.ImageOptions.Image")));
            this.btn_yearly.Location = new System.Drawing.Point(211, 70);
            this.btn_yearly.Name = "btn_yearly";
            this.btn_yearly.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_yearly.Size = new System.Drawing.Size(148, 61);
            this.btn_yearly.TabIndex = 5;
            this.btn_yearly.Text = "سنوي";
            this.btn_yearly.Click += new System.EventHandler(this.btn_yearly_Click);
            // 
            // btn_weekly
            // 
            this.btn_weekly.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_weekly.Appearance.Options.UseFont = true;
            this.btn_weekly.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_weekly.ImageOptions.Image")));
            this.btn_weekly.Location = new System.Drawing.Point(211, 3);
            this.btn_weekly.Name = "btn_weekly";
            this.btn_weekly.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_weekly.Size = new System.Drawing.Size(148, 61);
            this.btn_weekly.TabIndex = 4;
            this.btn_weekly.Text = "أسبوعي";
            this.btn_weekly.Click += new System.EventHandler(this.btn_weekly_Click);
            // 
            // btn_daily
            // 
            this.btn_daily.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_daily.Appearance.Options.UseFont = true;
            this.btn_daily.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_daily.ImageOptions.Image")));
            this.btn_daily.Location = new System.Drawing.Point(57, 3);
            this.btn_daily.Name = "btn_daily";
            this.btn_daily.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_daily.Size = new System.Drawing.Size(148, 61);
            this.btn_daily.TabIndex = 3;
            this.btn_daily.Text = "يومي";
            this.btn_daily.Click += new System.EventHandler(this.btn_daily_Click);
            // 
            // dtp_startDate
            // 
            this.dtp_startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_startDate.Location = new System.Drawing.Point(425, 12);
            this.dtp_startDate.Name = "dtp_startDate";
            this.dtp_startDate.Size = new System.Drawing.Size(173, 27);
            this.dtp_startDate.TabIndex = 1;
            this.dtp_startDate.ValueChanged += new System.EventHandler(this.dto_startDate_ValueChanged);
            this.dtp_startDate.Enter += new System.EventHandler(this.dtp_startDate_Enter);
            // 
            // dtp_endDate
            // 
            this.dtp_endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_endDate.Location = new System.Drawing.Point(425, 58);
            this.dtp_endDate.Name = "dtp_endDate";
            this.dtp_endDate.Size = new System.Drawing.Size(173, 27);
            this.dtp_endDate.TabIndex = 0;
            this.dtp_endDate.ValueChanged += new System.EventHandler(this.dtp_endDate_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_add_report);
            this.panel2.Controls.Add(this.chk_reportes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 144);
            this.panel2.TabIndex = 1;
            // 
            // btn_add_report
            // 
            this.btn_add_report.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_report.Appearance.Options.UseFont = true;
            this.btn_add_report.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_report.ImageOptions.Image")));
            this.btn_add_report.Location = new System.Drawing.Point(350, 24);
            this.btn_add_report.Name = "btn_add_report";
            this.btn_add_report.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_add_report.Size = new System.Drawing.Size(118, 61);
            this.btn_add_report.TabIndex = 1;
            this.btn_add_report.Text = "بحث";
            this.btn_add_report.Click += new System.EventHandler(this.btn_add_report_Click);
            // 
            // chk_reportes
            // 
            this.chk_reportes.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_reportes.FormattingEnabled = true;
            this.chk_reportes.Items.AddRange(new object[] {
            "المبيعات",
            "الأرباح",
            "المنتجات الأكثر مبيعا",
            "المنتجات الأكثر إرجاعا"});
            this.chk_reportes.Location = new System.Drawing.Point(14, 42);
            this.chk_reportes.Name = "chk_reportes";
            this.chk_reportes.Size = new System.Drawing.Size(290, 32);
            this.chk_reportes.TabIndex = 0;
            this.chk_reportes.SelectedIndexChanged += new System.EventHandler(this.chk_reportes_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.panel4.Controls.Add(this.pnl_sub_lbl);
            this.panel4.Controls.Add(this.pnl_main_lbl);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 346);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1259, 104);
            this.panel4.TabIndex = 1;
            // 
            // lbl_main_content
            // 
            this.lbl_main_content.AutoSize = true;
            this.lbl_main_content.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_main_content.ForeColor = System.Drawing.Color.White;
            this.lbl_main_content.Location = new System.Drawing.Point(21, 56);
            this.lbl_main_content.Name = "lbl_main_content";
            this.lbl_main_content.Size = new System.Drawing.Size(86, 24);
            this.lbl_main_content.TabIndex = 2;
            this.lbl_main_content.Text = "0.00 دج";
            // 
            // lbl_main_title
            // 
            this.lbl_main_title.AutoSize = true;
            this.lbl_main_title.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_main_title.ForeColor = System.Drawing.Color.White;
            this.lbl_main_title.Location = new System.Drawing.Point(21, 3);
            this.lbl_main_title.Name = "lbl_main_title";
            this.lbl_main_title.Size = new System.Drawing.Size(157, 24);
            this.lbl_main_title.TabIndex = 0;
            this.lbl_main_title.Text = "المبلغ الإجمالي";
            // 
            // pnl_reports
            // 
            this.pnl_reports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_reports.Location = new System.Drawing.Point(0, 144);
            this.pnl_reports.Name = "pnl_reports";
            this.pnl_reports.Size = new System.Drawing.Size(1259, 202);
            this.pnl_reports.TabIndex = 2;
            // 
            // pnl_main_lbl
            // 
            this.pnl_main_lbl.Controls.Add(this.lbl_main_title);
            this.pnl_main_lbl.Controls.Add(this.lbl_main_content);
            this.pnl_main_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_main_lbl.Location = new System.Drawing.Point(1049, 0);
            this.pnl_main_lbl.Name = "pnl_main_lbl";
            this.pnl_main_lbl.Size = new System.Drawing.Size(210, 104);
            this.pnl_main_lbl.TabIndex = 4;
            this.pnl_main_lbl.Visible = false;
            // 
            // pnl_sub_lbl
            // 
            this.pnl_sub_lbl.Controls.Add(this.lbl_sub_content);
            this.pnl_sub_lbl.Controls.Add(this.lbl_sub_title);
            this.pnl_sub_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_sub_lbl.Location = new System.Drawing.Point(839, 0);
            this.pnl_sub_lbl.Name = "pnl_sub_lbl";
            this.pnl_sub_lbl.Size = new System.Drawing.Size(210, 104);
            this.pnl_sub_lbl.TabIndex = 5;
            this.pnl_sub_lbl.Visible = false;
            // 
            // lbl_sub_content
            // 
            this.lbl_sub_content.AutoSize = true;
            this.lbl_sub_content.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sub_content.ForeColor = System.Drawing.Color.White;
            this.lbl_sub_content.Location = new System.Drawing.Point(17, 56);
            this.lbl_sub_content.Name = "lbl_sub_content";
            this.lbl_sub_content.Size = new System.Drawing.Size(86, 24);
            this.lbl_sub_content.TabIndex = 7;
            this.lbl_sub_content.Text = "0.00 دج";
            // 
            // lbl_sub_title
            // 
            this.lbl_sub_title.AutoSize = true;
            this.lbl_sub_title.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sub_title.ForeColor = System.Drawing.Color.White;
            this.lbl_sub_title.Location = new System.Drawing.Point(17, 3);
            this.lbl_sub_title.Name = "lbl_sub_title";
            this.lbl_sub_title.Size = new System.Drawing.Size(161, 24);
            this.lbl_sub_title.TabIndex = 6;
            this.lbl_sub_title.Text = "إجمالي الصافي";
            // 
            // frm_reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 450);
            this.Controls.Add(this.pnl_reports);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "frm_reports";
            this.Text = "frm_reports";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnl_main_lbl.ResumeLayout(false);
            this.pnl_main_lbl.PerformLayout();
            this.pnl_sub_lbl.ResumeLayout(false);
            this.pnl_sub_lbl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox chk_reportes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtp_startDate;
        private System.Windows.Forms.DateTimePicker dtp_endDate;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btn_add_report;
        private DevExpress.XtraEditors.SimpleButton btn_daily;
        private DevExpress.XtraEditors.SimpleButton btn_monthly;
        private DevExpress.XtraEditors.SimpleButton btn_yearly;
        private DevExpress.XtraEditors.SimpleButton btn_weekly;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnl_reports;
        private System.Windows.Forms.Label lbl_main_title;
        private System.Windows.Forms.Label lbl_main_content;
        private System.Windows.Forms.Panel pnl_sub_lbl;
        private System.Windows.Forms.Label lbl_sub_content;
        private System.Windows.Forms.Label lbl_sub_title;
        private System.Windows.Forms.Panel pnl_main_lbl;
    }
}