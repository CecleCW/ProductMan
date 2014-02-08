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
    public partial class ParameterForm : Form
    {
        public ParameterForm()
        {
            InitializeComponent();

            btn_New.Visible = DataService.Instance.IsAdmin;
        }

        public void InitData(int typeIndex)
        {
            if (cbx_ParamType.Items.Count > typeIndex)
                cbx_ParamType.SelectedIndex = typeIndex;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            bool ok = false;
            switch (cbx_ParamType.SelectedIndex)
            {
                case 0:
                    //Category
                    ProductCategory category = cbx_ParamName.SelectedItem as ProductCategory;
                    if (category != null)
                    {
                        category.Remark = rtbx_Remark.Text.Trim();
                        ok = (DataService.Instance.UpdateCategory(category) != null);
                    }
                    break;
                case 1:
                    //Sub Category
                    ProductSubCategory subCategory = cbx_ParamName.SelectedItem as ProductSubCategory;
                    if (subCategory != null)
                    {
                        subCategory.Remark = rtbx_Remark.Text.Trim();
                        ok = (DataService.Instance.UpdateSubCategory(subCategory) != null);
                    }
                    break;
                case 2:
                    //Color
                    ProductColor color = cbx_ParamName.SelectedItem as ProductColor;
                    if (color != null)
                    {
                        color.Remark = rtbx_Remark.Text.Trim();
                        ok = (DataService.Instance.UpdateColor(color) != null);
                    }
                    break;
                case 3:
                    //Crafts
                    ProductCrafts crafts = cbx_ParamName.SelectedItem as ProductCrafts;
                    if (crafts != null)
                    {
                        crafts.Remark = rtbx_Remark.Text.Trim();
                        ok = (DataService.Instance.UpdateCrafts(crafts) != null);
                    }
                    break;
                case 4:
                    //Material
                    ProductMaterial material = cbx_ParamName.SelectedItem as ProductMaterial;
                    if (material != null)
                    {
                        material.Remark = rtbx_Remark.Text.Trim();
                        ok = (DataService.Instance.UpdateMaterial(material) != null);
                    }
                    break;
                default:
                    break;
            }
            if (!ok)
            {
                MessageBox.Show(ResourceHelper.Instance.GetString("NewParameter.Update.Failed"), Text);
                return;
            }
            else MessageBox.Show(ResourceHelper.Instance.GetString("NewParameter.Update.OK"), Text);
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbx_ParamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_ParamName.Items.Clear();
            switch (cbx_ParamType.SelectedIndex)
            {
                case 0:
                    //Category
                    cbx_ParamName.Items.AddRange(DataService.Instance.Categories.ToArray());
                    break;
                case 1:
                    //Sub Category
                    cbx_ParamName.Items.AddRange(DataService.Instance.SubCategories.ToArray());
                    break;
                case 2:
                    //Color
                    cbx_ParamName.Items.AddRange(DataService.Instance.Colors.ToArray());
                    break;
                case 3:
                    //Crafts
                    cbx_ParamName.Items.AddRange(DataService.Instance.Crafts.ToArray());
                    break;
                case 4:
                    //Material
                    cbx_ParamName.Items.AddRange(DataService.Instance.Materials.ToArray());
                    break;
                default:
                    break;
            }
            if (cbx_ParamName.Items.Count > 0)
                cbx_ParamName.SelectedIndex = 0;
        }

        private void cbx_ParamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbx_Remark.Clear();
            switch (cbx_ParamType.SelectedIndex)
            {
                case 0:
                    //Category
                    ProductCategory category = cbx_ParamName.SelectedItem as ProductCategory;
                    if (category != null) rtbx_Remark.Text = category.Remark;
                    break;
                case 1:
                    //Sub Category
                    ProductSubCategory subCategory = cbx_ParamName.SelectedItem as ProductSubCategory;
                    if (subCategory != null) rtbx_Remark.Text = subCategory.Remark;
                    break;
                case 2:
                    //Color
                    ProductColor color = cbx_ParamName.SelectedItem as ProductColor;
                    if (color != null) rtbx_Remark.Text = color.Remark;
                    break;
                case 3:
                    //Crafts
                    ProductCrafts crafts = cbx_ParamName.SelectedItem as ProductCrafts;
                    if (crafts != null) rtbx_Remark.Text = crafts.Remark;
                    break;
                case 4:
                    //Material
                    ProductMaterial material = cbx_ParamName.SelectedItem as ProductMaterial;
                    if (material != null) rtbx_Remark.Text = material.Remark;
                    break;
                default:
                    break;
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            NewParameter form = new NewParameter();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                bool ok = false;
                int i = cbx_ParamName.SelectedIndex;
                string paramName = form.ParameterName;
                string paramRemark = form.ParameterRemark;
                switch (cbx_ParamType.SelectedIndex)
                {
                    case 0:
                        //Category
                        ProductCategory category = new ProductCategory();
                        category.CategoryName = paramName;
                        category.Remark = paramRemark;
                        ok = (DataService.Instance.CreateCategory(category) != null);
                        if (ok)
                        {
                            cbx_ParamName.Items.Clear();
                            cbx_ParamName.Items.AddRange(DataService.Instance.Categories.ToArray());
                        }
                        break;
                    case 1:
                        //Sub Category
                        ProductSubCategory subCategory = cbx_ParamName.SelectedItem as ProductSubCategory;
                        if (subCategory != null)
                        {
                            ProductSubCategory newSubCate = new ProductSubCategory();
                            newSubCate.CategoryID = subCategory.CategoryID;
                            newSubCate.Remark = paramRemark;
                            newSubCate.SubCategoryName = paramName;
                            ok = (DataService.Instance.CreateSubCategory(newSubCate) != null);
                            if (ok)
                            {
                                cbx_ParamName.Items.Clear();
                                cbx_ParamName.Items.AddRange(DataService.Instance.SubCategories.ToArray());
                            }
                        }
                        break;
                    case 2:
                        //Color
                        ProductColor color = new ProductColor();
                        color.ColorName = paramName;
                        color.Remark = paramRemark;
                        ok = (DataService.Instance.CreateColor(color) != null);
                        if (ok)
                        {
                            cbx_ParamName.Items.Clear();
                            cbx_ParamName.Items.AddRange(DataService.Instance.Colors.ToArray());
                        }
                        break;
                    case 3:
                        //Crafts
                        ProductCrafts crafts = new ProductCrafts();
                        crafts.CraftsName = paramName;
                        crafts.Remark = paramRemark;
                        ok = (DataService.Instance.CreateCrafts(crafts) != null);
                        if (ok)
                        {
                            cbx_ParamName.Items.Clear();
                            cbx_ParamName.Items.AddRange(DataService.Instance.Crafts.ToArray());
                        }
                        break;
                    case 4:
                        //Material
                        ProductMaterial material = new ProductMaterial();
                        material.MaterialName = paramName;
                        material.Remark = paramRemark;
                        ok = (DataService.Instance.CreateMaterial(material) != null);
                        if (ok)
                        {
                            cbx_ParamName.Items.Clear();
                            cbx_ParamName.Items.AddRange(DataService.Instance.Materials.ToArray());
                        }
                        break;
                    default:
                        break;
                }
                if (!ok)
                {
                    MessageBox.Show(ResourceHelper.Instance.GetString("NewParameter.New.Failed"), Text);
                }
                else
                {
                    if (cbx_ParamName.Items.Count > i)
                        cbx_ParamName.SelectedIndex = i;
                }
            }
        }
    }
}
