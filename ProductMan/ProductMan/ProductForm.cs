using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductMan.Helpers;
using System.IO;

namespace ProductMan
{
    public partial class ProductForm : Form
    {
        private bool newMode;
        private bool isAdmin;
        private ProductInfo currentProduct;

        public ProductForm(bool isAdmin)
        {
            InitializeComponent();

            newMode = true;
            this.isAdmin = isAdmin;
            ChangeLanguage();
        }

        private void ChangeLanguage()
        {
            wtbx_ProductName.WaterMark = ResourceHelper.Instance.GetString("ProductEditor.ProductName.Hints");
            wtbx_Qty.WaterMark = ResourceHelper.Instance.GetString("ProductEditor.Quantity.Hints");
            wtbx_Weight.WaterMark = ResourceHelper.Instance.GetString("ProductEditor.Weight.Hints");
        }

        public bool NewMode { get { return newMode; } }

        public void InitialData(ProductInfo pi)
        {
            ToggleBtnState();
            currentProduct = pi;
            newMode = (pi == null);
            cbx_Category.Items.AddRange(DataService.Instance.Categories.ToArray());
            cbx_Origin.Items.AddRange(DataService.Instance.Origins.ToArray());
            cbx_Status.Items.AddRange(DataService.Instance.StatusList.ToArray());
            cbx_Style.Items.AddRange(DataService.Instance.StyleList.ToArray());
            cbx_Color.Items.AddRange(DataService.Instance.Colors.ToArray());
            cbx_Crafts.Items.AddRange(DataService.Instance.Crafts.ToArray());
            cbx_Material.Items.AddRange(DataService.Instance.Materials.ToArray());

            if (cbx_Category.Items.Count > 0) cbx_Category.SelectedIndex = 0;
            if (cbx_Style.Items.Count > 0) cbx_Style.SelectedIndex = 0;
            if (cbx_Origin.Items.Count > 0) cbx_Origin.SelectedIndex = 0;
            if (cbx_Status.Items.Count > 0) cbx_Status.SelectedIndex = 0;
            if (cbx_Color.Items.Count > 0) cbx_Color.SelectedIndex = 0;
            if (cbx_Crafts.Items.Count > 0) cbx_Crafts.SelectedIndex = 0;
            if (cbx_Material.Items.Count > 0) cbx_Material.SelectedIndex = 0;

            dtp_ProductionDate.Value = DateTime.Now;
            PaintProduct(pi);
        }

        private void ToggleBtnState()
        {
            if (isAdmin) return;
            btn_Category.Enabled = false;
            btn_Category.Visible = false;
            btn_Color.Enabled = false;
            btn_Color.Visible = false;
            btn_Crafts.Enabled = false;
            btn_Crafts.Visible = false;
            btn_Material.Enabled = false;
            btn_Material.Visible = false;
            btn_SubCategory.Enabled = false;
            btn_SubCategory.Visible = false;
            btn_OK.Enabled = false;
            btn_OK.Visible = false;
        }

        private void PaintProduct(ProductInfo pi)
        {
            if (pi == null) return;
            wtbx_ProductName.Text = pi.ProductName;
            dtp_ProductionDate.Value = pi.ProductionDate;
            wtbx_Qty.Text = pi.Quantity;
            wtbx_Weight.Text = pi.Weight;
            rtbx_Remark.Text = pi.Remark;
            rtbx_Spec.Text = pi.Specification;
            pictureBox1.Image = pi.Image;
            tbx_Stock.Text = pi.Stock.ToString("N0");
            cbx_Category.SelectedItem = DataService.Instance.CategoryOf(pi.CategoryID);
            cbx_Color.SelectedItem = DataService.Instance.ColorOf(pi.ColorID);
            cbx_Crafts.SelectedItem = DataService.Instance.CraftsOf(pi.CraftsID);
            cbx_Material.SelectedItem = DataService.Instance.MaterialOf(pi.MaterialID);
            cbx_Origin.SelectedItem = DataService.Instance.OriginOf(pi.OriginID);
            cbx_Status.SelectedItem = DataService.Instance.StatusOf(pi.StatusID);
            cbx_Style.SelectedItem = DataService.Instance.StyleOf(pi.StyleID);
            cbx_SubCategory.SelectedItem = DataService.Instance.SubCategoryOf(pi.SubCategoryID);
        }

        private ProductInfo GetProductInfo()
        {
            ProductInfo pi = new ProductInfo();
            if (!newMode)
            {
                if (currentProduct == null) return null;
                pi.ProductID = currentProduct.ProductID;
            }

            ProductCategory category = cbx_Category.SelectedItem as ProductCategory;
            if (category == null) return null;
            pi.CategoryID = category.CategoryID;
            ProductColor color = cbx_Color.SelectedItem as ProductColor;
            if (color == null) return null;
            pi.ColorID = color.ColorID;
            ProductCrafts crafts = cbx_Crafts.SelectedItem as ProductCrafts;
            if (crafts == null) return null;
            pi.CraftsID = crafts.CraftsID;
            ProductMaterial material = cbx_Material.SelectedItem as ProductMaterial;
            if (material == null) return null;
            pi.MaterialID = material.MaterialID;
            ProductOrigin origin = cbx_Origin.SelectedItem as ProductOrigin;
            if (origin == null) return null;
            pi.OriginID = origin.OriginID;
            pi.ProductionDate = dtp_ProductionDate.Value;
            pi.ProductName = wtbx_ProductName.Text;
            pi.Quantity = wtbx_Qty.Text;
            pi.Remark = rtbx_Remark.Text;
            pi.Specification = rtbx_Spec.Text;
            ProductStatus status = cbx_Status.SelectedItem as ProductStatus;
            if (status == null) return null;
            pi.StatusID = status.StatusID;
            ProductStyle style = cbx_Style.SelectedItem as ProductStyle;
            if (style == null) return null;
            pi.StyleID = style.StyleID;
            ProductSubCategory subcategory = cbx_SubCategory.SelectedItem as ProductSubCategory;
            if (subcategory == null) return null;
            pi.SubCategoryID = subcategory.SubCategoryID;
            pi.Weight = wtbx_Weight.Text;
            pi.Image = pictureBox1.Image as Bitmap;
            return pi;
        }

        private void btn_Category_Click(object sender, EventArgs e)
        {
            EditParam(0);
        }

        private void btn_SubCategory_Click(object sender, EventArgs e)
        {
            EditParam(1);
        }

        private void btn_Color_Click(object sender, EventArgs e)
        {
            EditParam(2);
        }

        private void btn_Crafts_Click(object sender, EventArgs e)
        {
            EditParam(3);
        }

        private void btn_Material_Click(object sender, EventArgs e)
        {
            EditParam(4);
        }

        private void EditParam(int typeIndex)
        {
            ParameterForm form = new ParameterForm();
            form.InitData(typeIndex);
            form.ShowDialog(this);
        }

        private void btn_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.JPG|*.JPG|*.JPEG|*.JPEG|*.GIF|*.GIF|*.BMP|*.BMP";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
                pictureBox1.Refresh();
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            ProductInfo pi = GetProductInfo();
            bool ok = false;
            if (pi != null)
            {
                ProductInfo newProduct = null;
                if (newMode)
                {
                    newProduct = DataService.Instance.CreateProduct(pi);
                    if (newProduct == null)
                        MessageBox.Show(this, ResourceHelper.Instance.GetString("ProductEditor.CreateProduct.Failed"), Text);
                    else
                    {
                        ok = true;
                        MessageBox.Show(this, ResourceHelper.Instance.GetString("ProductEditor.CreateProduct.OK"), Text);
                    }
                }
                else
                {
                    newProduct = DataService.Instance.UpdateProduct(pi);
                    if (newProduct == null)
                        MessageBox.Show(this, ResourceHelper.Instance.GetString("ProductEditor.UpdateProduct.Failed"), Text);
                    else
                    {
                        ok = true;
                        MessageBox.Show(this, ResourceHelper.Instance.GetString("ProductEditor.UpdateProduct.OK"), Text);
                    }
                }
            }
            if (ok) Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbx_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_SubCategory.Items.Clear();
            ProductCategory item = cbx_Category.SelectedItem as ProductCategory;
            if (item == null) return;
            List<ProductSubCategory> values = DataService.Instance.SubCategoriesOf(item.CategoryID);
            if (values == null) return;
            cbx_SubCategory.Items.AddRange(values.ToArray());
            if (cbx_SubCategory.Items.Count > 0)
            {
                cbx_SubCategory.SelectedIndex = 0;
            }
        }
    }
}
