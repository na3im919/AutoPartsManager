namespace AutoPartsManager.Forms.Clients
{
    partial class frm_add_update_client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_add_update_client));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txt_name = new DevExpress.XtraEditors.TextEdit();
            this.layctrl_name = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layctrl_phone = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.layctrl_address = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layctrl_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layctrl_phone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layctrl_address)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_name);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Location = new System.Drawing.Point(18, 16);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(765, 225);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layctrl_name,
            this.layctrl_phone,
            this.layctrl_address});
            this.Root.MoveFocusRightToLeft = DevExpress.Utils.DefaultBoolean.True;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(765, 225);
            this.Root.TextVisible = false;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(12, 12);
            this.txt_name.Name = "txt_name";
            this.txt_name.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Properties.Appearance.Options.UseFont = true;
            this.txt_name.Size = new System.Drawing.Size(603, 36);
            this.txt_name.StyleController = this.layoutControl1;
            this.txt_name.TabIndex = 4;
            // 
            // layctrl_name
            // 
            this.layctrl_name.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layctrl_name.AppearanceItemCaption.Options.UseFont = true;
            this.layctrl_name.Control = this.txt_name;
            this.layctrl_name.Location = new System.Drawing.Point(0, 0);
            this.layctrl_name.Name = "layctrl_name";
            this.layctrl_name.Size = new System.Drawing.Size(745, 40);
            this.layctrl_name.Text = "إسم الزبون";
            this.layctrl_name.TextSize = new System.Drawing.Size(126, 29);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(12, 52);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new System.Drawing.Size(603, 36);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 5;
            // 
            // layctrl_phone
            // 
            this.layctrl_phone.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layctrl_phone.AppearanceItemCaption.Options.UseFont = true;
            this.layctrl_phone.Control = this.textEdit1;
            this.layctrl_phone.Location = new System.Drawing.Point(0, 40);
            this.layctrl_phone.Name = "layctrl_phone";
            this.layctrl_phone.Size = new System.Drawing.Size(745, 40);
            this.layctrl_phone.Text = "رقم الهاتف";
            this.layctrl_phone.TextSize = new System.Drawing.Size(126, 29);
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(12, 92);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Size = new System.Drawing.Size(603, 36);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 6;
            // 
            // layctrl_address
            // 
            this.layctrl_address.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layctrl_address.AppearanceItemCaption.Options.UseFont = true;
            this.layctrl_address.Control = this.textEdit2;
            this.layctrl_address.Location = new System.Drawing.Point(0, 80);
            this.layctrl_address.Name = "layctrl_address";
            this.layctrl_address.Size = new System.Drawing.Size(745, 125);
            this.layctrl_address.Text = "العنوان";
            this.layctrl_address.TextSize = new System.Drawing.Size(126, 29);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 247);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 203);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(88, 70);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(216, 102);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "إضافة زبون";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(330, 70);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(216, 102);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "إلغاء";
            // 
            // frm_add_update_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_add_update_client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_add_update_client";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layctrl_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layctrl_phone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layctrl_address)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txt_name;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layctrl_name;
        private DevExpress.XtraLayout.LayoutControlItem layctrl_phone;
        private DevExpress.XtraLayout.LayoutControlItem layctrl_address;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}