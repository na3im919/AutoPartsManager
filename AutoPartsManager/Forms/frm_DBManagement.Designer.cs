namespace AutoPartsManager.Forms
{
    partial class frm_DBManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DBManagement));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnResetDB = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackupDB = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestoreDB = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(135)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 69);
            this.panel1.TabIndex = 0;
            // 
            // btnResetDB
            // 
            this.btnResetDB.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnResetDB.ImageOptions.Image")));
            this.btnResetDB.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnResetDB.Location = new System.Drawing.Point(56, 109);
            this.btnResetDB.Name = "btnResetDB";
            this.btnResetDB.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnResetDB.Size = new System.Drawing.Size(186, 90);
            this.btnResetDB.TabIndex = 1;
            this.btnResetDB.Click += new System.EventHandler(this.btnResetDB_Click);
            // 
            // btnBackupDB
            // 
            this.btnBackupDB.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBackupDB.ImageOptions.Image")));
            this.btnBackupDB.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBackupDB.Location = new System.Drawing.Point(282, 109);
            this.btnBackupDB.Name = "btnBackupDB";
            this.btnBackupDB.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBackupDB.Size = new System.Drawing.Size(186, 90);
            this.btnBackupDB.TabIndex = 2;
            this.btnBackupDB.Click += new System.EventHandler(this.btnBackupDB_Click);
            // 
            // btnRestoreDB
            // 
            this.btnRestoreDB.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRestoreDB.ImageOptions.Image")));
            this.btnRestoreDB.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRestoreDB.Location = new System.Drawing.Point(509, 109);
            this.btnRestoreDB.Name = "btnRestoreDB";
            this.btnRestoreDB.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnRestoreDB.Size = new System.Drawing.Size(186, 90);
            this.btnRestoreDB.TabIndex = 3;
            this.btnRestoreDB.Click += new System.EventHandler(this.btnRestoreDB_Click);
            // 
            // frm_DBManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 236);
            this.Controls.Add(this.btnRestoreDB);
            this.Controls.Add(this.btnBackupDB);
            this.Controls.Add(this.btnResetDB);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_DBManagement";
            this.Text = "frm_DBManagement";
            this.Load += new System.EventHandler(this.frm_DBManagement_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnResetDB;
        private DevExpress.XtraEditors.SimpleButton btnBackupDB;
        private DevExpress.XtraEditors.SimpleButton btnRestoreDB;
    }
}