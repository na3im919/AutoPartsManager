using BL;
using DevExpress.XtraEditors;
using Moldels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Inventory
{
    public partial class frm_inventory : XtraForm
    {
        string Keyword = string.Empty;
        bool ActiveOnly = true;
        bool ZeroQtyOnly = false;
        public frm_inventory()
        {
            InitializeComponent();
        }

        private void GetTotalQuantity()
        {
            int total = 0;
            if(dgv_inventory.Rows.Count == 0)
            {
                lbl_products_number.Text = "0";
                return;
            }

            foreach (DataGridViewRow row in dgv_inventory.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["Quantity"].Value != null)
                {
                    int qty;
                    if (int.TryParse(row.Cells["Quantity"].Value.ToString(), out qty))
                    {
                        total += qty;
                    }
                }
            }

            lbl_products_number.Text = total.ToString();
        }

        private string FormatDZD(decimal amount, bool withDecimals = false)
        {
            return "دج " + amount.ToString(withDecimals ? "N2" : "N0");
        }

        private void GetTotalPrice()
        {
            decimal total_price = 0;
            
            foreach (DataGridViewRow row in dgv_inventory.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["Quantity"].Value != null &&
                   decimal.TryParse(row.Cells["Quantity"].Value.ToString(), out decimal qty))
                {
                    if (row.Cells["Price"].Value != null &&
                   decimal.TryParse(row.Cells["Price"].Value.ToString(), out decimal price))
                    {
                        price *= qty;
                        total_price += price;
                    }
                }

               
            }

            //CultureInfo dzCulture = new CultureInfo("fr-DZ");
            //dzCulture.NumberFormat.CurrencySymbol = "دج";

            lbl_total_price.Text = FormatDZD(total_price);
        }

        private void GetTotalCost()
        {
            decimal total_cost = 0;

            foreach (DataGridViewRow row in dgv_inventory.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["Quantity"].Value != null &&
                   decimal.TryParse(row.Cells["Quantity"].Value.ToString(), out decimal qty))
                {
                    if (row.Cells["Cost"].Value != null &&
                   decimal.TryParse(row.Cells["Cost"].Value.ToString(), out decimal cost))
                    {
                        cost *= qty;
                        total_cost += cost;
                    }
                }


            }

            //CultureInfo dzCulture = new CultureInfo("fr-DZ");
            //dzCulture.NumberFormat.CurrencySymbol = "دج";

            lbl_total_cost.Text = FormatDZD(total_cost);
        }


        public void SetupGridView(DataGridView gridView)
        {
            // Example setup code for the DataGridView
            gridView.AutoGenerateColumns = false;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.MultiSelect = false;
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.Font = new Font("Segoe UI", 16);
            
        }

        private void LoadInventoryList()
        {
            string error_message = string.Empty;

            List<cls_ml_Products> products =
                cls_bl_Products.GetAllProducts(Keyword, ActiveOnly, ZeroQtyOnly, out error_message);

            // في حال وجود خطأ
            if (!string.IsNullOrEmpty(error_message))
            {
                MessageBox.Show(error_message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgv_inventory.Rows.Clear();

            if (products == null || products.Count == 0)
            {
                GetTotalQuantity();
                GetTotalPrice();
                GetTotalCost();
                return;
            }

            foreach (var product in products)
            {
                dgv_inventory.Rows.Add(
                    product.ID,
                    product.Reference,
                    product.ProductName,
                    product.ProductBrand,
                    product.Cost,
                    product.Price,
                    product.Quantity,
                    Properties.Resources.edit__1_,    // عمود Edit
                    Properties.Resources.bin, // عمود Delete
                    Properties.Resources._return
                );
            }
            GetTotalQuantity();
            GetTotalPrice();
            GetTotalCost();
        }



        private void frm_inventory_Load(object sender, EventArgs e)
        {
            SetupGridView(dgv_inventory);

            LoadInventoryList();
            InventoryListButtonsManager(ActiveOnly);
            rad_non_zero.Checked = true;
        }


        private void InventoryListButtonsManager(bool isActiveProducts )
        {
            if(isActiveProducts)
            {
                dgv_inventory.Columns["Delete"].Visible = true;
                dgv_inventory.Columns["Edit"].Visible = true;
                dgv_inventory.Columns["Restore"].Visible = false;
            }
            else
            {
                dgv_inventory.Columns["Delete"].Visible = false;
                dgv_inventory.Columns["Edit"].Visible = false;
                dgv_inventory.Columns["Restore"].Visible = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Keyword = txtSearch.Text.Trim();
            LoadInventoryList();
        }

        private void dgv_inventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName = dgv_inventory.Columns[e.ColumnIndex].Name;

            // نتحقق فقط من أعمدة الأزرار
            if (columnName != "Delete" && columnName != "Restore" && columnName != "Edit")
                return;

            int productId = Convert.ToInt32(
                dgv_inventory.Rows[e.RowIndex].Cells["ID"].Value
            );

            switch (columnName)
            {
                case "Delete":
                    string deleteError = string.Empty;
                    DialogResult confirmResult = MessageBox.Show(
                        "هل أنت متأكد من رغبتك في حذف هذا المنتج؟",
                        "تأكيد الحذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (confirmResult != DialogResult.Yes)
                        return;

                    bool deleteSuccess = cls_bl_Products.DeactivateProduct(productId, out deleteError);
                    if (!deleteSuccess)
                    {
                        MessageBox.Show(
                            deleteError,
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }
                    else
                    {
                        LoadInventoryList();
                    }
                    break;

                case "Restore":
                    string restoreError = string.Empty;
                    DialogResult restoreConfirmResult = MessageBox.Show(
                        "هل أنت متأكد من رغبتك في استعادة هذا المنتج؟",
                        "تأكيد الاستعادة",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (restoreConfirmResult != DialogResult.Yes)
                        return;
                    bool restoreSuccess = cls_bl_Products.SetActive(productId, out restoreError);
                    if (!restoreSuccess)
                        {
                        MessageBox.Show(
                            restoreError,
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }
                    else
                    {
                        LoadInventoryList();
                    }
                        break;

                case "Edit":
                    // TODO: سيتم تنفيذ منطق التعديل لاحقًا
                    MessageBox.Show(
                        "منطق التعديل سيتم تنفيذه لاحقًا",
                        "معلومة",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    break;
            }
        }


        private void chk_non_active_product_CheckedChanged(object sender, EventArgs e)
        {
            ActiveOnly = !chk_non_active_product.Checked;
            label1.Text = chk_non_active_product.Checked ? "عدد المنتجات المحذوفة:" : "عدد المنتجات :";
            panel7.Width = chk_non_active_product.Checked ? 150 : 80;
            (pnl_total_price.Visible, pnl_total_cost.Visible) = (!chk_non_active_product.Checked, !chk_non_active_product.Checked);
            groupBox1.Enabled = !chk_non_active_product.Checked;
            if (chk_non_active_product.Checked)
            {
                ZeroQtyOnly = false;
                rad_non_zero.Checked = true;
            }
            LoadInventoryList();
            InventoryListButtonsManager(ActiveOnly);
        }

        private void rad_zero_CheckedChanged(object sender, EventArgs e)
        {
            ZeroQtyOnly = rad_zero.Checked;
            LoadInventoryList();
        }
    }
}
