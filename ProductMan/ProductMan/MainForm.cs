using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductMan.Panes;
using System.Globalization;
using ProductMan.MultiLang;
using ProductMan.Helpers;

namespace ProductMan
{
    public partial class MainForm : Form
    {
        private const string TITLE = "Product Man";
        private ProductPane productPane;
        private bool initializing;

        public MainForm()
        {
            InitializeComponent();

            SplashScreen.Instance.Status = ResourceHelper.Instance.GetString("SplashScreen.Initial");
            initializing = true;
            CreateHandle();
            productPane = new ProductPane();
            productPane.Parent = panel1;
            productPane.Dock = DockStyle.Fill;
            CHSToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //TODO
        }

        public void InitData()
        {
            productPane.InitProductPane();
            SplashScreen.Instance.Status = ResourceHelper.Instance.GetString("SplashScreen.LoadProducts");
            DataService.Instance.GetColors();
            DataService.Instance.GetCrafts();
            DataService.Instance.GetMaterials();
            DataService.Instance.GetCategories();
            DataService.Instance.GetOrigins();
            DataService.Instance.GetStatus();
            DataService.Instance.GetStyle();
            DataService.Instance.GetSubCategories();
            DataService.Instance.GetProducts();
            SplashScreen.Instance.Status = ResourceHelper.Instance.GetString("SplashScreen.PrepareProducts");
            productPane.InitData();
            productPane.AddProducts(DataService.Instance.Products);
            initializing = false;
        }

        private void ChangeLanguage(string name)
        {
            CultureInfo ci = new CultureInfo(name);
            FormLanguageSwitchSingleton.Instance.ChangeCurrentThreadUICulture(ci);
            FormLanguageSwitchSingleton.Instance.ChangeLanguage(this, ci);
            productPane.ChangeLanguage(ci, initializing);
            Text = string.Format("{0} - {1} ({2})", TITLE, DataService.Instance.CurrentUser.FullName, DataService.Instance.CurrentUser.UserID);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en-US");
        }

        private void CHSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("zh-CHS");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog(this);
        }

        private void productEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm(DataService.Instance.IsAdmin);
            form.InitialData(null);
            form.ShowDialog(this);
        }

        private void productParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParameterForm form = new ParameterForm();
            form.InitData(0);
            form.ShowDialog(this);
        }

        private void tsbtn_NewProduct_Click(object sender, EventArgs e)
        {
            productEditorToolStripMenuItem_Click(sender, e);
        }

        private void stbtn_ModProduct_Click(object sender, EventArgs e)
        {
            productPane.EditData();
        }

        private void tsbtn_DeleteProduct_Click(object sender, EventArgs e)
        {
            ProductInfo pi = productPane.SelectedProduct;
            if (pi == null) return;
            if (MessageBox.Show(ResourceHelper.Instance.GetString("Main.DeleteProduct.Warning") + "\r\n\r\n" + pi.Representation, TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DataService.Instance.DeleteProduct(pi))
                {
                    productPane.DeleteProduct(pi);
                    MessageBox.Show(ResourceHelper.Instance.GetString("Main.DeleteProduct.OK"), TITLE);
                }
                else MessageBox.Show(ResourceHelper.Instance.GetString("Main.DeleteProduct.Failed"), TITLE);
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(ResourceHelper.Instance.GetString("ChangePassword.ChangeOK"), TITLE);
            }
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(ResourceHelper.Instance.GetString("UserForm.UpdateUser.OK"), TITLE);
                Text = string.Format("{0} - {1} ({2})", TITLE, DataService.Instance.CurrentUser.FullName, DataService.Instance.CurrentUser.UserID);
            }
        }

        private void tsbtn_AddOne_Click(object sender, EventArgs e)
        {
            ProductInfo pi = productPane.SelectedProduct;
            if (pi == null) return;
            StockForm form = new StockForm(pi, true);
            form.SetStock(1);
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                ProductInfo newPI = DataService.Instance.UpdateProductStock(pi.ProductID, 1);
                if (newPI != null) MessageBox.Show(ResourceHelper.Instance.GetString("Main.Stock.Add.OK"), TITLE);
                else MessageBox.Show(ResourceHelper.Instance.GetString("Main.Stock.Add.Failed"), TITLE);
            }
        }

        private void tsbtn_AddN_Click(object sender, EventArgs e)
        {
            ProductInfo pi = productPane.SelectedProduct;
            if (pi == null) return;
            StockForm form = new StockForm(pi, true);
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                ProductInfo newPI = DataService.Instance.UpdateProductStock(pi.ProductID, form.Stock);
                if (newPI != null) MessageBox.Show(ResourceHelper.Instance.GetString("Main.Stock.Add.OK"), TITLE);
                else MessageBox.Show(ResourceHelper.Instance.GetString("Main.Stock.Add.Failed"), TITLE);
            }
        }

        private void tsbtn_DelOne_Click(object sender, EventArgs e)
        {
            ProductInfo pi = productPane.SelectedProduct;
            if (pi == null) return;
            StockForm form = new StockForm(pi, false);
            form.SetStock(1);
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                ProductInfo newPI = DataService.Instance.UpdateProductStock(pi.ProductID, -1);
                if (newPI != null) MessageBox.Show(ResourceHelper.Instance.GetString("Main.Stock.Minus.OK"), TITLE);
                else MessageBox.Show(ResourceHelper.Instance.GetString("Main.Stock.Minus.Failed"), TITLE);
            }
        }

        private void tsbtn_DelN_Click(object sender, EventArgs e)
        {
            ProductInfo pi = productPane.SelectedProduct;
            if (pi == null) return;
            StockForm form = new StockForm(pi, false);
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                ProductInfo newPI = DataService.Instance.UpdateProductStock(pi.ProductID, form.Stock);
                if (newPI != null) MessageBox.Show(ResourceHelper.Instance.GetString("Main.Stock.Minus.OK"), TITLE);
                else MessageBox.Show(ResourceHelper.Instance.GetString("Main.Stock.Minus.Failed"), TITLE);
            }
        }
    }
}
