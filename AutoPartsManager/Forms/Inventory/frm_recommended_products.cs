using BL;
using ClosedXML.Excel;
using DevExpress.XtraEditors;
using Moldels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Inventory
{
    public partial class frm_recommended_products : XtraForm
    {
        public frm_recommended_products()
        {
            InitializeComponent();
        }


        void LoadRecommendedProducts()
        {
            string error = string.Empty;

            var recommended = cls_bl_recomendations.GetRecommendedProducts(out error);
            if (!string.IsNullOrEmpty(error))
            {
                XtraMessageBox.Show(error);
            }
            else
            {
                dgv_inventory.Rows.Clear();
                foreach (var product in recommended)
                {
                    object imageValue = null;
                    if (product.AlreadyRecomended)
                    {
                        // ضع هنا صورة من الموارد أو ملف
                        imageValue = Properties.Resources.check; // مثال: صورة علامة صح من Resources
                    }
                    else
                    {

                        imageValue = Properties.Resources.close__2_;
                    }


                    dgv_inventory.Rows.Add
                            (
                           product.ID,
                           product.Reference,
                           product.ProductName,
                           product.ProductBrand,
                           product.Quantity,
                           imageValue,
                           Properties.Resources.bin
                            );
                }
            }


        }


        private void dgv_inventory_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_inventory.CurrentCell.ColumnIndex == dgv_inventory.Columns["Quantity"].Index) // عمود Quantity
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= Tb_KeyPress; // لتجنب تكرار الحدث
                    tb.KeyPress += Tb_KeyPress;
                }
            }
        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح فقط بالأرقام و backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void SetupDataGridView()
        {
            // افترض أن dgv_inventory موجود بالفعل
            foreach (DataGridViewColumn col in dgv_inventory.Columns)
            {
                if (col.Name == "Quantity")
                    col.ReadOnly = false; // السماح بالتحرير
                else
                    col.ReadOnly = true;  // منع التحرير
            }
        }

        // افترض أن عمود الحذف هو العمود الأخير في dgv_inventory
        private void dgv_inventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // تأكد أن المستخدم ضغط داخل الصف وليس على رأس العمود
            if (e.RowIndex >= 0)
            {
                // افحص إذا العمود هو عمود الحذف (مثلاً العمود الأخير)
                if (dgv_inventory.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                    e.ColumnIndex == dgv_inventory.Columns["Delete"].Index) // غيّر "DeleteColumn" باسم العمود الفعلي
                {
                    int productId = Convert.ToInt32(dgv_inventory.Rows[e.RowIndex].Cells["ID"].Value);
                    string error = string.Empty;

                    bool success = cls_bl_recomendations.DeleteRecommendedProduct(productId, out error);
                    if (!success)
                    {
                        XtraMessageBox.Show("حدث خطأ أثناء الحذف: " + error);
                    }
                    else
                    {
                        // إزالة الصف من DataGridView بعد الحذف
                        dgv_inventory.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }



        private void frm_recommended_products_Load(object sender, EventArgs e)
        {
            dgv_inventory.EditingControlShowing += dgv_inventory_EditingControlShowing;
            LoadRecommendedProducts();
            SetupDataGridView();

        }

        private void dgv_inventory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgv_inventory.Columns[e.ColumnIndex].Name == "Quantity")
            {
                string value = e.FormattedValue.ToString().Trim();

                // إذا كانت الخلية فارغة
                if (string.IsNullOrEmpty(value))
                {
                    dgv_inventory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    return;
                }

                // إذا لم تكن رقمًا
                if (!int.TryParse(value, out _))
                {
                    e.Cancel = true;
                    MessageBox.Show("Quantity must be a number");
                }
            }
        }

        private void dgv_inventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_inventory.Columns[e.ColumnIndex].Name == "Quantity")
            {
                var cell = dgv_inventory.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    cell.Value = 0;
                }
            }
        }


        public static void ExportInventoryToExcel(DataGridView dgv_inventory)
        {
            if (dgv_inventory.Rows.Count == 0)
                return;

            // تحقق من وجود أي كمية > 0
            bool hasQuantity = dgv_inventory.Rows
                                .Cast<DataGridViewRow>()
                                .Any(row => !row.IsNewRow && Convert.ToInt32(row.Cells["Quantity"].Value ?? 0) > 0);

            if (!hasQuantity)
            {
                MessageBox.Show("يرجى إدخال كمية أكبر من الصفر على الأقل لمنتج واحد.",
                                "تنبيه",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = "Inventory.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Inventory");

                    int colIndex = 1;

                    // 🔹 Headers (تجاهل الأعمدة من نوع Image)
                    foreach (DataGridViewColumn col in dgv_inventory.Columns)
                    {
                        if (col is DataGridViewImageColumn)
                            continue;
                        if (col.Name == "ID") continue;


                        ws.Cell(1, colIndex).Value = col.HeaderText;
                        ws.Cell(1, colIndex).Style.Font.Bold = true;
                        colIndex++;
                    }

                    int rowIndex = 2;

                    foreach (DataGridViewRow row in dgv_inventory.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                        if (quantity <= 0) continue;

                        colIndex = 1;

                        foreach (DataGridViewColumn col in dgv_inventory.Columns)
                        {
                            if (col is DataGridViewImageColumn)
                                continue;
                            if (col.Name == "ID") continue;

                            var cell = ws.Cell(rowIndex, colIndex);
                            object value = row.Cells[col.Index].Value;

                            if (col.Name == "Quantity")
                            {
                                cell.Value = quantity;
                            }
                            else if (col.Name == "Price")
                            {
                                cell.Value = Convert.ToDecimal(value ?? 0);
                                cell.Style.NumberFormat.Format = "#,##0.00";
                            }
                            else
                            {
                                cell.Value = value?.ToString() ?? "";
                            }

                            colIndex++;
                        }

                        rowIndex++;
                    }

                    ws.Columns().AdjustToContents();
                    workbook.SaveAs(sfd.FileName);
                }

                // اخبر المستخدم بمكان الملف
                DialogResult result = MessageBox.Show(
                    "تم تصدير المخزون إلى Excel بنجاح ✅\nهل تريد فتح موقع الملف؟",
                    "Export",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    // فتح موقع الملف في File Explorer
                    string argument = "/select, \"" + sfd.FileName + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
            }
        }

        void UpdateRecommendedProducts()
        {
            string error = string.Empty;
            var products = new List<cls_ml_Products>();
            foreach (DataGridViewRow row in dgv_inventory.Rows)
            {
                if (row.IsNewRow) continue;
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                if (quantity <= 0) continue;
                int ID = Convert.ToInt32(row.Cells["ID"].Value);
                cls_ml_Products product = new cls_ml_Products()
                {
                    ID = ID,
                    AlreadyRecomended = true,
                    Quantity = quantity
                };
                products.Add(product);
            }
            if (!cls_bl_recomendations.UpdateRecommendedProduct(products, out error))
            {
                XtraMessageBox.Show(error);
            }
        }
        private void btn_export_excel_Click(object sender, EventArgs e)
        {
            UpdateRecommendedProducts();
            ExportInventoryToExcel(dgv_inventory);
            LoadRecommendedProducts();
        }

        private void btn_add_recomended_product_Click(object sender, EventArgs e)
        {
            frm_add_updat_products recomended = new frm_add_updat_products(true);
            recomended.ShowDialog();
            if (recomended.add_or_update_product)
            {
                LoadRecommendedProducts();
            }
        }
    }
}
