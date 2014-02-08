using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductMan.Helpers;

namespace ProductMan
{
    public partial class NewParameter : Form
    {
        public NewParameter()
        {
            InitializeComponent();

            wtbx_Name.WaterMark = ResourceHelper.Instance.GetString("NewParameter.Name.Hints");
        }

        public string ParameterName { get { return wtbx_Name.Text.Trim(); } }

        public string ParameterRemark { get { return rtbx_Remark.Text.Trim(); } }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (ParameterName == "")
            {
                MessageBox.Show(ResourceHelper.Instance.GetString("NewParameter.Warning"), Text);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
