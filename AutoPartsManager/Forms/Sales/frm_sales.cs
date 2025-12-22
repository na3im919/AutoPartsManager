using BL;
using DevExpress.XtraEditors;
using Moldels; // تأكد من صحة اسم الـ namespace للـ Models
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AutoPartsManager.Forms.frm_discount;


namespace AutoPartsManager.Forms
{
    public partial class frm_sales : XtraForm
    {

        private decimal _currentDiscount = 0m;
        private bool _hasDiscount = false;
        decimal _currentDiscountValue;  // قيمة الخصم (للمبلغ الثابت)
        decimal _currentDiscountPercentage; // نسبة الخصم (0 - 100)
        bool _isPercentageDiscount = false;
        


        public frm_sales()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }


        private void SetupSuggestionDataGridView()
        {
            dgv_suggest.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv_suggest.RowHeadersVisible = false;
            dgv_suggest.ColumnHeadersVisible = false;
            dgv_suggest.ReadOnly = true;
            dgv_suggest.AllowUserToAddRows = false;
            dgv_suggest.AllowUserToDeleteRows = false;
            dgv_suggest.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_suggest.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_suggest.AutoGenerateColumns = false;
            dgv_suggest.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            dgv_suggest.Width = txtSearch.Width * 2;


            //عمود id المنتج
            DataGridViewTextBoxColumn productIDColumn = new DataGridViewTextBoxColumn();
            productIDColumn.DataPropertyName = "ID"; // *** تم التغيير من "ProductName" إلى "Name" ***
            productIDColumn.HeaderText = "ID";
            productIDColumn.Name = "ID";
            //productIDColumn.Visible = false;
            productIDColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_suggest.Columns.Add(productIDColumn);



            // عمود اسم المنتج
            DataGridViewTextBoxColumn productNameColumn = new DataGridViewTextBoxColumn();
            productNameColumn.DataPropertyName = "ProductName"; // *** تم التغيير من "ProductName" إلى "Name" ***
            productNameColumn.HeaderText = "اسم المنتج";
            productNameColumn.Name = "ProductName";
            productNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_suggest.Columns.Add(productNameColumn);

            // عمود السعر
            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "Price"; // *** تم التغيير من "Price" إلى "Price" (لكن للتأكيد) ***
            priceColumn.HeaderText = "السعر";
            priceColumn.Name = "Price";
            priceColumn.Width = 100;
            priceColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            priceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_suggest.Columns.Add(priceColumn);

            // ضبط الألوان
            dgv_suggest.BackgroundColor = ColorTranslator.FromHtml("#FFFFFF");
            dgv_suggest.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            dgv_suggest.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#343A40");
            dgv_suggest.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4682B4");
            dgv_suggest.DefaultCellStyle.SelectionForeColor = Color.White;

            // ضبط موقع dgv_suggest تحت txtSearchProduct
            // تأكد من أن dgv_suggest و txtSearchProduct يقعان في نفس الحاوية
            dgv_suggest.Location = new Point(txtSearch.Left, txtSearch.Bottom);
            dgv_suggest.Width = txtSearch.Width;
            dgv_suggest.Height = 200;
        }

        private void SetupDataGridView()
        {



            // 1. إخفاء جميع الحدود الافتراضية
            dgv_invoice_list.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv_invoice_list.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_invoice_list.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // 2. إخفاء رؤوس الصفوف إذا لم تكن بحاجة لها (العمود الأقصى يساراً الذي يحوي أرقام الصفوف)
            dgv_invoice_list.RowHeadersVisible = false;

            // 3. تأكد من أن الخلفية ليست شفافة لتجنب مشاكل الرسم
            //dgv_invoice_list.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48); // أو أي لون خلفية لخلايا البيانات
            //dgv_invoice_list.DefaultCellStyle.ForeColor = Color.White; // أو أي لون خلفية لخلايا البيانات

            dgv_invoice_list.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray; // لون خلفية لرؤوس الأعمدة
            dgv_invoice_list.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            foreach (DataGridViewColumn col in dgv_invoice_list.Columns)
            {
                col.DefaultCellStyle.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            }


        }

        private void ApplyDiscountAndCalculateTotal()
        {
            decimal grandTotal = GetCurrentGrandTotal();
            decimal discountAmount = 0m;

            if (_hasDiscount)
            {
                if (_isPercentageDiscount)
                {
                    // نحسب الخصم دائمًا بناءً على المجموع الحالي
                    discountAmount = grandTotal * (_currentDiscountPercentage / 100);
                }
                else
                {
                    // الخصم ثابت
                    discountAmount = _currentDiscountValue;
                }

                // لا يتجاوز المجموع
                if (discountAmount > grandTotal)
                    discountAmount = grandTotal;
            }

            lbl_discount.Text = discountAmount.ToString("N2") + " DZD";
            lbl_total.Text = (grandTotal - discountAmount).ToString("N2") + " DZD";
        }




        private void CancelDiscount()
        {
            if (!_hasDiscount)
                return;

            _currentDiscount = 0;
            _hasDiscount = false;

            decimal grandTotal = GetCurrentGrandTotal();

            lbl_discount.Text = "0.00 DZD";
            lbl_total.Text = grandTotal.ToString("N2") + " DZD";
        }

        private decimal GetCurrentGrandTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgv_invoice_list.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    decimal rowTotal;
                    if (decimal.TryParse(row.Cells["Total"].Value.ToString(), out rowTotal))
                    {
                        total += rowTotal;
                    }
                }
            }

            return total;
        }

        private void DeleteSelectedProductFromInvoice()
        {
            if (dgv_invoice_list.SelectedRows.Count == 0)
                return;

            // حذف الصف المحدد
            dgv_invoice_list.Rows.Remove(dgv_invoice_list.SelectedRows[0]);

            // إعادة حساب المجموع الكلي بعد الحذف
            ApplyDiscountAndCalculateTotal();
        }

        private void ClearInvoiceList()
        {
            dgv_invoice_list.Rows.Clear();
            CancelDiscount();
            // تصفير الإجمالي
            lbl_total.Text = "0.00 DZD";
        }


        private void AddSelectedProductToInvoice()
        {
            if (dgv_suggest.SelectedRows.Count == 0)
                return;

            var selectedRow = dgv_suggest.SelectedRows[0];
            int productId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            string productName = selectedRow.Cells["ProductName"].Value.ToString();
            decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);

            // جلب الكمية المتاحة من قاعدة البيانات
            string error;
            int availableQty = cls_bl_Products.GetAvailableQuantity(productId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("حدث خطأ أثناء جلب الكمية: " + error);
                return;
            }

            // التحقق إذا كان المنتج موجود مسبقًا في dgv_invoice_list
            foreach (DataGridViewRow row in dgv_invoice_list.Rows)
            {
                if (Convert.ToInt32(row.Cells["ID"].Value) == productId)
                {
                    int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);

                    if (currentQty >= availableQty)
                    {
                        MessageBox.Show($"وصلت إلى الحد الأقصى المتاح من هذا المنتج!\nالكمية المتاحة: {availableQty}",
                                        "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgv_suggest.Visible = false;
                        txtSearch.Clear();
                        return;
                    }

                    row.Cells["Quantity"].Value = currentQty + 1;
                    row.Cells["Total"].Value = (currentQty + 1) * price;
                    ApplyDiscountAndCalculateTotal();
                    txtSearch.Clear();
                    dgv_suggest.Visible = false;
                    return;
                }
            }

            // إذا لم يكن موجود، أضفه كصف جديد
            if (availableQty <= 0)
            {
                MessageBox.Show("لا توجد كمية متاحة من هذا المنتج!");
                return;
            }

            dgv_invoice_list.Rows.Add(productId, productName, 1, price, price);
            txtSearch.Clear();
            dgv_suggest.Visible = false;

            ApplyDiscountAndCalculateTotal();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (searchTerm.Length >= 1)
            {
                string errorMessage;
                List<cls_ml_Products> results = cls_bl_Products.SearchForProducts(searchTerm, out errorMessage);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (results.Any())
                    {
                        dgv_suggest.DataSource = results;
                        dgv_suggest.Visible = true;
                        dgv_suggest.Height = Math.Min(results.Count * dgv_suggest.RowTemplate.Height + (dgv_suggest.ColumnHeadersVisible ? dgv_suggest.ColumnHeadersHeight : 0), 200);

                        if (dgv_suggest.Rows.Count > 0)
                        {
                            dgv_suggest.ClearSelection();
                            dgv_suggest.Rows[0].Selected = true;
                            dgv_suggest.CurrentCell = dgv_suggest.Rows[0].Cells[0];
                        }
                    }
                    else
                    {
                        dgv_suggest.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء البحث عن المنتجات: " + errorMessage, "خطأ في قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgv_suggest.Visible = false;
                }
            }
            else
            {
                dgv_suggest.Visible = false;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // التنقل في الاقتراحات إذا كانت ظاهرة
            if (dgv_suggest.Visible && dgv_suggest.Rows.Count > 0)
            {
                int rowIndex = dgv_suggest.CurrentCell?.RowIndex ?? 0;

                if (e.KeyCode == Keys.Down)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    rowIndex = (rowIndex < dgv_suggest.Rows.Count - 1) ? rowIndex + 1 : 0;
                    dgv_suggest.ClearSelection();
                    dgv_suggest.Rows[rowIndex].Selected = true;
                    dgv_suggest.CurrentCell = dgv_suggest.Rows[rowIndex].Cells[0];
                }
                else if (e.KeyCode == Keys.Up)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    rowIndex = (rowIndex > 0) ? rowIndex - 1 : dgv_suggest.Rows.Count - 1;
                    dgv_suggest.ClearSelection();
                    dgv_suggest.Rows[rowIndex].Selected = true;
                    dgv_suggest.CurrentCell = dgv_suggest.Rows[rowIndex].Cells[0];
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    AddSelectedProductToInvoice();
                    ApplyDiscountAndCalculateTotal();
                }
            }
            // إذا الاقتراحات غير ظاهرة وهنالك منتجات في الفاتورة
            else if (dgv_invoice_list.Rows.Count > 0)
            {
                int firstVisibleColumnIndex = -1;
                foreach (DataGridViewColumn col in dgv_invoice_list.Columns)
                {
                    if (col.Visible)
                    {
                        firstVisibleColumnIndex = col.Index;
                        break;
                    }
                }

                if (firstVisibleColumnIndex < 0)
                    return; // لا يوجد عمود ظاهر

                int rowIndex = dgv_invoice_list.CurrentCell?.RowIndex ?? 0;

                if (e.KeyCode == Keys.Down)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    rowIndex = (rowIndex < dgv_invoice_list.Rows.Count - 1) ? rowIndex + 1 : 0;
                    dgv_invoice_list.ClearSelection();
                    dgv_invoice_list.Rows[rowIndex].Selected = true;
                    dgv_invoice_list.CurrentCell = dgv_invoice_list.Rows[rowIndex].Cells[firstVisibleColumnIndex];
                }
                else if (e.KeyCode == Keys.Up)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    rowIndex = (rowIndex > 0) ? rowIndex - 1 : dgv_invoice_list.Rows.Count - 1;
                    dgv_invoice_list.ClearSelection();
                    dgv_invoice_list.Rows[rowIndex].Selected = true;
                    dgv_invoice_list.CurrentCell = dgv_invoice_list.Rows[rowIndex].Cells[firstVisibleColumnIndex];
                }
            }
        }

        private void dgv_suggest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AddSelectedProductToInvoice();
                ApplyDiscountAndCalculateTotal();
            }
        }

        private void frm_sales_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            ApplyDiscountAndCalculateTotal();
            lbl_discount.Text = lbl_discount.Text + " DZD";

            SetupSuggestionDataGridView();
            SetupDataGridView();
        }

        private void btn_delete_product_Click(object sender, EventArgs e)
        {
            DeleteSelectedProductFromInvoice();
            ApplyDiscountAndCalculateTotal();
        }

        private void btn_clear_invoice_Click(object sender, EventArgs e)
        {
            ClearInvoiceList();
        }

        private void btn_discount_Click(object sender, EventArgs e)
        {
            decimal grandTotal = GetCurrentGrandTotal();
            if (grandTotal <= 0)
                return;

            frm_discount frm = new frm_discount();
            frm.GrandTotal = GetCurrentGrandTotal();
            frm.ShowDialog();

            if (frm.IsCanceled)
            {
                CancelDiscount();
                return;
            }

            if (frm.IsConfirmed)
            {
                _hasDiscount = true;

                if (frm.SelectedDiscountType == frm_discount.DiscountType.Percentage)
                {
                    _isPercentageDiscount = true;
                    _currentDiscountPercentage = frm.DiscountValue; // القيمة كنسبة مئوية
                }
                else
                {
                    _isPercentageDiscount = false;
                    _currentDiscountValue = frm.DiscountValue; // القيمة ثابتة
                }

                ApplyDiscountAndCalculateTotal();
            }

        }



        

        private void frm_sales_KeyPress(object sender, KeyPressEventArgs e)
        {
            // إذا كان المستخدم يكتب أصلًا داخل txtSearch → لا تتدخل
            if (this.ActiveControl == txtSearch)
                return;

            // السماح فقط بالحروف والأرقام
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == ' ')
            {
                txtSearch.Focus();
                // لا تكتب الحرف يدويًا ❌
                // النظام سيكتبه تلقائيًا
                e.Handled = false;
            }
        }


        private void frm_sales_KeyDown(object sender, KeyEventArgs e)
        {

            // ===== Delete Product Shortcut =====
            if (e.KeyCode == Keys.Delete)
            {
                // إذا المؤشر داخل مربع البحث لا نحذف
                //if (txtSearch.Focused)
                //    return;

                // إذا يوجد صف محدد في الفاتورة
                if (dgv_invoice_list.Focused || dgv_invoice_list.SelectedRows.Count > 0)
                {
                    DeleteSelectedProductFromInvoice();

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
            }

            // ===== Clear Invoice (Ctrl + C) =====
            if (e.Control && e.KeyCode == Keys.C)
            {
                // لا نمسح إذا المستخدم يكتب في البحث
                //if (txtSearch.Focused)
                //    return;

                ClearInvoiceList();

                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            // ===== Edit Quantity (F4) =====
            if (e.KeyCode == Keys.F4)
            {
                // تحقق أن الفوكس ليس داخل txtSearch
                //if (txtSearch.Focused)
                //    return;

                // تحقق أن هناك صف محدد في dgv_invoice_list
                if (dgv_invoice_list.SelectedRows.Count > 0)
                {
                    btn_edit_quantity_Click(null, null); // نعيد استخدام كود زر تعديل الكمية
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
            }



            // ===== Discount (F3) =====
            if (e.KeyCode == Keys.F3)
            {
                // لا نفتح الخصم إذا المستخدم يكتب في البحث
                if (txtSearch.Focused && txtSearch.Text.Length > 0)
                {
                    // اختياري: اسمح أو امنع حسب رغبتك
                    // return;
                }

                btn_discount_Click(null, null);

                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }


            // لا تتدخل إذا المستخدم يكتب داخل txtSearch
            if (txtSearch.Focused)
                return;

            // تجاهل الاختصارات (Ctrl / Alt)
            if (e.Control || e.Alt)
                return;

            // حروف وأرقام
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) ||
                (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                txtSearch.Focus();

                char c = Convert.ToChar(e.KeyCode);

                // تحويل صحيح للأرقام والحروف
                if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                    c = (char)('0' + (e.KeyCode - Keys.D0));
                else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                    c = (char)('0' + (e.KeyCode - Keys.NumPad0));

                txtSearch.AppendText(c.ToString());

                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            // Backspace من أي مكان
            if (e.KeyCode == Keys.Back)
            {
                txtSearch.Focus();
                if (txtSearch.Text.Length > 0)
                {
                    txtSearch.Text = txtSearch.Text.Substring(0, txtSearch.Text.Length - 1);
                    txtSearch.SelectionStart = txtSearch.Text.Length;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }



          

        }

        private void btn_edit_quantity_Click(object sender, EventArgs e)
        {
            if (dgv_invoice_list.SelectedRows.Count == 0)
                return;

            DataGridViewRow selectedRow = dgv_invoice_list.SelectedRows[0];
            int productId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            int currentQty = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

            // جلب الكمية المتاحة من قاعدة البيانات
            string error;
            int availableQty = cls_bl_Products.GetAvailableQuantity(productId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("حدث خطأ أثناء جلب الكمية: " + error);
                return;
            }

            frm_quantity qForm = new frm_quantity();
            qForm.CurrentQuantity = currentQty;
            qForm.MaxQuantity = availableQty; // نرسل الكمية المتاحة إلى frm_quantity
            qForm.ShowDialog();

            if (qForm.IsConfirmed)
            {
                int newQty = qForm.NewQuantity;

                if (newQty > availableQty)
                {
                    MessageBox.Show($"وصلت إلى الحد الأقصى المتاح من هذا المنتج!\nالكمية المتاحة: {availableQty}",
                                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // يبقى قيمة textbox كما هي
                }

                // تحديث الكمية في DataGridView
                selectedRow.Cells["Quantity"].Value = newQty;

                // تحديث المجموع الجزئي للصف
                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                selectedRow.Cells["Total"].Value = newQty * price;

                // تحديث المجموع الكلي
                ApplyDiscountAndCalculateTotal();
            }
        }

    }
}