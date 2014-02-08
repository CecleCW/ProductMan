namespace ProductMan.Panes
{
    partial class ProductPane
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductPane));
            BinaryComponents.SuperList.Sections.SectionFactory sectionFactory1 = new BinaryComponents.SuperList.Sections.SectionFactory();
            this.captionPane1 = new ProductMan.Panes.CaptionPane();
            this.searchPane1 = new ProductMan.Panes.SearchPane();
            this.filterPane1 = new ProductMan.Panes.FilterPane();
            this.listControl1 = new BinaryComponents.SuperList.ListControl();
            this.SuspendLayout();
            // 
            // captionPane1
            // 
            this.captionPane1.AllowActive = false;
            this.captionPane1.AntiAlias = false;
            this.captionPane1.Caption = "Products";
            resources.ApplyResources(this.captionPane1, "captionPane1");
            this.captionPane1.Name = "captionPane1";
            // 
            // searchPane1
            // 
            this.searchPane1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.searchPane1.Caption = "Search";
            this.searchPane1.ConditionIndex = -1;
            resources.ApplyResources(this.searchPane1, "searchPane1");
            this.searchPane1.Hints = "";
            this.searchPane1.Name = "searchPane1";
            // 
            // filterPane1
            // 
            this.filterPane1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            resources.ApplyResources(this.filterPane1, "filterPane1");
            this.filterPane1.Name = "filterPane1";
            // 
            // listControl1
            // 
            this.listControl1.AllowDrop = true;
            this.listControl1.AllowRowDragDrop = false;
            this.listControl1.AllowSorting = true;
            this.listControl1.AlternatingRowColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.listControl1, "listControl1");
            this.listControl1.FocusedItem = null;
            this.listControl1.GroupSectionFont = null;
            this.listControl1.GroupSectionForeColor = System.Drawing.SystemColors.WindowText;
            this.listControl1.GroupSectionTextPlural = "Items";
            this.listControl1.GroupSectionTextSingular = "Item";
            this.listControl1.GroupSectionVerticalAlignment = BinaryComponents.WinFormsUtility.Drawing.GdiPlusEx.VAlignment.Top;
            this.listControl1.IndentColor = System.Drawing.Color.LightGoldenrodYellow;
            this.listControl1.MultiSelect = false;
            this.listControl1.Name = "listControl1";
            this.listControl1.SectionFactory = sectionFactory1;
            this.listControl1.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this.listControl1.ShowCustomizeSection = true;
            this.listControl1.ShowHeaderSection = true;
            // 
            // ProductPane
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listControl1);
            this.Controls.Add(this.filterPane1);
            this.Controls.Add(this.searchPane1);
            this.Controls.Add(this.captionPane1);
            this.Name = "ProductPane";
            this.ResumeLayout(false);

        }

        #endregion

        private CaptionPane captionPane1;
        private SearchPane searchPane1;
        private FilterPane filterPane1;
        private BinaryComponents.SuperList.ListControl listControl1;
    }
}
