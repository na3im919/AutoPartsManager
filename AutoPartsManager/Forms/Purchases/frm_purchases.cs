using ClosedXML.Excel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using BL;


namespace AutoPartsManager.Forms.Purchases
{
    public partial class frm_purchases : frm_sales
    {
        protected override string InvoiceType => "شراء";
        protected override bool AllowDiscount => false;
        private ContextMenuStrip dgvContextMenu;

        public frm_purchases()
        {
           //InitializeComponent();
           btn_discount.Click -= btn_discount_Click;
            btn_discount.Click += BtnDiscountForSuppliers_Click;
            SetupDgvContextMenu();
            ConfigureFormForType();

        }


        private void SetupDgvContextMenu()
        {
            dgvContextMenu = new ContextMenuStrip();
            var exportItem = new ToolStripMenuItem("تصدير ملف Excel فارغ");
            exportItem.Click += ExportEmptyExcel_Click;
            dgvContextMenu.Items.Add(exportItem);

            dgv_invoice_list.ContextMenuStrip = dgvContextMenu;
        }


        protected override void ConfigureFormForType()
        {
            base.ConfigureFormForType();

            label1.Text = "إدارة المشتريات";
            label1.Location = new Point(5, 115);
            pictureBox1.Image = Properties.Resources.purchasing__1_;
            label2.Visible = false;
            lbl_discount.Visible = false;

            if (dgv_invoice_list.Columns.Contains("Reference"))
                dgv_invoice_list.Columns["Reference"].Visible = true;

            if(dgv_invoice_list.Columns.Contains("ProductBrand"))
                dgv_invoice_list.Columns["ProductBrand"].Visible = true;
        }

        protected override void AddSelectedProductToInvoice()
        {
            if (dgv_suggest.SelectedRows.Count == 0) return;

            var row = dgv_suggest.SelectedRows[0];
            int productId = Convert.ToInt32(row.Cells["ID"].Value);
            string productName = row.Cells["ProductName"].Value.ToString();
            decimal cost = Convert.ToDecimal(row.Cells["Cost"].Value);
            string productReference = row.Cells["Reference"].Value.ToString();
            string productBrand = row.Cells["ProductBrand"].Value.ToString();

            // بالنسبة للمشتريات لا نتحقق من الكمية المتاحة
            foreach (DataGridViewRow invoiceRow in dgv_invoice_list.Rows)
            {
                if (Convert.ToInt32(invoiceRow.Cells["ID"].Value) == productId)
                {
                    int currentQty = Convert.ToInt32(invoiceRow.Cells["Quantity"].Value);
                    invoiceRow.Cells["Quantity"].Value = currentQty + 1;
                    invoiceRow.Cells["Total"].Value = (currentQty + 1) * cost;
                    ApplyDiscountAndCalculateTotal();
                    txtSearch.Clear();
                    dgv_suggest.Visible = false;
                    return;
                }
            }

            // إضافة المنتج جديد في القائمة
            dgv_invoice_list.Rows.Add(productId, productReference, productName, productBrand, 1, cost, cost);
            txtSearch.Clear();
            dgv_suggest.Visible = false;
            ApplyDiscountAndCalculateTotal();
        }

        private void ImportProductsFromExcel(string filePath)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var ws = workbook.Worksheet(1);
                var rows = ws.RowsUsed().Skip(1);

                dgv_invoice_list.Rows.Clear();

                foreach (var row in rows)
                {
                    string reference = row.Cell(1).GetValue<string>().Trim();
                    string name = row.Cell(2).GetValue<string>();
                    string brand = row.Cell(3).GetValue<string>();
                    int quantity = row.Cell(4).GetValue<int>();
                    decimal price = row.Cell(5).GetValue<decimal>();
                    decimal total = quantity * price;

                    int productId = cls_bl_Products.GetProductIdByReference(reference);

                    int rowIndex = dgv_invoice_list.Rows.Add();

                    var dgvRow = dgv_invoice_list.Rows[rowIndex];

                    dgvRow.Cells["ID"].Value = productId == -1 ? -1 : productId;
                    dgvRow.Cells["Reference"].Value = reference;
                    dgvRow.Cells["ProductName"].Value = name;
                    dgvRow.Cells["ProductBrand"].Value = brand;
                    dgvRow.Cells["Quantity"].Value = quantity;
                    dgvRow.Cells["Price"].Value = price;
                    dgvRow.Cells["Total"].Value = total;

                    dgvRow.Cells["IsNew"].Value = productId == -1;

                    // تمييز بصري (اختياري)
                    if (productId == -1)
                        dgvRow.DefaultCellStyle.BackColor = Color.LightYellow;
                }

                ApplyDiscountAndCalculateTotal();
            }
        }

        public static void CreateEmptyExcelFile(string filePath)
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Products");

                // إضافة الأعمدة
                ws.Cell(1, 1).Value = "كود المنتج";
                ws.Cell(1, 2).Value = "إسم المنتج";
                ws.Cell(1, 3).Value = "العلامة التجارية";
                ws.Cell(1, 4).Value = "الكمية";
                ws.Cell(1, 5).Value = "السعر";

                // ضبط عرض الأعمدة
                ws.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }

        protected override void btn_edit_quantity_Click(object sender, EventArgs e)
        {
            if (dgv_invoice_list.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgv_invoice_list.SelectedRows[0];
            int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);

            // للشراء، الحد الأقصى يمكن أن يكون مفتوحًا أو رقم كبير جدًا
            int maxQty = int.MaxValue;

            frm_quantity qForm = new frm_quantity { CurrentQuantity = currentQty, MaxQuantity = maxQty };
            qForm.ShowDialog();
            if (!qForm.IsConfirmed) return;

            int newQty = qForm.NewQuantity;

            row.Cells["Quantity"].Value = newQty;
            row.Cells["Total"].Value = newQty * Convert.ToDecimal(row.Cells["Price"].Value);

            // نحسب المجموع بعد التعديل
            ApplyDiscountAndCalculateTotal();
        }

        private void BtnDiscountForSuppliers_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xlsx";
                ofd.Title = "اختر ملف المنتجات بعد تعبئته";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ImportProductsFromExcel(ofd.FileName);
                }
            }
        }

        public static void ExportEmptyExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "اختر مكان حفظ ملف المنتجات الفارغ";
                sfd.FileName = "Products.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;

                    CreateEmptyExcelFile(filePath);

                    XtraMessageBox.Show(
                        "تم إنشاء ملف Excel فارغ.\nيمكنك الآن تعبئته بالمنتجات.",
                        "تم بنجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // فتح موقع الملف
                    string folderPath = Path.GetDirectoryName(filePath);
                    Process.Start("explorer.exe", folderPath);
                }
            }
        }
        private void frm_purchases_Load(object sender, EventArgs e)
        {
        }

    }
}
