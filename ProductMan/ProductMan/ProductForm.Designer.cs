namespace ProductMan
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.gbx_ProductSummary = new System.Windows.Forms.GroupBox();
            this.tbx_Stock = new System.Windows.Forms.TextBox();
            this.lbl_Stock = new System.Windows.Forms.Label();
            this.btn_Material = new System.Windows.Forms.Button();
            this.btn_Crafts = new System.Windows.Forms.Button();
            this.btn_Color = new System.Windows.Forms.Button();
            this.btn_Category = new System.Windows.Forms.Button();
            this.btn_SubCategory = new System.Windows.Forms.Button();
            this.cbx_Material = new System.Windows.Forms.ComboBox();
            this.lbl_Material = new System.Windows.Forms.Label();
            this.cbx_Crafts = new System.Windows.Forms.ComboBox();
            this.lbl_Crafts = new System.Windows.Forms.Label();
            this.cbx_Color = new System.Windows.Forms.ComboBox();
            this.lbl_Color = new System.Windows.Forms.Label();
            this.cbx_Status = new System.Windows.Forms.ComboBox();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.cbx_Origin = new System.Windows.Forms.ComboBox();
            this.lbl_Origin = new System.Windows.Forms.Label();
            this.cbx_SubCategory = new System.Windows.Forms.ComboBox();
            this.lbl_SubCategory = new System.Windows.Forms.Label();
            this.cbx_Category = new System.Windows.Forms.ComboBox();
            this.lbl_Category = new System.Windows.Forms.Label();
            this.cbx_Style = new System.Windows.Forms.ComboBox();
            this.lbl_Style = new System.Windows.Forms.Label();
            this.wtbx_ProductName = new ProductMan.Components.WaterMarkTextBox();
            this.dtp_ProductionDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_ProductionDate = new System.Windows.Forms.Label();
            this.lbl_ProductName = new System.Windows.Forms.Label();
            this.gbx_ProductDetail = new System.Windows.Forms.GroupBox();
            this.btn_Image = new System.Windows.Forms.Button();
            this.lbl_Image = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtbx_Remark = new System.Windows.Forms.RichTextBox();
            this.lbl_Remark = new System.Windows.Forms.Label();
            this.wtbx_Weight = new ProductMan.Components.WaterMarkTextBox();
            this.lbl_Weight = new System.Windows.Forms.Label();
            this.rtbx_Spec = new System.Windows.Forms.RichTextBox();
            this.lbl_Spec = new System.Windows.Forms.Label();
            this.wtbx_Qty = new ProductMan.Components.WaterMarkTextBox();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.gbx_ProductSummary.SuspendLayout();
            this.gbx_ProductDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbx_ProductSummary
            // 
            this.gbx_ProductSummary.Controls.Add(this.tbx_Stock);
            this.gbx_ProductSummary.Controls.Add(this.lbl_Stock);
            this.gbx_ProductSummary.Controls.Add(this.btn_Material);
            this.gbx_ProductSummary.Controls.Add(this.btn_Crafts);
            this.gbx_ProductSummary.Controls.Add(this.btn_Color);
            this.gbx_ProductSummary.Controls.Add(this.btn_Category);
            this.gbx_ProductSummary.Controls.Add(this.btn_SubCategory);
            this.gbx_ProductSummary.Controls.Add(this.cbx_Material);
            this.gbx_ProductSummary.Controls.Add(this.lbl_Material);
            this.gbx_ProductSummary.Controls.Add(this.cbx_Crafts);
            this.gbx_ProductSummary.Controls.Add(this.lbl_Crafts);
            this.gbx_ProductSummary.Controls.Add(this.cbx_Color);
            this.gbx_ProductSummary.Controls.Add(this.lbl_Color);
            this.gbx_ProductSummary.Controls.Add(this.cbx_Status);
            this.gbx_ProductSummary.Controls.Add(this.lbl_Status);
            this.gbx_ProductSummary.Controls.Add(this.cbx_Origin);
            this.gbx_ProductSummary.Controls.Add(this.lbl_Origin);
            this.gbx_ProductSummary.Controls.Add(this.cbx_SubCategory);
            this.gbx_ProductSummary.Controls.Add(this.lbl_SubCategory);
            this.gbx_ProductSummary.Controls.Add(this.cbx_Category);
            this.gbx_ProductSummary.Controls.Add(this.lbl_Category);
            this.gbx_ProductSummary.Controls.Add(this.cbx_Style);
            this.gbx_ProductSummary.Controls.Add(this.lbl_Style);
            this.gbx_ProductSummary.Controls.Add(this.wtbx_ProductName);
            this.gbx_ProductSummary.Controls.Add(this.dtp_ProductionDate);
            this.gbx_ProductSummary.Controls.Add(this.lbl_ProductionDate);
            this.gbx_ProductSummary.Controls.Add(this.lbl_ProductName);
            resources.ApplyResources(this.gbx_ProductSummary, "gbx_ProductSummary");
            this.gbx_ProductSummary.Name = "gbx_ProductSummary";
            this.gbx_ProductSummary.TabStop = false;
            // 
            // tbx_Stock
            // 
            resources.ApplyResources(this.tbx_Stock, "tbx_Stock");
            this.tbx_Stock.Name = "tbx_Stock";
            this.tbx_Stock.ReadOnly = true;
            // 
            // lbl_Stock
            // 
            resources.ApplyResources(this.lbl_Stock, "lbl_Stock");
            this.lbl_Stock.Name = "lbl_Stock";
            // 
            // btn_Material
            // 
            resources.ApplyResources(this.btn_Material, "btn_Material");
            this.btn_Material.Name = "btn_Material";
            this.btn_Material.UseVisualStyleBackColor = true;
            this.btn_Material.Click += new System.EventHandler(this.btn_Material_Click);
            // 
            // btn_Crafts
            // 
            resources.ApplyResources(this.btn_Crafts, "btn_Crafts");
            this.btn_Crafts.Name = "btn_Crafts";
            this.btn_Crafts.UseVisualStyleBackColor = true;
            this.btn_Crafts.Click += new System.EventHandler(this.btn_Crafts_Click);
            // 
            // btn_Color
            // 
            resources.ApplyResources(this.btn_Color, "btn_Color");
            this.btn_Color.Name = "btn_Color";
            this.btn_Color.UseVisualStyleBackColor = true;
            this.btn_Color.Click += new System.EventHandler(this.btn_Color_Click);
            // 
            // btn_Category
            // 
            resources.ApplyResources(this.btn_Category, "btn_Category");
            this.btn_Category.Name = "btn_Category";
            this.btn_Category.UseVisualStyleBackColor = true;
            this.btn_Category.Click += new System.EventHandler(this.btn_Category_Click);
            // 
            // btn_SubCategory
            // 
            resources.ApplyResources(this.btn_SubCategory, "btn_SubCategory");
            this.btn_SubCategory.Name = "btn_SubCategory";
            this.btn_SubCategory.UseVisualStyleBackColor = true;
            this.btn_SubCategory.Click += new System.EventHandler(this.btn_SubCategory_Click);
            // 
            // cbx_Material
            // 
            this.cbx_Material.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Material.FormattingEnabled = true;
            resources.ApplyResources(this.cbx_Material, "cbx_Material");
            this.cbx_Material.Name = "cbx_Material";
            // 
            // lbl_Material
            // 
            resources.ApplyResources(this.lbl_Material, "lbl_Material");
            this.lbl_Material.Name = "lbl_Material";
            // 
            // cbx_Crafts
            // 
            this.cbx_Crafts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Crafts.FormattingEnabled = true;
            resources.ApplyResources(this.cbx_Crafts, "cbx_Crafts");
            this.cbx_Crafts.Name = "cbx_Crafts";
            // 
            // lbl_Crafts
            // 
            resources.ApplyResources(this.lbl_Crafts, "lbl_Crafts");
            this.lbl_Crafts.Name = "lbl_Crafts";
            // 
            // cbx_Color
            // 
            this.cbx_Color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Color.FormattingEnabled = true;
            resources.ApplyResources(this.cbx_Color, "cbx_Color");
            this.cbx_Color.Name = "cbx_Color";
            // 
            // lbl_Color
            // 
            resources.ApplyResources(this.lbl_Color, "lbl_Color");
            this.lbl_Color.Name = "lbl_Color";
            // 
            // cbx_Status
            // 
            this.cbx_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Status.FormattingEnabled = true;
            resources.ApplyResources(this.cbx_Status, "cbx_Status");
            this.cbx_Status.Name = "cbx_Status";
            // 
            // lbl_Status
            // 
            resources.ApplyResources(this.lbl_Status, "lbl_Status");
            this.lbl_Status.Name = "lbl_Status";
            // 
            // cbx_Origin
            // 
            this.cbx_Origin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Origin.FormattingEnabled = true;
            resources.ApplyResources(this.cbx_Origin, "cbx_Origin");
            this.cbx_Origin.Name = "cbx_Origin";
            // 
            // lbl_Origin
            // 
            resources.ApplyResources(this.lbl_Origin, "lbl_Origin");
            this.lbl_Origin.Name = "lbl_Origin";
            // 
            // cbx_SubCategory
            // 
            this.cbx_SubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_SubCategory.FormattingEnabled = true;
            resources.ApplyResources(this.cbx_SubCategory, "cbx_SubCategory");
            this.cbx_SubCategory.Name = "cbx_SubCategory";
            // 
            // lbl_SubCategory
            // 
            resources.ApplyResources(this.lbl_SubCategory, "lbl_SubCategory");
            this.lbl_SubCategory.Name = "lbl_SubCategory";
            // 
            // cbx_Category
            // 
            this.cbx_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Category.FormattingEnabled = true;
            resources.ApplyResources(this.cbx_Category, "cbx_Category");
            this.cbx_Category.Name = "cbx_Category";
            this.cbx_Category.SelectedIndexChanged += new System.EventHandler(this.cbx_Category_SelectedIndexChanged);
            // 
            // lbl_Category
            // 
            resources.ApplyResources(this.lbl_Category, "lbl_Category");
            this.lbl_Category.Name = "lbl_Category";
            // 
            // cbx_Style
            // 
            this.cbx_Style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Style.FormattingEnabled = true;
            resources.ApplyResources(this.cbx_Style, "cbx_Style");
            this.cbx_Style.Name = "cbx_Style";
            // 
            // lbl_Style
            // 
            resources.ApplyResources(this.lbl_Style, "lbl_Style");
            this.lbl_Style.Name = "lbl_Style";
            // 
            // wtbx_ProductName
            // 
            this.wtbx_ProductName.FocusSelect = true;
            resources.ApplyResources(this.wtbx_ProductName, "wtbx_ProductName");
            this.wtbx_ProductName.Name = "wtbx_ProductName";
            this.wtbx_ProductName.WaterMark = "Product name...";
            this.wtbx_ProductName.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wtbx_ProductName.WaterMarkForeColor = System.Drawing.SystemColors.GrayText;
            // 
            // dtp_ProductionDate
            // 
            resources.ApplyResources(this.dtp_ProductionDate, "dtp_ProductionDate");
            this.dtp_ProductionDate.Name = "dtp_ProductionDate";
            // 
            // lbl_ProductionDate
            // 
            resources.ApplyResources(this.lbl_ProductionDate, "lbl_ProductionDate");
            this.lbl_ProductionDate.Name = "lbl_ProductionDate";
            // 
            // lbl_ProductName
            // 
            resources.ApplyResources(this.lbl_ProductName, "lbl_ProductName");
            this.lbl_ProductName.Name = "lbl_ProductName";
            // 
            // gbx_ProductDetail
            // 
            this.gbx_ProductDetail.Controls.Add(this.btn_Image);
            this.gbx_ProductDetail.Controls.Add(this.lbl_Image);
            this.gbx_ProductDetail.Controls.Add(this.pictureBox1);
            this.gbx_ProductDetail.Controls.Add(this.rtbx_Remark);
            this.gbx_ProductDetail.Controls.Add(this.lbl_Remark);
            this.gbx_ProductDetail.Controls.Add(this.wtbx_Weight);
            this.gbx_ProductDetail.Controls.Add(this.lbl_Weight);
            this.gbx_ProductDetail.Controls.Add(this.rtbx_Spec);
            this.gbx_ProductDetail.Controls.Add(this.lbl_Spec);
            this.gbx_ProductDetail.Controls.Add(this.wtbx_Qty);
            this.gbx_ProductDetail.Controls.Add(this.lbl_Quantity);
            resources.ApplyResources(this.gbx_ProductDetail, "gbx_ProductDetail");
            this.gbx_ProductDetail.Name = "gbx_ProductDetail";
            this.gbx_ProductDetail.TabStop = false;
            // 
            // btn_Image
            // 
            resources.ApplyResources(this.btn_Image, "btn_Image");
            this.btn_Image.Name = "btn_Image";
            this.btn_Image.UseVisualStyleBackColor = true;
            this.btn_Image.Click += new System.EventHandler(this.btn_Image_Click);
            // 
            // lbl_Image
            // 
            resources.ApplyResources(this.lbl_Image, "lbl_Image");
            this.lbl_Image.Name = "lbl_Image";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // rtbx_Remark
            // 
            resources.ApplyResources(this.rtbx_Remark, "rtbx_Remark");
            this.rtbx_Remark.Name = "rtbx_Remark";
            // 
            // lbl_Remark
            // 
            resources.ApplyResources(this.lbl_Remark, "lbl_Remark");
            this.lbl_Remark.Name = "lbl_Remark";
            // 
            // wtbx_Weight
            // 
            this.wtbx_Weight.FocusSelect = true;
            resources.ApplyResources(this.wtbx_Weight, "wtbx_Weight");
            this.wtbx_Weight.Name = "wtbx_Weight";
            this.wtbx_Weight.WaterMark = "Weight...";
            this.wtbx_Weight.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wtbx_Weight.WaterMarkForeColor = System.Drawing.SystemColors.GrayText;
            // 
            // lbl_Weight
            // 
            resources.ApplyResources(this.lbl_Weight, "lbl_Weight");
            this.lbl_Weight.Name = "lbl_Weight";
            // 
            // rtbx_Spec
            // 
            resources.ApplyResources(this.rtbx_Spec, "rtbx_Spec");
            this.rtbx_Spec.Name = "rtbx_Spec";
            // 
            // lbl_Spec
            // 
            resources.ApplyResources(this.lbl_Spec, "lbl_Spec");
            this.lbl_Spec.Name = "lbl_Spec";
            // 
            // wtbx_Qty
            // 
            this.wtbx_Qty.FocusSelect = true;
            resources.ApplyResources(this.wtbx_Qty, "wtbx_Qty");
            this.wtbx_Qty.Name = "wtbx_Qty";
            this.wtbx_Qty.WaterMark = "Quantity...";
            this.wtbx_Qty.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wtbx_Qty.WaterMarkForeColor = System.Drawing.SystemColors.GrayText;
            // 
            // lbl_Quantity
            // 
            resources.ApplyResources(this.lbl_Quantity, "lbl_Quantity");
            this.lbl_Quantity.Name = "lbl_Quantity";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            resources.ApplyResources(this.btn_OK, "btn_OK");
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // ProductForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.gbx_ProductDetail);
            this.Controls.Add(this.gbx_ProductSummary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.ShowInTaskbar = false;
            this.gbx_ProductSummary.ResumeLayout(false);
            this.gbx_ProductSummary.PerformLayout();
            this.gbx_ProductDetail.ResumeLayout(false);
            this.gbx_ProductDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_ProductSummary;
        private System.Windows.Forms.Label lbl_ProductName;
        private System.Windows.Forms.DateTimePicker dtp_ProductionDate;
        private System.Windows.Forms.Label lbl_ProductionDate;
        private ProductMan.Components.WaterMarkTextBox wtbx_ProductName;
        private System.Windows.Forms.ComboBox cbx_Category;
        private System.Windows.Forms.Label lbl_Category;
        private System.Windows.Forms.ComboBox cbx_Style;
        private System.Windows.Forms.Label lbl_Style;
        private System.Windows.Forms.ComboBox cbx_SubCategory;
        private System.Windows.Forms.Label lbl_SubCategory;
        private System.Windows.Forms.ComboBox cbx_Origin;
        private System.Windows.Forms.Label lbl_Origin;
        private System.Windows.Forms.ComboBox cbx_Status;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.GroupBox gbx_ProductDetail;
        private System.Windows.Forms.RichTextBox rtbx_Spec;
        private System.Windows.Forms.Label lbl_Spec;
        private ProductMan.Components.WaterMarkTextBox wtbx_Qty;
        private System.Windows.Forms.Label lbl_Quantity;
        private ProductMan.Components.WaterMarkTextBox wtbx_Weight;
        private System.Windows.Forms.Label lbl_Weight;
        private System.Windows.Forms.ComboBox cbx_Material;
        private System.Windows.Forms.Label lbl_Material;
        private System.Windows.Forms.ComboBox cbx_Crafts;
        private System.Windows.Forms.Label lbl_Crafts;
        private System.Windows.Forms.ComboBox cbx_Color;
        private System.Windows.Forms.Label lbl_Color;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rtbx_Remark;
        private System.Windows.Forms.Label lbl_Remark;
        private System.Windows.Forms.Label lbl_Image;
        private System.Windows.Forms.Button btn_SubCategory;
        private System.Windows.Forms.Button btn_Crafts;
        private System.Windows.Forms.Button btn_Color;
        private System.Windows.Forms.Button btn_Category;
        private System.Windows.Forms.Button btn_Material;
        private System.Windows.Forms.Button btn_Image;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox tbx_Stock;
        private System.Windows.Forms.Label lbl_Stock;
    }
}