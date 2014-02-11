using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BinaryComponents.SuperList;
using System.Globalization;
using ProductMan.Helpers;
using ProductMan.Utilities;

namespace ProductMan.Panes
{
    public partial class ProductPane : UserControl
    {
        public ProductPane()
        {
            InitializeComponent();

            DataService.Instance.OnProductCreated += new EventHandler<ProductUpdateEventArgs>(Instance_OnProductCreated);
            DataService.Instance.OnProductUpdated += new EventHandler<ProductUpdateEventArgs>(Instance_OnProductUpdated);
        }

        public void RefreshGrid()
        {
            try
            {
                listControl1.RefreshItems();
            }
            catch { }
        }

        private void Instance_OnProductUpdated(object sender, ProductUpdateEventArgs e)
        {
            RefreshGrid();
        }

        private void Instance_OnProductCreated(object sender, ProductUpdateEventArgs e)
        {
            AddProduct(e.Product);
        }

        public void ChangeLanguage(CultureInfo culture, bool init)
        {
            captionPane1.Caption = ResourceHelper.Instance.GetString("ProductPane.Caption", culture);
            searchPane1.Caption = ResourceHelper.Instance.GetString("ProductPane.Search", culture);
            searchPane1.Hints = ResourceHelper.Instance.GetString("ProductPane.SearchHints", culture);
            filterPane1.ChangeLanguage(culture);
            listControl1.ChangeLanguage(culture);

            if (init) return;
            listControl1.SuspendLayout();
            try
            {
                foreach (Column item in listControl1.Columns)
                {
                    item.Caption = ResourceHelper.Instance.GetString(item.Name, culture);
                }
                listControl1.Invalidate();
            }
            finally
            {
                listControl1.ResumeLayout();
            }
        }

        public void InitProductPane()
        {
            InitGrid();
            filterPane1.OnFilter += new EventHandler<EventArgs>(filterPane1_OnFilter);
            searchPane1.OnInput += new EventHandler<InputTextChangedEventArgs>(searchPane1_OnInput);
            searchPane1.OnCancel += new EventHandler<EventArgs>(searchPane1_OnCancel);
            searchPane1.AllowCustomTypes = false;
        }

        public void InitData()
        {
            foreach (ProductSubCategory psc in DataService.Instance.SubCategories)
            {
                if (psc.SubCategoryName == "全部") continue;
                filterPane1.MyOwner.Items.Add(psc);
            }
        }

        public void AddProduct(ProductInfo pi)
        {
            if (pi == null) return;
            AddProductInternal(pi);
        }

        public void AddProducts(List<ProductInfo> products)
        {
            if (products == null) return;
            if (products.Count == 0) return;
            foreach (ProductInfo pi in products)
            {
                AddProductInternal(pi);
            }
        }

        public ProductInfo SelectedProduct
        {
            get
            {
                if (listControl1.SelectedItems != null && listControl1.SelectedItems.Count == 1)
                {
                    RowIdentifier ri = listControl1.SelectedItems[0];
                    if (ri.Items != null && ri.Items.Length > 0)
                    {
                        return ri.Items[0] as ProductInfo;
                    }
                }
                return null;
            }
        }

        public void DeleteProduct(ProductInfo pi)
        {
            if (pi == null) return;
            try
            {
                listControl1.Items.Remove(pi);
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public void EditData()
        {
            listControl1_DoubleClick(this, EventArgs.Empty);
        }

        private void AddProductInternal(ProductInfo item)
        {
            if (item == null) return;
            listControl1.Items.Add(item);
        }

        private void DoFilter()
        {
            DoFilter("");
        }

        private void DoFilter(string keyword)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                List<string> filters = new List<string>();
                foreach (ProductSubCategory item in filterPane1.MyOwner.CheckedItems)
                {
                    filters.Add(item.SubCategoryID);
                }

                List<ProductInfo> tmpProducts = new List<ProductInfo>();
                foreach (ProductInfo pi in DataService.Instance.Products)
                {
                    if (filters.Count > 0)
                    {
                        if (!filters.Contains(pi.SubCategoryID)) continue;
                    }
                    if (!pi.HasMe(keyword)) continue;
                    tmpProducts.Add(pi);
                }
                listControl1.Items.Clear();
                if (tmpProducts.Count > 0)
                    listControl1.Items.AddRange(tmpProducts);
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void filterPane1_OnFilter(object sender, EventArgs e)
        {
            DoFilter(searchPane1.Keywords);
        }

        private void searchPane1_OnCancel(object sender, EventArgs e)
        {
            DoFilter();
        }

        private void searchPane1_OnInput(object sender, InputTextChangedEventArgs e)
        {
            if (e.Text == null || e.Text.Trim() == "")
            {
                DoFilter();
                return;
            }
            DoFilter(e.Text.Trim());
        }

        private void InitGrid()
        {
            Column nameColumn = new Column("ProductPane.ProductName", ResourceHelper.Instance.GetString("ProductPane.ProductName"), 200, delegate(object item) { return ((ProductInfo)item).ProductName; });
            Column remarkColumn = new Column("ProductPane.Remark", ResourceHelper.Instance.GetString("ProductPane.Remark"), 80, delegate(object item) { return ((ProductInfo)item).Remark; });
            Column productionDateColumn = new Column("ProductPane.ProductionDate", ResourceHelper.Instance.GetString("ProductPane.ProductionDate"), 120, delegate(object item) { return ((ProductInfo)item).ProductionDate; });
            Column createDateColumn = new Column("ProductPane.CreateDate", ResourceHelper.Instance.GetString("ProductPane.CreateDate"), 120, delegate(object item) { return ((ProductInfo)item).CreateDate; });
            Column modifiedDateColumn = new Column("ProductPane.ModifiedDate", ResourceHelper.Instance.GetString("ProductPane.ModifiedDate"), 120, delegate(object item) { return ((ProductInfo)item).ModifiedDate; });
            Column categoryColumn = new Column("ProductPane.Category", ResourceHelper.Instance.GetString("ProductPane.Category"), 80, delegate(object item) { return ((ProductInfo)item).CategoryName; });
            Column subcategoryColumn = new Column("ProductPane.SubCategory", ResourceHelper.Instance.GetString("ProductPane.SubCategory"), 80, delegate(object item) { return ((ProductInfo)item).SubCategoryName; });
            Column craftsColumn = new Column("ProductPane.Crafts", ResourceHelper.Instance.GetString("ProductPane.Crafts"), 80, delegate(object item) { return ((ProductInfo)item).Crafts; });
            Column materialColumn = new Column("ProductPane.Material", ResourceHelper.Instance.GetString("ProductPane.Material"), 80, delegate(object item) { return ((ProductInfo)item).Material; });
            //Column statusColumn = new Column("ProductPane.Status", ResourceHelper.Instance.GetString("ProductPane.Status"), 80, delegate(object item) { return ((ProductInfo)item).StatusName; });
            //Column originColumn = new Column("ProductPane.Origin", ResourceHelper.Instance.GetString("ProductPane.Origin"), 80, delegate(object item) { return ((ProductInfo)item).OriginName; });
            //Column styleColumn = new Column("ProductPane.Style", ResourceHelper.Instance.GetString("ProductPane.Style"), 80, delegate(object item) { return ((ProductInfo)item).StyleName; });
            Column colorColumn = new Column("ProductPane.Color", ResourceHelper.Instance.GetString("ProductPane.Color"), 80, delegate(object item) { return ((ProductInfo)item).Color; });
            Column specColumn = new Column("ProductPane.Spec", ResourceHelper.Instance.GetString("ProductPane.Spec"), 80, delegate(object item) { return ((ProductInfo)item).Specification; });
            Column stockColumn = new Column("ProductPane.Stock", ResourceHelper.Instance.GetString("ProductPane.Stock"), 120, delegate(object item) { return ((ProductInfo)item).Stock.ToString("N0"); });

            productionDateColumn.GroupItemAccessor = new ColumnItemValueAccessor(GroupValueFromItem);
            productionDateColumn.GroupSortOrder = SortOrder.Descending;
            productionDateColumn.SortOrder = SortOrder.Ascending;

            listControl1.Columns.Add(productionDateColumn);
            productionDateColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(nameColumn);
            nameColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(categoryColumn);
            categoryColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(subcategoryColumn);
            subcategoryColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(materialColumn);
            materialColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(craftsColumn);
            craftsColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(specColumn);
            specColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(colorColumn);
            colorColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            //listControl1.Columns.Add(styleColumn);
            //styleColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            //listControl1.Columns.Add(originColumn);
            //originColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            //listControl1.Columns.Add(statusColumn);
            //statusColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(stockColumn);
            stockColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(createDateColumn);
            createDateColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(modifiedDateColumn);
            modifiedDateColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
            listControl1.Columns.Add(remarkColumn);
            remarkColumn.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;

            listControl1.Columns.GroupedItems.Add(productionDateColumn);
            listControl1.ShowCustomizeSection = true;
            listControl1.DoubleClick += new EventHandler(listControl1_DoubleClick);
        }

        private string GroupValueFromItem(object obj)
        {
            ProductInfo pi = obj as ProductInfo;
            if (pi == null) return ResourceHelper.Instance.GetString("ProductPane.Today");
            DateTime date = pi.ProductionDate;
            DateTime publicationDate = date.Date;
            DateTime now = DateTime.Now.Date;
            DateTime weekStart = now.AddDays(-(int)now.DayOfWeek);
            DateTime monthStart = now.AddDays(-now.Day);

            int days = now.Subtract(publicationDate).Days;

            if (days < 1)
            {
                return ResourceHelper.Instance.GetString("ProductPane.Today");
            }
            else if (days < 2)
            {
                return ResourceHelper.Instance.GetString("ProductPane.Yesterday");
            }
            else if (publicationDate > weekStart)
            {
                return ResourceHelper.Instance.GetString("ProductPane.ThisWeek");
            }
            else if (publicationDate > weekStart.AddDays(-7))
            {
                return ResourceHelper.Instance.GetString("ProductPane.LastWeek");
            }
            else if (publicationDate > monthStart)
            {
                return ResourceHelper.Instance.GetString("ProductPane.ThisMonth");
            }
            else if (publicationDate > monthStart.AddMonths(-1).AddDays(1))
            {
                return ResourceHelper.Instance.GetString("ProductPane.LastMonth");
            }
            else
            {
                return ResourceHelper.Instance.GetString("ProductPane.Older");
            }
        }

        private void listControl1_DoubleClick(object sender, EventArgs e)
        {
            ProductInfo pi = SelectedProduct;
            if (pi == null) return;
            ProductForm form = new ProductForm(DataService.Instance.IsAdmin);
            form.InitialData(pi);
            form.ShowDialog(this);
        }
    }
}
