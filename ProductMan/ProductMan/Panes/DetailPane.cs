using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductMan.Panes
{
    public partial class DetailPane : UserControl
    {
        protected ProductInfo currentProduct;

        public DetailPane()
        {
            InitializeComponent();
        }

        public void AssignProduct(ProductInfo product)
        {
            currentProduct = product;
            ResetProduct();
            if (product == null) return;
        }

        private void ResetProduct()
        {
            lbl_Title.Text = "";
            lbl_AssignedTo.Text = "";
            rtbx_Description.Text = "";
            rtbx_Remark.Text = "";
        }
    }
}
