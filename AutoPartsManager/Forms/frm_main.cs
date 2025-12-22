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
        public void OpenFormsFrom(string Name)
        {
           
            // تحقق مما إذا كان الفورم مفتوحًا بالفعل
            if (OpenedForms.ContainsKey(Name))
            {
                // إذا كان مفتوحًا، فقط قم بعرضه
                Form existingForm = OpenedForms[Name];
                existingForm.BringToFront(); // إحضاره إلى المقدمة
            }
            else
            {
                // إذا لم يكن مفتوحًا، قم بإنشائه كما فعلت سابقًا
                var ins = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == Name);
                if (ins != null)
                {
                    Form frm = (Form)Activator.CreateInstance(ins);
                    if (fluentDesignFormContainer1.Controls.Count > 0)
                        fluentDesignFormContainer1.Controls.Clear();

                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    frm.TopLevel = false;
                    this.fluentDesignFormContainer1.Controls.Add(frm);
                    this.fluentDesignFormContainer1.Tag = frm;

                    // أضف الفورم الجديد إلى القاموس قبل عرضه
                    OpenedForms.Add(Name, frm);
                    frm.Show();
                }
                else
                {
                    XtraMessageBox.Show("النموذج '" + Name + "' غير موجود بعد!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }
    }
}
