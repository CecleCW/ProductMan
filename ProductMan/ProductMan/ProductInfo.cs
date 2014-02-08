using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ProductMan.Utilities;
using System.IO;

namespace ProductMan
{
    public class ProductCategory
    {
        private string categoryID;
        private string categoryName;
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        public string CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        public override string ToString()
        {
            if (categoryName != null) return categoryName;
            return base.ToString();
        }
    }

    public class ProductSubCategory
    {
        private string categoryID;
        private string subCategoryID;
        private string subCategoryName;
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string SubCategoryName
        {
            get { return subCategoryName; }
            set { subCategoryName = value; }
        }

        public string SubCategoryID
        {
            get { return subCategoryID; }
            set { subCategoryID = value; }
        }

        public string CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        public override string ToString()
        {
            if (subCategoryName != null) return subCategoryName;
            return base.ToString();
        }
    }

    public class ProductOrigin
    {
        private string originID;
        private string originName;
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string OriginName
        {
            get { return originName; }
            set { originName = value; }
        }

        public string OriginID
        {
            get { return originID; }
            set { originID = value; }
        }

        public override string ToString()
        {
            if (originName != null) return originName;
            return base.ToString();
        }
    }

    public class ProductStatus
    {
        private string statusID;
        private string statusName;
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string StatusName
        {
            get { return statusName; }
            set { statusName = value; }
        }

        public string StatusID
        {
            get { return statusID; }
            set { statusID = value; }
        }

        public override string ToString()
        {
            if (statusName != null) return statusName;
            return base.ToString();
        }
    }

    public class ProductStyle
    {
        private string styleID;
        private string styleName;
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string StyleName
        {
            get { return styleName; }
            set { styleName = value; }
        }

        public string StyleID
        {
            get { return styleID; }
            set { styleID = value; }
        }

        public override string ToString()
        {
            if (styleName != null) return styleName;
            return base.ToString();
        }
    }

    public class ProductColor
    {
        private string colorID;
        private string colorName;
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string ColorName
        {
            get { return colorName; }
            set { colorName = value; }
        }

        public string ColorID
        {
            get { return colorID; }
            set { colorID = value; }
        }

        public override string ToString()
        {
            if (colorName != null) return colorName;
            return base.ToString();
        }
    }

    public class ProductCrafts
    {
        private string craftsID;
        private string craftsName;
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string CraftsName
        {
            get { return craftsName; }
            set { craftsName = value; }
        }

        public string CraftsID
        {
            get { return craftsID; }
            set { craftsID = value; }
        }

        public override string ToString()
        {
            if (craftsName != null) return craftsName;
            return base.ToString();
        }
    }

    public class ProductMaterial
    {
        private string materialID;
        private string materialName;
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string MaterialName
        {
            get { return materialName; }
            set { materialName = value; }
        }

        public string MaterialID
        {
            get { return materialID; }
            set { materialID = value; }
        }

        public override string ToString()
        {
            if (materialName != null) return materialName;
            return base.ToString();
        }
    }

    public class ProductInfo
    {
        private string productID;
        private string productName;
        private DateTime productionDate;
        private DateTime createDate;
        private DateTime modifiedDate;
        private string quantity;
        private string specification;
        private string weight;
        private string material;
        private string color;
        private string crafts;
        private string remark;
        private Bitmap image;
        private string statusName;
        private string styleName;
        private string categoryName;
        private string subCategoryName;
        private string originName;
        private string styleID;
        private string categoryID;
        private string subCategoryID;
        private string statusID;
        private string originID;
        private string materialID;
        private string colorID;
        private string craftsID;
        private int stock;

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public string CraftsID
        {
            get { return craftsID; }
            set { craftsID = value; }
        }

        public string ColorID
        {
            get { return colorID; }
            set { colorID = value; }
        }

        public string MaterialID
        {
            get { return materialID; }
            set { materialID = value; }
        }

        public string OriginID
        {
            get { return originID; }
            set { originID = value; }
        }

        public string StatusID
        {
            get { return statusID; }
            set { statusID = value; }
        }

        public string SubCategoryID
        {
            get { return subCategoryID; }
            set { subCategoryID = value; }
        }

        public string CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        public string StyleID
        {
            get { return styleID; }
            set { styleID = value; }
        }

        public string OriginName
        {
            get { return originName; }
            set { originName = value; }
        }

        public string SubCategoryName
        {
            get { return subCategoryName; }
            set { subCategoryName = value; }
        }

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        public string StyleName
        {
            get { return styleName; }
            set { styleName = value; }
        }

        public string StatusName
        {
            get { return statusName; }
            set { statusName = value; }
        }

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }

        public string Crafts
        {
            get { return crafts; }
            set { crafts = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Specification
        {
            get { return specification; }
            set { specification = value; }
        }

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        public DateTime ProductionDate
        {
            get { return productionDate; }
            set { productionDate = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public override string ToString()
        {
            if (productName != null) return productName;
            return base.ToString();
        }

        public string Representation
        {
            get
            {
                return string.Format("{0} - {1}\r\n{2}", categoryName, subCategoryName, productName);
            }
        }

        public byte[] ImageArray
        {
            get
            {
                if (image == null) return null;
                try
                {
                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    byte[] bytes = ms.GetBuffer();
                    ms.Close();
                    return bytes;
                }
                catch { }
                return null;
            }
        }

        public bool HasMe(string keyword)
        {
            if (keyword != null && keyword.Trim() != "")
            {
                try
                {
                    string[] andPieces = keyword.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
                    if (andPieces != null && andPieces.Length > 0)
                    {
                        List<bool> bs = new List<bool>();
                        foreach (string item in andPieces)
                        {
                            string[] orPieces = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            bs.Add(OrRelationship(orPieces));
                        }
                        foreach (bool b in bs)
                        {
                            if (!b) return false;
                        }
                        return true;
                    }
                    else
                    {
                        string[] orPieces = keyword.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        return OrRelationship(orPieces);
                    }
                }
                catch (Exception ex)
                {
                    LoggerBase.Instance.Error(ex.ToString());
                }
                return false;
            }
            return true;
        }

        private bool OrRelationship(string[] orPieces)
        {
            if (orPieces != null && orPieces.Length > 0)
            {
                foreach (string item in orPieces)
                {
                    if (HasMe(productName, item)) return true;
                    //if (HasMe(styleName, item)) return true;
                    if (HasMe(categoryName, item)) return true;
                    if (HasMe(subCategoryName, item)) return true;
                    //if (HasMe(statusName, item)) return true;
                    //if (HasMe(originName, item)) return true;
                    if (HasMe(material, item)) return true;
                    if (HasMe(color, item)) return true;
                    if (HasMe(crafts, item)) return true;
                    if (HasMe(specification, item)) return true;
                    //if (HasMe(quantity, item)) return true;
                    //if (HasMe(weight, item)) return true;
                    if (HasMe(remark, item)) return true;
                }
            }
            return false;
        }

        private bool HasMe(string target, string keyword)
        {
            if (target != null)
            {
                if (target.Contains(keyword)) return true;
            }
            return false;
        }

        public List<object> GetCreateParams()
        {
            List<object> values = new List<object>();
            values.Add(DataService.Instance.CurrentUser.UserID);
            values.Add(productName);
            values.Add(styleID);
            values.Add(categoryID);
            values.Add(subCategoryID);
            values.Add(statusID);
            values.Add(originID);
            values.Add(materialID);
            values.Add(colorID);
            values.Add(craftsID);
            values.Add(productionDate);
            values.Add(quantity);
            values.Add(specification);
            values.Add(weight);
            values.Add(ImageArray);
            values.Add(remark);
            return values;
        }

        public List<object> GetUpdateParams()
        {
            List<object> values = GetCreateParams();
            values.Insert(1, productID);
            return values;
        }
    }
}
