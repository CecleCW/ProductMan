using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ProductMan.Utilities;
using System.Configuration;
using ProductMan.Helpers;
using System.Data;
using ProductMan.Win32;

namespace ProductMan
{
    public class DataService
    {
        public event EventHandler<ProductUpdateEventArgs> OnProductCreated;
        public event EventHandler<ProductUpdateEventArgs> OnProductUpdated;

        private static DataService instance = new DataService();
        private SqlConnection sqlConn;
        private Dictionary<string, ProductInfo> products;
        private Dictionary<string, ProductCategory> categories;
        private Dictionary<string, ProductSubCategory> subCategories;
        private Dictionary<string, ProductOrigin> origins;
        private Dictionary<string, ProductStatus> statusList;
        private Dictionary<string, ProductStyle> styleList;
        private Dictionary<string, ProductColor> colors;
        private Dictionary<string, ProductCrafts> crafts;
        private Dictionary<string, ProductMaterial> materials;
        private UserInfo currentUser;

        private DataService()
        {
            try
            {
                products = new Dictionary<string, ProductInfo>(StringComparer.InvariantCultureIgnoreCase);
                categories = new Dictionary<string, ProductCategory>(StringComparer.InvariantCultureIgnoreCase);
                subCategories = new Dictionary<string, ProductSubCategory>(StringComparer.InvariantCultureIgnoreCase);
                origins = new Dictionary<string, ProductOrigin>(StringComparer.InvariantCultureIgnoreCase);
                statusList = new Dictionary<string, ProductStatus>(StringComparer.InvariantCultureIgnoreCase);
                styleList = new Dictionary<string, ProductStyle>(StringComparer.InvariantCultureIgnoreCase);
                colors = new Dictionary<string, ProductColor>(StringComparer.InvariantCultureIgnoreCase);
                crafts = new Dictionary<string, ProductCrafts>(StringComparer.InvariantCultureIgnoreCase);
                materials = new Dictionary<string, ProductMaterial>(StringComparer.InvariantCultureIgnoreCase);
                sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SYDDATA"].ConnectionString);
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public static DataService Instance { get { return instance; } }

        public UserInfo CurrentUser { get { return currentUser; } }

        public bool IsAdmin
        {
            get
            {
                if (currentUser != null) return currentUser.UserType == 9;
                return false;
            }
        }

        public UserInfo Authenticate(string id, string password)
        {
            if (id == null || id.Trim() == "") return null;
            if (password == null || password.Trim() == "") return null;
            try
            {
                string passwordEncrypted = DataProtection.Encrypt(password, id);
                ComputerSystem cs = WMIVendor.Instance.GetComputerSystem();
                NetworkAdapterConfiguration network = WMIVendor.Instance.GetNetworkConfig();
                ProductMan.Win32.OperatingSystem os = WMIVendor.Instance.GetOS();
                string ip = "";
                if (network.IPAddress != null && network.IPAddress.Length > 0)
                    ip = network.IPAddress[0];
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "AuthenticateUser", new object[] { id, passwordEncrypted, ip, network.MACAddress, cs.Domain, cs.UserName, os.SerialNumber, "ProductMan", typeof(DataService).Assembly.GetName().Version.ToString(), "" });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    currentUser = GetUserInfoFrom(table.Rows[0]);
                    return currentUser;
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        private UserInfo GetUserInfoFrom(DataRow row)
        {
            if (row == null) return null;
            UserInfo ui = new UserInfo();
            ui.Email = Formatter.GetStringValueFrom(row, "Email");
            ui.FullName = Formatter.GetStringValueFrom(row, "FullName");
            ui.Password = Formatter.GetStringValueFrom(row, "Password");
            ui.UserID = Formatter.GetStringValueFrom(row, "UserID");
            ui.UserName = Formatter.GetStringValueFrom(row, "UserName");
            ui.UserType = Formatter.GetIntValueFrom(row, "UserType");
            return ui;
        }

        public bool ChangePassword(string password)
        {
            if (password == null || password.Trim() == "") return false;
            if (currentUser == null) return false;
            try
            {
                string passwordEncrypted = DataProtection.Encrypt(password, DataService.Instance.CurrentUser.UserID);
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "ChangePassword", new object[] { currentUser.UserID, passwordEncrypted, currentUser.UserID });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    UserInfo ui = GetUserInfoFrom(table.Rows[0]);
                    currentUser.Password = ui.Password;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return false;
        }

        public bool UpdateUserInfo(UserInfo ui)
        {
            if (ui == null) return false;
            if (currentUser == null) return false;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "UpdateUser", new object[] { currentUser.UserID, currentUser.UserID, currentUser.Password, currentUser.UserType, ui.UserName, ui.FullName, ui.Email });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    UserInfo newUI = GetUserInfoFrom(table.Rows[0]);
                    currentUser.UserName = newUI.UserName;
                    currentUser.FullName = newUI.FullName;
                    currentUser.Email = newUI.Email;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return false;
        }

        public List<ProductInfo> Products
        {
            get
            {
                List<ProductInfo> values = new List<ProductInfo>();
                foreach (ProductInfo pi in products.Values)
                {
                    values.Add(pi);
                }
                return values;
            }
        }

        public List<ProductCategory> Categories
        {
            get
            {
                List<ProductCategory> values = new List<ProductCategory>();
                ProductCategory firstItem = null;
                foreach (ProductCategory item in categories.Values)
                {
                    if (item.CategoryName == "餐具") firstItem = item;
                    else values.Add(item);
                }
                if (firstItem != null) values.Insert(0, firstItem);
                return values;
            }
        }

        public List<ProductOrigin> Origins
        {
            get
            {
                List<ProductOrigin> values = new List<ProductOrigin>();
                foreach (ProductOrigin item in origins.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public List<ProductColor> Colors
        {
            get
            {
                List<ProductColor> values = new List<ProductColor>();
                foreach (ProductColor item in colors.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public List<ProductCrafts> Crafts
        {
            get
            {
                List<ProductCrafts> values = new List<ProductCrafts>();
                foreach (ProductCrafts item in crafts.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public List<ProductMaterial> Materials
        {
            get
            {
                List<ProductMaterial> values = new List<ProductMaterial>();
                foreach(ProductMaterial item in materials.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public List<ProductStatus> StatusList
        {
            get
            {
                List<ProductStatus> values = new List<ProductStatus>();
                foreach (ProductStatus item in statusList.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public List<ProductStyle> StyleList
        {
            get
            {
                List<ProductStyle> values = new List<ProductStyle>();
                foreach (ProductStyle item in styleList.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public List<ProductSubCategory> SubCategories
        {
            get
            {
                List<ProductSubCategory> values = new List<ProductSubCategory>();
                ProductSubCategory firstItem = null;
                foreach (ProductSubCategory item in subCategories.Values)
                {
                    if (item.SubCategoryName == "全部") firstItem = item;
                    else values.Add(item);
                }
                if (firstItem != null) values.Insert(0, firstItem);
                return values;
            }
        }

        public ProductSubCategory SubCategoryOf(string id)
        {
            if (id == null || id.Trim() == "") return null;
            if (!subCategories.ContainsKey(id)) return null;
            return subCategories[id];
        }

        public List<ProductSubCategory> SubCategoriesOf(string categoryID)
        {
            if (categoryID == null || categoryID.Trim() == "") return null;
            List<ProductSubCategory> values = new List<ProductSubCategory>();
            ProductSubCategory firstItem = null;
            foreach (ProductSubCategory item in subCategories.Values)
            {
                if (item.CategoryID == categoryID)
                {
                    if (item.SubCategoryName == "全部") firstItem = item;
                    else values.Add(item);
                }
            }
            if (firstItem != null)
                values.Insert(0, firstItem);
            return values;
        }

        public ProductStyle StyleOf(string id)
        {
            if (id == null || id.Trim() == "") return null;
            if (!styleList.ContainsKey(id)) return null;
            return styleList[id];
        }

        public ProductStatus StatusOf(string id)
        {
            if (id == null || id.Trim() == "") return null;
            if (!statusList.ContainsKey(id)) return null;
            return statusList[id];
        }

        public ProductOrigin OriginOf(string id)
        {
            if (id == null || id.Trim() == "") return null;
            if (!origins.ContainsKey(id)) return null;
            return origins[id];
        }

        public ProductColor ColorOf(string id)
        {
            if (id == null || id.Trim() == "") return null;
            if (!colors.ContainsKey(id)) return null;
            return colors[id];
        }

        public ProductCrafts CraftsOf(string id)
        {
            if (id == null || id.Trim() == "") return null;
            if (!crafts.ContainsKey(id)) return null;
            return crafts[id];
        }

        public ProductMaterial MaterialOf(string id)
        {
            if (id == null || id.Trim() == "") return null;
            if (!materials.ContainsKey(id)) return null;
            return materials[id];
        }

        public ProductCategory CategoryOf(string id)
        {
            if (id == null || id.Trim() == "") return null;
            if (!categories.ContainsKey(id)) return null;
            return categories[id];
        }

        public ProductInfo ProductOf(string id)
        {
            if (id == null || id.Trim() == "") return null;
            if (!products.ContainsKey(id)) return null;
            return products[id];
        }

        public ProductInfo CreateProduct(ProductInfo pi)
        {
            if (pi == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "InsertProductDetail", pi.GetCreateParams().ToArray());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductInfo product = GetProductInfoFrom(table.Rows[0]);
                    if (product != null)
                    {
                        if (!products.ContainsKey(product.ProductID))
                            products[product.ProductID] = product;
                        else
                            AssignNewProduct(product);
                        if (OnProductCreated != null)
                        {
                            OnProductCreated(this, new ProductUpdateEventArgs(product));
                        }
                        return product;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductInfo UpdateProduct(ProductInfo pi)
        {
            if (pi == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "UpdateProductDetail", pi.GetUpdateParams().ToArray());
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductInfo product = GetProductInfoFrom(table.Rows[0]);
                    if (product != null)
                    {
                        if (!products.ContainsKey(product.ProductID))
                            products[product.ProductID] = product;
                        else
                            AssignNewProduct(product);
                        if (OnProductUpdated != null)
                        {
                            OnProductUpdated(this, new ProductUpdateEventArgs(product));
                        }
                        return product;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public bool DeleteProduct(ProductInfo pi)
        {
            if (pi == null) return false;
            try
            {
                int count = SqlHelper.ExecuteNonQuery(sqlConn, "DeleteProductDetails", new object[] { pi.ProductID, currentUser.UserID });
                if (count > 0)
                {
                    if (products.ContainsKey(pi.ProductID))
                        products.Remove(pi.ProductID);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return false;
        }

        public ProductCategory CreateCategory(ProductCategory category)
        {
            if (category == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "InsertProductCategory", new object[] { currentUser.UserID, category.CategoryName, category.Remark });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductCategory pc = GetProductCategoryFrom(table.Rows[0]);
                    if (pc != null)
                    {
                        if (!categories.ContainsKey(pc.CategoryID))
                            categories[pc.CategoryID] = pc;
                        else AssignNewCategory(pc);
                        return pc;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductCategory UpdateCategory(ProductCategory category)
        {
            if (category == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "UpdateProductCategory", new object[] { currentUser.UserID, category.CategoryID, category.CategoryName, category.Remark });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductCategory pc = GetProductCategoryFrom(table.Rows[0]);
                    if (pc != null)
                    {
                        if (!categories.ContainsKey(pc.CategoryID))
                            categories[pc.CategoryID] = pc;
                        else AssignNewCategory(pc);
                        return pc;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductSubCategory CreateSubCategory(ProductSubCategory subCategory)
        {
            if (subCategory == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "InsertProductSubCategory", new object[] { currentUser.UserID, subCategory.CategoryID, subCategory.SubCategoryName, subCategory.Remark });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductSubCategory psc = GetProductSubCategoryFrom(table.Rows[0]);
                    if (psc != null)
                    {
                        if (!subCategories.ContainsKey(psc.CategoryID))
                            subCategories[psc.CategoryID] = psc;
                        else AssignNewSubCategory(psc);
                        return psc;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductSubCategory UpdateSubCategory(ProductSubCategory subCategory)
        {
            if (subCategory == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "UpdateProductSubCategory", new object[] { currentUser.UserID, subCategory.CategoryID, subCategory.SubCategoryID, subCategory.SubCategoryName, subCategory.Remark });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductSubCategory psc = GetProductSubCategoryFrom(table.Rows[0]);
                    if (psc != null)
                    {
                        if (!subCategories.ContainsKey(psc.CategoryID))
                            subCategories[psc.CategoryID] = psc;
                        else AssignNewSubCategory(psc);
                        return psc;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductColor CreateColor(ProductColor color)
        {
            if (color == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "InsertProductColor", new object[] { currentUser.UserID, color.ColorName, color.Remark });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductColor pc = GetProductColorFrom(table.Rows[0]);
                    if (pc != null)
                    {
                        if (!colors.ContainsKey(pc.ColorID))
                            colors[pc.ColorID] = pc;
                        else AssignNewColor(pc);
                        return pc;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductColor UpdateColor(ProductColor color)
        {
            if (color == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "UpdateProductColor", new object[] { currentUser.UserID, color.ColorID, color.ColorName, color.Remark });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductColor pc = GetProductColorFrom(table.Rows[0]);
                    if (pc != null)
                    {
                        if (!colors.ContainsKey(pc.ColorID))
                            colors[pc.ColorID] = pc;
                        else AssignNewColor(pc);
                        return pc;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductCrafts CreateCrafts(ProductCrafts craft)
        {
            if (craft == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "InsertProductCrafts", new object[] { currentUser.UserID, craft.CraftsName, craft.Remark });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductCrafts pc = GetProductCraftsFrom(table.Rows[0]);
                    if (pc != null)
                    {
                        if (!crafts.ContainsKey(pc.CraftsID))
                            crafts[pc.CraftsID] = pc;
                        else AssignNewCrafts(pc);
                        return pc;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductCrafts UpdateCrafts(ProductCrafts craft)
        {
            if (craft == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "UpdateProductCrafts", new object[] { currentUser.UserID, craft.CraftsID, craft.CraftsName, craft.Remark });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductCrafts pc = GetProductCraftsFrom(table.Rows[0]);
                    if (pc != null)
                    {
                        if (!crafts.ContainsKey(pc.CraftsID))
                            crafts[pc.CraftsID] = pc;
                        else AssignNewCrafts(pc);
                        return pc;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductMaterial CreateMaterial(ProductMaterial material)
        {
            if (material == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "InsertProductMaterial", new object[] { currentUser.UserID, material.MaterialName, material.Remark });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductMaterial pm = GetProductMaterialFrom(table.Rows[0]);
                    if (pm != null)
                    {
                        if (!materials.ContainsKey(pm.MaterialID))
                            materials[pm.MaterialID] = pm;
                        else AssignNewMaterial(pm);
                        return pm;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductMaterial UpdateMaterial(ProductMaterial material)
        {
            if (material == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "UpdateProductMaterial", new object[] { currentUser.UserID, material.MaterialID, material.MaterialName, material.Remark });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    ProductMaterial pm = GetProductMaterialFrom(table.Rows[0]);
                    if (pm != null)
                    {
                        if (!materials.ContainsKey(pm.MaterialID))
                            materials[pm.MaterialID] = pm;
                        else AssignNewMaterial(pm);
                        return pm;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public ProductInfo UpdateProductStock(string productID, int increment)
        {
            if (productID == null || productID.Trim() == "") return null;
            ProductInfo pi = ProductOf(productID);
            if (pi == null) return null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "UpdateProductStock", new object[] { currentUser.UserID, productID, increment });
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    pi.Stock = Formatter.GetIntValueFrom(table.Rows[0], "Stock");
                    return pi;
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public void GetProducts()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "GetProducts", null);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        ProductInfo pi = GetProductInfoFrom(row);
                        if (pi != null)
                        {
                            if (!products.ContainsKey(pi.ProductID))
                                products[pi.ProductID] = pi;
                            else
                                AssignNewProduct(pi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public void GetCategories()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "GetProductCategory", null);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        ProductCategory pc = GetProductCategoryFrom(row);
                        if (pc != null)
                        {
                            if (!categories.ContainsKey(pc.CategoryID))
                                categories[pc.CategoryID] = pc;
                            else AssignNewCategory(pc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public void GetSubCategories()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "GetProductSubCategory", null);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        ProductSubCategory psc = GetProductSubCategoryFrom(row);
                        if (psc != null)
                        {
                            if (!subCategories.ContainsKey(psc.SubCategoryID))
                                subCategories[psc.SubCategoryID] = psc;
                            else AssignNewSubCategory(psc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public void GetStatus()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "GetProductStatus", null);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        ProductStatus ps = GetProductStatusFrom(row);
                        if (ps != null)
                        {
                            if (!statusList.ContainsKey(ps.StatusID))
                                statusList[ps.StatusID] = ps;
                            else AssignNewStatus(ps);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public void GetStyle()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "GetProductStyle", null);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        ProductStyle ps = GetProductStyleFrom(row);
                        if (ps != null)
                        {
                            if (!styleList.ContainsKey(ps.StyleID))
                                styleList[ps.StyleID] = ps;
                            else AssignNewStyle(ps);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public void GetOrigins()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "GetProductOrigin", null);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        ProductOrigin po = GetProductOriginFrom(row);
                        if (po != null)
                        {
                            if (!origins.ContainsKey(po.OriginID))
                                origins[po.OriginID] = po;
                            else AssignNewOrigin(po);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public void GetColors()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "GetProductColor", null);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        ProductColor pc = GetProductColorFrom(row);
                        if (pc != null)
                        {
                            if (!colors.ContainsKey(pc.ColorID))
                                colors[pc.ColorID] = pc;
                            else AssignNewColor(pc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public void GetCrafts()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "GetProductCrafts", null);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        ProductCrafts pc = GetProductCraftsFrom(row);
                        if (pc != null)
                        {
                            if (!crafts.ContainsKey(pc.CraftsID))
                                crafts[pc.CraftsID] = pc;
                            else AssignNewCrafts(pc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public void GetMaterials()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sqlConn, "GetProductMaterial", null);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        ProductMaterial pm = GetProductMaterialFrom(row);
                        if (pm != null)
                        {
                            if (!materials.ContainsKey(pm.MaterialID))
                                materials[pm.MaterialID] = pm;
                            else AssignNewMaterial(pm);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        private ProductCategory GetProductCategoryFrom(DataRow row)
        {
            if (row == null) return null;
            ProductCategory pc = new ProductCategory();
            pc.CategoryID = Formatter.GetStringValueFrom(row, "CategoryID");
            pc.CategoryName = Formatter.GetStringValueFrom(row, "CategoryName");
            pc.Remark = Formatter.GetStringValueFrom(row, "Remark");
            return pc;
        }

        private void AssignNewCategory(ProductCategory item)
        {
            if (item == null) return;
            if (!categories.ContainsKey(item.CategoryID)) return;
            ProductCategory oldItem = categories[item.CategoryID];
            oldItem.CategoryName = item.CategoryName;
            oldItem.Remark = item.Remark;
        }

        private ProductSubCategory GetProductSubCategoryFrom(DataRow row)
        {
            if (row == null) return null;
            ProductSubCategory psc = new ProductSubCategory();
            psc.CategoryID = Formatter.GetStringValueFrom(row, "CategoryID");
            psc.Remark = Formatter.GetStringValueFrom(row, "Remark");
            psc.SubCategoryID = Formatter.GetStringValueFrom(row, "SubCategoryID");
            psc.SubCategoryName = Formatter.GetStringValueFrom(row, "SubCategoryName");
            return psc;
        }

        private void AssignNewSubCategory(ProductSubCategory item)
        {
            if (item == null) return;
            if (!subCategories.ContainsKey(item.SubCategoryID)) return;
            ProductSubCategory oldItem = subCategories[item.SubCategoryID];
            oldItem.SubCategoryName = item.SubCategoryName;
            oldItem.Remark = item.Remark;
        }

        private ProductOrigin GetProductOriginFrom(DataRow row)
        {
            if (row == null) return null;
            ProductOrigin po = new ProductOrigin();
            po.OriginID = Formatter.GetStringValueFrom(row, "OriginID");
            po.OriginName = Formatter.GetStringValueFrom(row, "OriginName");
            po.Remark = Formatter.GetStringValueFrom(row, "Remark");
            return po;
        }

        private void AssignNewOrigin(ProductOrigin item)
        {
            if (item == null) return;
            if (!origins.ContainsKey(item.OriginID)) return;
            ProductOrigin oldItem = origins[item.OriginID];
            oldItem.OriginName = item.OriginName;
            oldItem.Remark = item.Remark;
        }

        private ProductStatus GetProductStatusFrom(DataRow row)
        {
            if (row == null) return null;
            ProductStatus ps = new ProductStatus();
            ps.Remark = Formatter.GetStringValueFrom(row, "Remark");
            ps.StatusID = Formatter.GetStringValueFrom(row, "StatusID");
            ps.StatusName = Formatter.GetStringValueFrom(row, "StatusName");
            return ps;
        }

        private void AssignNewStatus(ProductStatus item)
        {
            if (item == null) return;
            if (!statusList.ContainsKey(item.StatusID)) return;
            ProductStatus oldItem = statusList[item.StatusID];
            oldItem.StatusName = item.StatusName;
            oldItem.Remark = item.Remark;
        }

        private ProductStyle GetProductStyleFrom(DataRow row)
        {
            if (row == null) return null;
            ProductStyle ps = new ProductStyle();
            ps.Remark = Formatter.GetStringValueFrom(row, "Remark");
            ps.StyleID = Formatter.GetStringValueFrom(row, "StyleID");
            ps.StyleName = Formatter.GetStringValueFrom(row, "StyleName");
            return ps;
        }

        private void AssignNewStyle(ProductStyle item)
        {
            if (item == null) return;
            if (!styleList.ContainsKey(item.StyleID)) return;
            ProductStyle oldItem = styleList[item.StyleID];
            oldItem.Remark = item.Remark;
            oldItem.StyleName = item.StyleName;
        }

        private ProductColor GetProductColorFrom(DataRow row)
        {
            if (row == null) return null;
            ProductColor pc = new ProductColor();
            pc.ColorID = Formatter.GetStringValueFrom(row, "ColorID");
            pc.ColorName = Formatter.GetStringValueFrom(row, "ColorName");
            pc.Remark = Formatter.GetStringValueFrom(row, "Remark");
            return pc;
        }

        private void AssignNewColor(ProductColor item)
        {
            if (item == null) return;
            if (!colors.ContainsKey(item.ColorID)) return;
            ProductColor oldItem = colors[item.ColorID];
            oldItem.ColorName = item.ColorName;
            oldItem.Remark = item.Remark;
        }

        private ProductCrafts GetProductCraftsFrom(DataRow row)
        {
            if (row == null) return null;
            ProductCrafts pc = new ProductCrafts();
            pc.CraftsID = Formatter.GetStringValueFrom(row, "CraftsID");
            pc.CraftsName = Formatter.GetStringValueFrom(row, "CraftsName");
            pc.Remark = Formatter.GetStringValueFrom(row, "Remark");
            return pc;
        }

        private void AssignNewCrafts(ProductCrafts item)
        {
            if (item == null) return;
            if (!crafts.ContainsKey(item.CraftsID)) return;
            ProductCrafts oldItem = crafts[item.CraftsID];
            oldItem.CraftsName = item.CraftsName;
            oldItem.Remark = item.Remark;
        }

        private ProductMaterial GetProductMaterialFrom(DataRow row)
        {
            if (row == null) return null;
            ProductMaterial pc = new ProductMaterial();
            pc.MaterialID = Formatter.GetStringValueFrom(row, "MaterialID");
            pc.MaterialName = Formatter.GetStringValueFrom(row, "MaterialName");
            pc.Remark = Formatter.GetStringValueFrom(row, "Remark");
            return pc;
        }

        private void AssignNewMaterial(ProductMaterial item)
        {
            if (item == null) return;
            if (!materials.ContainsKey(item.MaterialID)) return;
            ProductMaterial oldItem = materials[item.MaterialID];
            oldItem.MaterialName = item.MaterialName;
            oldItem.Remark = item.Remark;
        }

        private ProductInfo GetProductInfoFrom(DataRow row)
        {
            if (row == null) return null;
            ProductInfo pi = new ProductInfo();
            pi.ProductID = Formatter.GetStringValueFrom(row, "ProductID");
            pi.ProductName = Formatter.GetStringValueFrom(row, "ProductName");
            pi.CategoryName = Formatter.GetStringValueFrom(row, "CategoryName");
            pi.Color = Formatter.GetStringValueFrom(row, "ColorName");
            pi.Crafts = Formatter.GetStringValueFrom(row, "CraftsName");
            pi.CreateDate = Formatter.GetDateTimeValueFrom(row, "CreateDate");
            pi.Image = Formatter.GetImageFrom(row, "Image");
            pi.Material = Formatter.GetStringValueFrom(row, "MaterialName");
            pi.ModifiedDate = Formatter.GetDateTimeValueFrom(row, "ModifiedDate");
            pi.OriginName = Formatter.GetStringValueFrom(row, "OriginName");
            pi.ProductionDate = Formatter.GetDateTimeValueFrom(row, "ProductionDate");
            pi.Quantity = Formatter.GetStringValueFrom(row, "Quantity");
            pi.Specification = Formatter.GetStringValueFrom(row, "Spec");
            pi.StatusName = Formatter.GetStringValueFrom(row, "StatusName");
            pi.StyleName = Formatter.GetStringValueFrom(row, "StyleName");
            pi.SubCategoryName = Formatter.GetStringValueFrom(row, "SubCategoryName");
            pi.Weight = Formatter.GetStringValueFrom(row, "Weight");
            pi.Remark = Formatter.GetStringValueFrom(row, "Remark");
            pi.CategoryID = Formatter.GetStringValueFrom(row, "CategoryID");
            pi.ColorID = Formatter.GetStringValueFrom(row, "ColorID");
            pi.CraftsID = Formatter.GetStringValueFrom(row, "CraftsID");
            pi.MaterialID = Formatter.GetStringValueFrom(row, "MaterialID");
            pi.OriginID = Formatter.GetStringValueFrom(row, "OriginID");
            pi.StatusID = Formatter.GetStringValueFrom(row, "StatusID");
            pi.StyleID = Formatter.GetStringValueFrom(row, "StyleID");
            pi.SubCategoryID = Formatter.GetStringValueFrom(row, "SubCategoryID");
            pi.Stock = Formatter.GetIntValueFrom(row, "Stock");
            return pi;
        }

        private void AssignNewProduct(ProductInfo pi)
        {
            if (pi == null) return;
            if (products == null) return;
            if (!products.ContainsKey(pi.ProductID)) return;
            ProductInfo oldProduct = products[pi.ProductID];
            oldProduct.ProductName = pi.ProductName;
            oldProduct.CategoryName = pi.CategoryName;
            oldProduct.Color = pi.Color;
            oldProduct.Crafts = pi.Crafts;
            oldProduct.CreateDate = pi.CreateDate;
            oldProduct.Image = pi.Image;
            oldProduct.Material = pi.Material;
            oldProduct.ModifiedDate = pi.ModifiedDate;
            oldProduct.OriginName = pi.OriginName;
            oldProduct.ProductionDate = pi.ProductionDate;
            oldProduct.Quantity = pi.Quantity;
            oldProduct.Specification = pi.Specification;
            oldProduct.StatusName = pi.StatusName;
            oldProduct.StyleName = pi.StyleName;
            oldProduct.SubCategoryName = pi.SubCategoryName;
            oldProduct.Weight = pi.Weight;
            oldProduct.Remark = pi.Remark;
            oldProduct.CategoryID = pi.CategoryID;
            oldProduct.ColorID = pi.ColorID;
            oldProduct.CraftsID = pi.CraftsID;
            oldProduct.MaterialID = pi.MaterialID;
            oldProduct.OriginID = pi.OriginID;
            oldProduct.StatusID = pi.StatusID;
            oldProduct.StyleID = pi.StyleID;
            oldProduct.SubCategoryID = pi.SubCategoryID;
            oldProduct.Stock = pi.Stock;
        }
    }

    public class ProductUpdateEventArgs : EventArgs
    {
        protected ProductInfo pi;

        public ProductUpdateEventArgs(ProductInfo pi)
        {
            this.pi = pi;
        }

        public ProductInfo Product { get { return pi; } }
    }
}
