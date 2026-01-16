using AutoPartsManager.Forms.Inventory;
using AutoPartsManager.Forms.Sales;
using BL;
using DevExpress.XtraEditors;
using Moldels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AutoPartsManager.Forms
{
    public partial class frm_sales : XtraForm
    {
        private decimal _invoiceDiscountAmount = 0;
        private bool HasDiscount => _invoiceDiscountAmount > 0;

      

        private int NewProductsNumber = 0;
        protected virtual string InvoiceType => "بيع";
        protected virtual bool AllowDiscount => true;

        public frm_sales()
        {
            InitializeComponent();
            this.KeyPreview = true;

            this.Focus();
        }

        // ===== طرق قابلة للوراثة =====
        protected virtual bool SaveInvoice(cls_ml_Invoices invoice, List<cls_ml_InvoiceDetail> details, out string errorMessage)
        {
            return cls_bl_Invoices.AddInvoice(invoice, details, out errorMessage);
        }

        protected virtual void ConfigureFormForType()
        {
            // الافتراضي (Sales)
        }

        protected virtual void UpdateStockAfterSave(List<cls_ml_InvoiceDetail> details)
        {
            // البيع: يتم إنقاص الكمية داخل BL
        }

        protected virtual cls_ml_Invoices PrepareInvoice(int Client_SupplierID, string PaymentMethod, decimal discount)
        {
            int clientID = -1;
            int supplierID = -1;

            if(InvoiceType == "بيع")
            {
                clientID = Client_SupplierID;
            }
            else
            {
                supplierID = Client_SupplierID;
            }

            return new cls_ml_Invoices
            {
                Date = DateTime.Now,
                TotalAmount = GetCurrentGrandTotal(),
                DiscountAmount = discount,
                ClientID = clientID,
                SupplierID = supplierID,
                InvoiceType = InvoiceType,
                PaymentMethod = PaymentMethod
            };
        }

        private List<cls_ml_InvoiceDetail> PrepareInvoicesDetails()
        {
            List<cls_ml_InvoiceDetail> list = new List<cls_ml_InvoiceDetail>();
            NewProductsNumber = 0;

            foreach (DataGridViewRow row in dgv_invoice_list.Rows)
            {
                if (row.IsNewRow) continue;

                // Price
                decimal unitPrice = 0;
                if (row.Cells["Price"].Value != null)
                    decimal.TryParse(row.Cells["Price"].Value.ToString(), out unitPrice);

                // Cost
                decimal cost = 0;
                if (row.Cells["Cost"].Value != null)
                    decimal.TryParse(row.Cells["Cost"].Value.ToString(), out cost);

                // Quantity
                int quantity = 0;
                if (row.Cells["Quantity"].Value != null)
                    int.TryParse(row.Cells["Quantity"].Value.ToString(), out quantity);

                // Discount
                decimal discountAmount = 0;
                if (row.Cells["Discount"].Value != null)
                    decimal.TryParse(row.Cells["Discount"].Value.ToString(), out discountAmount);

                // IsNew
                bool isNew = false;
                if (row.Cells["IsNew"].Value != null)
                    bool.TryParse(row.Cells["IsNew"].Value.ToString(), out isNew);

                if (isNew) NewProductsNumber++;

                list.Add(new cls_ml_InvoiceDetail
                {
                    ProductID = Convert.ToInt32(row.Cells["ID"].Value),
                    ProductName = row.Cells["ProductName"].Value?.ToString(),
                    Reference = row.Cells["Reference"].Value?.ToString(),
                    ProductBrand = row.Cells["ProductBrand"].Value?.ToString(),
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    Cost = cost,
                    DiscountAmount = discountAmount,
                    IsNewProduct = isNew
                });
            }

            return list;
        }

        public void ResetForm()
        {
            txtSearch.Text = string.Empty;
            dgv_suggest.Visible = false;
        }



        // ===== إعداد DataGridViews =====
        private void SetupSuggestionDataGridView()
        {
            dgv_suggest.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv_suggest.RowHeadersVisible = false;
            dgv_suggest.ColumnHeadersVisible = false;
            dgv_suggest.ReadOnly = true;
            dgv_suggest.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_suggest.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_suggest.AutoGenerateColumns = false;
            dgv_suggest.Columns.Clear();

            dgv_suggest.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", DataPropertyName = "ID", HeaderText = "ID", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgv_suggest.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductName", DataPropertyName = "ProductName", HeaderText = "اسم المنتج", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgv_suggest.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", DataPropertyName = "Price", HeaderText = "السعر", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgv_suggest.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cost", DataPropertyName = "Cost", HeaderText = "سعر الشراء", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgv_suggest.Columns.Add(new DataGridViewTextBoxColumn { Name = "Reference", DataPropertyName = "Reference", HeaderText = "كود المنتج", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgv_suggest.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductBrand", DataPropertyName = "ProductBrand", HeaderText = "العلامة التجارية", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } });


            dgv_suggest.BackgroundColor = Color.White;
            dgv_suggest.DefaultCellStyle.BackColor = Color.White;
            dgv_suggest.DefaultCellStyle.ForeColor = Color.FromArgb(52, 58, 64);
            dgv_suggest.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dgv_suggest.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv_suggest.Location = new Point(txtSearch.Left, txtSearch.Bottom);
            dgv_suggest.Width = txtSearch.Width;
            dgv_suggest.Height = 200;
            dgv_suggest.Visible = false;
        }

        protected virtual void SetupDataGridView()

        {
            dgv_invoice_list.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv_invoice_list.RowHeadersVisible = false;
            dgv_invoice_list.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgv_invoice_list.Font = new Font("Segoe UI", 20, FontStyle.Regular);

            // إضافة أعمدة موجودة بالفعل (ID, ProductName, Price, Quantity, Total...)
            // ...

            // 🔹 عمود خصم لكل سطر
            if (!dgv_invoice_list.Columns.Contains("Discount"))
            {
                DataGridViewTextBoxColumn discountColumn = new DataGridViewTextBoxColumn();
                discountColumn.Name = "Discount";
                discountColumn.HeaderText = "خصم";
                discountColumn.ValueType = typeof(decimal);
                discountColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                discountColumn.DefaultCellStyle.Format = "N2";
                discountColumn.Width = 100;
                dgv_invoice_list.Columns.Add(discountColumn);
            }
        }


        // ===== خصم =====
        protected void ApplyDiscountAndCalculateTotal()
        {
            decimal grandTotal = 0;
            decimal totalDiscount = 0;

            foreach (DataGridViewRow row in dgv_invoice_list.Rows)
            {
                if (row.IsNewRow) continue;

                decimal lineTotal = 0;
                decimal discount = 0;
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                if (row.Cells["Total"].Value != null)
                    lineTotal = Convert.ToDecimal(row.Cells["Total"].Value);
                if (row.Cells["Discount"].Value != null)
                    discount = Convert.ToDecimal(row.Cells["Discount"].Value) * qty;

                grandTotal += lineTotal;
                totalDiscount += discount;
            }

            lbl_total.Text = grandTotal.ToString("N2") + " DZD";
            lbl_discount.Text = totalDiscount.ToString("N2") + " DZD";
        }

        private void CancelDiscount()
        {
            _invoiceDiscountAmount = 0; // إلغاء الخصم
            ApplyDiscountAndCalculateTotal(); // تحديث lbl_discount و lbl_total تلقائيًا
        }

        // ===== العمليات على الفاتورة =====
        protected decimal GetCurrentGrandTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgv_invoice_list.Rows)
            {
                if (row.IsNewRow) continue;

                decimal lineTotal = 0;
                decimal unitPrice = Convert.ToDecimal(row.Cells["Price"].Value);
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal discount = Convert.ToDecimal(row.Cells["Discount"].Value ?? 0);

                lineTotal = (unitPrice * qty);
                total += lineTotal;
            }
            return total;
        }

        protected void DeleteSelectedProductFromInvoice()
        {
            if (dgv_invoice_list.SelectedRows.Count == 0) return;
            dgv_invoice_list.Rows.Remove(dgv_invoice_list.SelectedRows[0]);
            ApplyDiscountAndCalculateTotal();
        }

        protected void ClearInvoiceList()
        {
            dgv_invoice_list.Rows.Clear();
            CancelDiscount();
        }

        protected virtual void AddSelectedProductToInvoice()
        {
            if (dgv_suggest.SelectedRows.Count == 0) return;

            var row = dgv_suggest.SelectedRows[0];
            int productId = Convert.ToInt32(row.Cells["ID"].Value);
            string productName = row.Cells["ProductName"].Value.ToString();
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
            decimal cost = Convert.ToDecimal(row.Cells["Cost"].Value);

            string error;
            int availableQty = cls_bl_Products.GetAvailableQuantity(productId, out error);
            if (!string.IsNullOrEmpty(error)) { MessageBox.Show(error); return; }

            foreach (DataGridViewRow invoiceRow in dgv_invoice_list.Rows)
            {
                if (Convert.ToInt32(invoiceRow.Cells["ID"].Value) == productId)
                {
                    int currentQty = Convert.ToInt32(invoiceRow.Cells["Quantity"].Value);
                    if (currentQty >= availableQty) 
                    {   
                        MessageBox.Show($"وصلت إلى الحد الأقصى: {availableQty}"); 
                        return; 
                    }
                    invoiceRow.Cells["Quantity"].Value = currentQty + 1;
                    invoiceRow.Cells["Total"].Value = (currentQty + 1) * price;
                    ApplyDiscountAndCalculateTotal();
                    txtSearch.Clear();
                    dgv_suggest.Visible = false;
                    return;
                }
            }

            if (availableQty <= 0) { MessageBox.Show("لا توجد كمية متاحة!"); return; }

            dgv_invoice_list.Rows.Add(productId, "",  productName, "", 1, "", price, price);
            txtSearch.Clear();
            dgv_suggest.Visible = false;
            ApplyDiscountAndCalculateTotal();
        }

        private void RecalculateRow(DataGridViewRow row)
        {
            if (row.Cells["Price"].Value == null || row.Cells["Quantity"].Value == null)
                return;

            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
            int qty = Convert.ToInt32(row.Cells["Quantity"].Value);

            decimal discount = 0;
            if (row.Cells["Discount"].Value != null)
                decimal.TryParse(row.Cells["Discount"].Value.ToString(), out discount);

            if (discount > price)
                discount = price;

            row.Cells["Total"].Value = qty * (price - discount);
        }


        // ===== Event Handlers للأزرار =====
        private void btn_add_invoice_Click(object sender, EventArgs e)
        {
            if (dgv_invoice_list.Rows.Count <= 0) return;

            frm_add_invoice invoiceForm = new frm_add_invoice(GetCurrentGrandTotal(), decimal.Parse(lbl_discount.Text.Split(' ')[0]), InvoiceType);
            invoiceForm.ShowDialog();
            if (!invoiceForm.IsApproved) return;
            cls_ml_Invoices invoice = new cls_ml_Invoices();
            if (InvoiceType == "بيع" )
            {
                invoice = PrepareInvoice(invoiceForm.ClientID, invoiceForm.PaymentMethod, decimal.Parse(lbl_discount.Text.Split(' ')[0]));
            }
            else
            {
               invoice = PrepareInvoice(invoiceForm.SupplierID, invoiceForm.PaymentMethod, decimal.Parse(lbl_discount.Text.Split(' ')[0]));

            }
                List<cls_ml_InvoiceDetail> details = PrepareInvoicesDetails();

            string error;
            if (SaveInvoice(invoice, details, out error))
            {
                XtraMessageBox.Show("تمت إضافة الفاتورة بنجاح");
                ClearInvoiceList();
                if (NewProductsNumber > 0)
                    XtraMessageBox.Show($"تمت إضافة {NewProductsNumber} منتجات جديدة يرجى التعديل على أسعار البيع", "منتجات جديدة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("فشل في إضافة الفاتورة\n" + error);
            }
        }

        private void btn_delete_product_Click(object sender, EventArgs e) => DeleteSelectedProductFromInvoice();
        private void btn_clear_invoice_Click(object sender, EventArgs e) => ClearInvoiceList();
        protected void btn_discount_Click(object sender, EventArgs e)
        {
            if (dgv_invoice_list.SelectedRows.Count == 0)
                return;

            var row = dgv_invoice_list.SelectedRows[0];

            frm_discount discountForm = new frm_discount
            {
                ProductName = row.Cells["ProductName"].Value.ToString(),
                currentDiscount = row.Cells["Discount"].Value?.ToString() ?? "0"
            };

            discountForm.ShowDialog();

            if (discountForm.IsConfirmed)
                row.Cells["Discount"].Value = discountForm.DiscountValue;
            else if (discountForm.IsDeleted)
                row.Cells["Discount"].Value = 0;

            RecalculateRow(row);
            ApplyDiscountAndCalculateTotal();
        }

        protected virtual void btn_edit_quantity_Click(object sender, EventArgs e)
        {
            if (dgv_invoice_list.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgv_invoice_list.SelectedRows[0];
            int productId = Convert.ToInt32(row.Cells["ID"].Value);
            int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);
            string error;
            int maxQty = cls_bl_Products.GetAvailableQuantity(productId, out error);
            if (!string.IsNullOrEmpty(error)) { MessageBox.Show(error); return; }

            frm_quantity qForm = new frm_quantity { CurrentQuantity = currentQty, MaxQuantity = maxQty };
            qForm.ShowDialog();
            if (!qForm.IsConfirmed) return;

            int newQty = qForm.NewQuantity;
            if (newQty > maxQty) { MessageBox.Show($"وصلت إلى الحد الأقصى: {maxQty}"); return; }

            row.Cells["Quantity"].Value = newQty;
            row.Cells["Total"].Value = newQty * Convert.ToDecimal(row.Cells["Price"].Value);
            ApplyDiscountAndCalculateTotal();
        }

        // ===== Key Events =====
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

            // ===== Add Invoice F10 =====
            if (e.KeyCode == Keys.F10)
            {
                // تحقق أن الفوكس ليس داخل txtSearch
                //if (txtSearch.Focused)
                //    return;
                btn_add_invoice_Click(null, null); // نعيد استخدام كود زر إضافة الفاتورة
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
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
            if (e.KeyCode == Keys.F3 && InvoiceType == "بيع")
            {
                // لا نفتح الخصم إذا المستخدم يكتب في البحث
                if (dgv_invoice_list.Rows.Count <= 0)
                {
                     return;
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
        private void frm_sales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.ActiveControl == txtSearch) return;
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (searchTerm.Length >= 1)
            {
                string errorMessage;
                List<cls_ml_Products> results = cls_bl_Products.SearchForProducts(searchTerm, InvoiceType, out errorMessage);

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
            lbl_discount.Text = lbl_discount.Text;
            ConfigureFormForType();
  

        SetupSuggestionDataGridView();
            SetupDataGridView();
            //btn_discount.Visible = AllowDiscount;

            if(!AllowDiscount)
            {
                btn_discount.Name = "btn_buy_from_excel";
                btn_discount.BackColor = Color.FromArgb(51, 51, 51);
                btn_discount.Text = "إستيراد إكسل";
                btn_discount.ImageOptions.Image = Properties.Resources.logo;
            }
        }


        private void dgv_invoice_list_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgv_invoice_list.Rows[e.RowIndex];

            // تحديث Total (قبل الخصم)
            if (row.Cells["Price"].Value != null && row.Cells["Quantity"].Value != null)
            {
                decimal unitPrice = Convert.ToDecimal(row.Cells["Price"].Value);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                row.Cells["Total"].Value = unitPrice * quantity;
            }

            // تحديث الخصم لكل صف
            if (dgv_invoice_list.Columns[e.ColumnIndex].Name == "Discount")
            {
                decimal discountPerUnit = 0;

                // التأكد من الرقم
                if (row.Cells["Discount"].Value == null || !decimal.TryParse(row.Cells["Discount"].Value.ToString(), out discountPerUnit))
                    discountPerUnit = 0;

                decimal unitPrice = Convert.ToDecimal(row.Cells["Price"].Value);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                // الخصم لا يتجاوز سعر الوحدة
                if (discountPerUnit > unitPrice)
                    discountPerUnit = unitPrice;

                // حساب الإجمالي بعد الخصم لكل صف
                row.Cells["Total"].Value = quantity * (unitPrice - discountPerUnit);

                // تخزين الخصم لكل وحدة (اختياري، حسب حاجتك)
                // row.Cells["DiscountPerUnit"].Value = discountPerUnit;

                ApplyDiscountAndCalculateTotal();
            }
        }


    }
}
