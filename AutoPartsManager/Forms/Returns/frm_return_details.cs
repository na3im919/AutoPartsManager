// Forms/Returns/frm_return_details.cs
using Moldels;
using BL;
using DevExpress.XtraEditors;
using Moldels.ML_Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Returns
{
    public partial class frm_return_details : XtraForm
    {
        private readonly int _invoiceId;
        private string _invoiceType;
        private List<ReturnProductModel> _products;

        public frm_return_details(int invoiceId)
        {
            InitializeComponent();
            _invoiceId = invoiceId;
        }

        private void frm_return_details_Load(object sender, EventArgs e)
        {
            LoadInvoiceData();
            SetupDataGridView();
            LoadProducts();
        }

        private void LoadInvoiceData()
        {
            string error;
            var invoiceInfo = cls_bl_Returns.GetInvoiceInfo(_invoiceId, out error);

            if (!string.IsNullOrEmpty(error) || invoiceInfo == null)
            {
                MessageBox.Show("حدث خطأ عند جلب بيانات الفاتورة: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            _invoiceType = invoiceInfo.Item1;
            this.Text = $"تفاصيل مرتجع - {_invoiceType} رقم {_invoiceId} - {invoiceInfo.Item2}";
        }

        private void SetupDataGridView()
        {
            // إضافة الأعمدة يدوياً للتحكم الكامل
            dgv_products.AutoGenerateColumns = false;

            // عمود الاختيار
            dgv_products.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsSelected",
                HeaderText = "اختر",
                Width = 50,
                // ربط العمود بالخاصية في النموذج
                DataPropertyName = "IsSelected"
            });

            // عمود رقم المنتج (مخفي)
            dgv_products.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductID",
                HeaderText = "رقم المنتج",
                DataPropertyName = "ProductID" // ربط العمود بالخاصية
            });
            dgv_products.Columns["ProductID"].Visible = false;

            // عمود اسم المنتج
            dgv_products.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "اسم المنتج",
                DataPropertyName = "ProductName", // ربط العمود بالخاصية
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // عمود السعر
            dgv_products.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "السعر",
                DataPropertyName = "Price" // ربط العمود بالخاصية
            });

            // عمود الكمية في الفاتورة
            dgv_products.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InvoiceQuantity",
                HeaderText = "الكمية في الفاتورة",
                DataPropertyName = "InvoiceQuantity" // ربط العمود بالخاصية
            });

            // عمود الكمية المرتجعة سابقاً
            dgv_products.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReturnedQuantity",
                HeaderText = "الكمية المرتجعة سابقاً",
                DataPropertyName = "ReturnedQuantity" // ربط العمود بالخاصية
            });

            // عمود الكمية المرتجعة حالياً
            dgv_products.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReturnQuantity",
                HeaderText = "الكمية المرتجعة حالياً",
                DataPropertyName = "ReturnQuantity" // ربط العمود بالخاصية
            });

            // لم نعد بحاجة لهذا السطر لأننا حددنا AutoSizeMode للأعمدة
            // dgv_products.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadProducts()
        {
            string error;
            _products = cls_bl_Returns.GetInvoiceProductsForReturn(_invoiceId, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("حدث خطأ عند جلب بيانات المنتجات: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgv_products.DataSource = _products;
            CustomizeHeaders();
        }

        private void CustomizeHeaders()
        {
            dgv_products.Columns["ProductName"].HeaderText = "اسم المنتج";
            dgv_products.Columns["Price"].HeaderText = _invoiceType == "شراء" ? "التكلفة" : "السعر بعد الخصم";
            dgv_products.Columns["InvoiceQuantity"].HeaderText = "الكمية في الفاتورة";
            dgv_products.Columns["ReturnedQuantity"].HeaderText = "الكمية المرتجعة سابقاً";
            dgv_products.Columns["ReturnQuantity"].HeaderText = "الكمية المرتجعة حالياً";

            dgv_products.Columns["Price"].DefaultCellStyle.Format = "F2";
            dgv_products.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            // تحضير قائمة المنتجات التي سيتم إرجاعها
            var productsToSave = _products
    .Where(p => p.IsSelected && p.ReturnQuantity > 0)
    .Select(p => new ReturnDetailToSave
    {
        ProductID = p.ProductID,
        ProductPrice = p.Price,
        Quantity = p.ReturnQuantity,
        InvoiceDetailID = p.InvoiceDetailID // الآن هذه القيمة متوفرة مباشرة
    })
    .ToList();

            string error;
            bool success = cls_bl_Returns.SaveNewReturn(_invoiceId, productsToSave, out error);

            if (success)
            {
                MessageBox.Show("تم حفظ بيانات المرتجعات بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(error, "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
       

        private bool ValidateData()
        {
            if (!_products.Any(p => p.IsSelected))
            {
                MessageBox.Show("يرجى اختيار منتج واحد على الأقل للإرجاع", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (var product in _products.Where(p => p.IsSelected))
            {
                if (product.ReturnQuantity <= 0)
                {
                    MessageBox.Show($"يرجى تحديد كمية صالحة للإرجاع للمنتج: {product.ProductName}", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (product.ReturnQuantity > product.AvailableReturnQuantity)
                {
                    MessageBox.Show($"الكمية المرتجعة للمنتج {product.ProductName} ({product.ReturnQuantity}) تتجاوز الكمية المتاحة ({product.AvailableReturnQuantity})", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // أحداث DataGridView للتحقق من صحة الإدخال
        private void dgv_products_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != dgv_products.Columns["ReturnQuantity"].Index || e.RowIndex < 0) return;

            if (!int.TryParse(e.FormattedValue.ToString(), out int value) || value < 0)
            {
                dgv_products.Rows[e.RowIndex].ErrorText = "يرجى إدخال قيمة عددية صحيحة موجبة";
                e.Cancel = true;
            }
            else
            {
                var product = _products[e.RowIndex];
                if (value > product.AvailableReturnQuantity)
                {
                    dgv_products.Rows[e.RowIndex].ErrorText = $"الكمية المتاحة للإرجاع: {product.AvailableReturnQuantity}";
                    e.Cancel = true;
                }
                else
                {
                    dgv_products.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }


        // هذا الحدث يتم تشغيله عندما يحاول المستخدم البدء في تحرير خلية
        private void dgv_products_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // اسمح بالتحرير لعمودي "IsSelected" و "ReturnQuantity"
            string columnName = dgv_products.Columns[e.ColumnIndex].Name;
            if (columnName != "IsSelected" && columnName != "ReturnQuantity")
            {
                // إذا لم يكن العمود هو "IsSelected" أو "ReturnQuantity"، ألغ عملية التحرير
                e.Cancel = true;
                return;
            }

            // إذا كان العمود هو "ReturnQuantity"، تحقق مما إذا كان الصف محدداً
            if (columnName == "ReturnQuantity")
            {
                var isSelectedCell = dgv_products.Rows[e.RowIndex].Cells["IsSelected"] as DataGridViewCheckBoxCell;

                // إذا كان الصف غير محدد، ألغ عملية التحرير
                if (isSelectedCell == null || Convert.ToBoolean(isSelectedCell.Value) == false)
                {
                    e.Cancel = true;
                }
            }
            // إذا كان العمود هو "IsSelected"، لا تفعل شيئاً واسمح بالتحرير
        }
        // هذا الحدث يتم تشغيله بعد تغيير قيمة أي خلية (مثل تحديد/إلغاء تحديد المربع)
        private void dgv_products_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // نحن مهتمون فقط بالتغييرات في عمود "IsSelected"
            if (e.ColumnIndex == dgv_products.Columns["IsSelected"].Index && e.RowIndex >= 0)
            {
                // تحديث قيمة النموذج المرتبط بالـ DataGridView
                var product = _products[e.RowIndex];
                product.IsSelected = Convert.ToBoolean(dgv_products.Rows[e.RowIndex].Cells["IsSelected"].Value);

                // إجبار الـ DataGridView على إعادة رسم الصف ليعكس حالة التحرير الجديدة
                dgv_products.InvalidateRow(e.RowIndex);
            }
        }
    }
}