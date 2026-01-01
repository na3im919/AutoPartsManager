using AutoPartsManager.Forms;
using AutoPartsManager.Forms.Inventory;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.Design.MaskSettingsForm.DesignInfo.MaskManagerInfo;

namespace AutoPartsManager
{
    public partial class frm_main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private Timer lowQuantityTimer;

        public frm_main()
        {
            InitializeComponent();
            accordionControl1.ElementClick += AccordionControl_ElementClick;

        }

        // في أعلى كلاس frm_main
        private Dictionary<string, Form> OpenedForms = new Dictionary<string, Form>();


        private void AccordionControl_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {
            if(e.Element == null || e.Element.Tag == null)
                return;
            string frm = e.Element.Tag.ToString();

            OpenFormsFrom(frm);
        }
        public void OpenFormsFrom(string formName)
        {
            if (OpenedForms.ContainsKey(formName))
            {
                Form existingForm = OpenedForms[formName];

                // إخفاء كل الفورمات الأخرى
                foreach (Control ctrl in fluentDesignFormContainer1.Controls)
                {
                    ctrl.Visible = false;
                }

                // إذا لم يكن موجودًا داخل الـ container، أضفه
                if (!fluentDesignFormContainer1.Controls.Contains(existingForm))
                {
                    fluentDesignFormContainer1.Controls.Add(existingForm);
                    existingForm.Dock = DockStyle.Fill;
                }

                existingForm.Visible = true;
                existingForm.BringToFront();

                // إذا كان الفورم يحتوي على دالة ResetForm (مثل frm_sales)
                MethodInfo resetMethod = existingForm.GetType().GetMethod("ResetForm");
                if (resetMethod != null)
                {
                    resetMethod.Invoke(existingForm, null);
                }


                // ✅ اجعل الفورم الحالي في التركيز
                existingForm.Focus();
            }
            else
            {
                var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == formName);
                if (type != null)
                {
                    Form frm = (Form)Activator.CreateInstance(type);
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;

                    // إخفاء كل الفورمات الأخرى
                    foreach (Control ctrl in fluentDesignFormContainer1.Controls)
                    {
                        ctrl.Visible = false;
                    }

                    fluentDesignFormContainer1.Controls.Add(frm);
                    fluentDesignFormContainer1.Tag = frm;

                    OpenedForms.Add(formName, frm);
                    frm.Show();
                    MethodInfo resetMethod = frm.GetType().GetMethod("ResetForm");

                    if (resetMethod != null)
                    {
                        resetMethod.Invoke(frm, null);
                    }

                    // اجعل الفورم الجديد في التركيز
                    frm.Focus();
                }
                else
                {
                    XtraMessageBox.Show($"النموذج '{formName}' غير موجود!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            lowQuantityTimer = new Timer();
            lowQuantityTimer.Interval = 2 * 60 * 60 * 1000; // ساعتان
            lowQuantityTimer.Tick += LowQuantityTimer_Tick;
            lowQuantityTimer.Start();

            LowQuantitiesChecker.NotifyOfLowQuantities();
            OpenFormsFrom("frm_sales");
        }

        private void LowQuantityTimer_Tick(object sender, EventArgs e)
        {
            LowQuantitiesChecker.NotifyOfLowQuantities();
        }


        public Form GetOpenedForm(string formName)
        {
            return OpenedForms.ContainsKey(formName)
                ? OpenedForms[formName]
                : null;
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            frm_DBManagement frm_DBManagement = new frm_DBManagement();
            frm_DBManagement.ShowDialog();
        }
    }
}
