using BL;
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
    public partial class frm_add_updat_products : XtraForm
    {
        private int _productId;
        public bool add_or_update_product = false;
        private enum frmMode
        {
            Add,
            Update
        }
        frmMode Mode;

        public frm_add_updat_products()
        {
            InitializeComponent();
            Mode = frmMode.Add;
            SetupNumericInputs();
        }
        public frm_add_updat_products(int productId)
        {
            InitializeComponent();
            _productId = productId;
            Mode = frmMode.Update;
        }


        private bool ValidateProductInputs()
        {
            bool isValid = true;

            // مسح الأخطاء السابقة
            txt_name.ErrorText = string.Empty;
            txt_cost.ErrorText = string.Empty;
            txt_price.ErrorText = string.Empty;
            txt_qty.ErrorText = string.Empty;
            txt_qty_min.ErrorText = string.Empty;

            // اسم المنتج
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                txt_name.ErrorText = "اسم المنتج إجباري";
                isValid = false;
            }

            // سعر التكلفة
            decimal cost = 0;
            if (string.IsNullOrWhiteSpace(txt_cost.Text))
            {
                txt_cost.ErrorText = "سعر التكلفة إجباري";
                isValid = false;
            }
            else if (!decimal.TryParse(txt_cost.Text, out cost) || cost < 0)
            {
                txt_cost.ErrorText = "الرجاء إدخال رقم صحيح ≥ 0";
                isValid = false;
            }

            // سعر البيع
            decimal price = 0;
            if (string.IsNullOrWhiteSpace(txt_price.Text))
            {
                txt_price.ErrorText = "سعر البيع إجباري";
                isValid = false;
            }
            else if (!decimal.TryParse(txt_price.Text, out price) || price < 0)
            {
                txt_price.ErrorText = "الرجاء إدخال رقم صحيح ≥ 0";
                isValid = false;
            }

            // تحقق أن التكلفة ≤ السعر
            if (cost > 0 && price > 0 && cost >= price)
            {
                txt_price.ErrorText = "سعر البيع يجب أن يكون أكبر من سعر التكلفة";
                isValid = false;
            }

            // الكمية
            int qty = 0;
            if (string.IsNullOrWhiteSpace(txt_qty.Text))
            {
                txt_qty.ErrorText = "الكمية إجبارية";
                isValid = false;
            }
            else if (!int.TryParse(txt_qty.Text, out qty) || qty < 0)
            {
                txt_qty.ErrorText = "الرجاء إدخال رقم صحيح ≥ 0";
                isValid = false;
            }

            // الحد الأدنى للكمية
            int minQty = 0;
            if (string.IsNullOrWhiteSpace(txt_qty_min.Text))
            {
                txt_qty_min.ErrorText = "الحد الأدنى للكمية إجباري";
                isValid = false;
            }
            else if (!int.TryParse(txt_qty_min.Text, out minQty) || minQty < 0)
            {
                txt_qty_min.ErrorText = "الرجاء إدخال رقم صحيح موجب ";
                isValid = false;
            }

            return isValid;
        }

        private void SetupNumericInputs()
        {
            // سعر التكلفة (رقم عشري)
            txt_cost.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_cost.Properties.Mask.EditMask = "n2";
            txt_cost.Properties.Mask.UseMaskAsDisplayFormat = true;

            // سعر البيع (رقم عشري)
            txt_price.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_price.Properties.Mask.EditMask = "n2";
            txt_price.Properties.Mask.UseMaskAsDisplayFormat = true;

            // الكمية (عدد صحيح)
            txt_qty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_qty.Properties.Mask.EditMask = "n0";
            txt_qty.Properties.Mask.UseMaskAsDisplayFormat = true;

            // الحد الأدنى للكمية (عدد صحيح)
            txt_qty_min.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_qty_min.Properties.Mask.EditMask = "n0";
            txt_qty_min.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void getProductDetails(int productId)
        {
            string error_message = string.Empty;
            cls_ml_Products product = cls_bl_Products.GetProductInfoByID(productId, out error_message);
            if (product == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(error_message))
            {
                XtraMessageBox.Show(error_message);
                return;
            }
            txt_name.Text = product.ProductName;
            txt_reffrence.Text = product.Reference;
            txt_brand.Text = product.ProductBrand;
            txt_cost.Text = product.Cost.ToString();
            txt_price.Text = product.Price.ToString();
            txt_qty.Text = product.Quantity.ToString();
            txt_qty_min.Text = product.min_quantity.ToString();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_add_updat_products_Load(object sender, EventArgs e)
        {
            this.Text = Mode == frmMode.Add ? "إضافة منتج جديد" : "تعديل بيانات المنتج";
            btn_save.ImageOptions.Image = Mode == frmMode.Add ? Properties.Resources.box : Properties.Resources.updated;
            
            if (Mode == frmMode.Update)
                getProductDetails(_productId);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string error_message = string.Empty;
            cls_ml_Products newProduct = new cls_ml_Products()
            {
                Reference = txt_reffrence.Text,
                ProductName = txt_name.Text,
                ProductBrand = txt_brand.Text,
                Cost = Convert.ToDecimal(txt_cost.Text),
                Price = Convert.ToDecimal(txt_price.Text),
                Quantity = Convert.ToInt32(txt_qty.Text),
                min_quantity = Convert.ToInt32(txt_qty_min.Text),


            };
            if (ValidateProductInputs())
            {
                if (Mode == frmMode.Update)
                {
                    newProduct.ID = _productId;
                    if (cls_bl_Products.UpdateProductStock(newProduct, out error_message))
                    {
                        XtraMessageBox.Show("تم تحديث بيانات المنتج بنجاح", "تحديث منتج", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        add_or_update_product = true;
                        this.Close();
                    }
                }
                else
                {
                    if (cls_bl_Products.AddProductStock(newProduct, out error_message))
                    {
                        XtraMessageBox.Show("تمت إضافة المنتج بنجاح", "إضافة منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        add_or_update_product = true;
                        this.Close();
                    }
                }
                if (!string.IsNullOrEmpty(error_message))
                {
                    XtraMessageBox.Show(error_message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
                
        }
    }
}
