namespace AutoPartsManager.Forms.Purchases
{
    partial class frm_purchases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_purchases));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(54, 170);
            this.label1.Size = new System.Drawing.Size(191, 60);
            this.label1.Text = "مشتريات";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(51, 69);
            this.pictureBox1.Size = new System.Drawing.Size(242, 102);
            // 
            // btn_discount
            // 
            this.btn_discount.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.btn_discount.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_discount.Appearance.Options.UseBackColor = true;
            this.btn_discount.Appearance.Options.UseFont = true;
            this.btn_discount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_discount.ImageOptions.Image")));
            this.btn_discount.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_discount.Visible = false;
            // 
            // lbl_discount
            // 
            this.lbl_discount.Size = new System.Drawing.Size(248, 43);
            this.lbl_discount.Text = "0.00 DZD DZD";
            // 
            // frm_purchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 1008);
            this.Name = "frm_purchases";
            this.Text = "frm_purchases";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}