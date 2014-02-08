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
    public partial class StockForm : Form
    {
        protected ProductInfo currentProduct;
        protected bool increase;

        public StockForm(ProductInfo pi, bool increase)
        {
            InitializeComponent();
            currentProduct = pi;
            tbx_Stock.Text = "1";
            this.increase = increase;
            if (increase)
                lbl_Warning.Text = ResourceHelper.Instance.GetString("Main.Stock.Add.Warning");
            else
            {
                lbl_Warning.Text = ResourceHelper.Instance.GetString("Main.Stock.Minus.Warning");
                lbl_Stock.Text = ResourceHelper.Instance.GetString("Stock.ReduceStock");
            }
            lbl_ProductInfo.Text = pi.Representation;
        }

        public void SetStock(int value)
        {
            tbx_Stock.Text = value.ToString();
            tbx_Stock.ReadOnly = true;
        }

        public int Stock
        {
            get
            {
                string stock = tbx_Stock.Text.Trim();
                int flag = 1;
                if (!increase) flag = -1;
                int iStock = 0;
                if (int.TryParse(stock, out iStock)) return iStock * flag;
                return 0;
            }
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            if (increase)
            {
                if (Stock <= 0)
                {
                    MessageBox.Show(ResourceHelper.Instance.GetString("Stock.InvalidStock"), Text);
                    return;
                }
            }
            else
            {
                if (Stock >= 0)
                {
                    MessageBox.Show(ResourceHelper.Instance.GetString("Stock.InvalidStock"), Text);
                    return;
                }
            }
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
