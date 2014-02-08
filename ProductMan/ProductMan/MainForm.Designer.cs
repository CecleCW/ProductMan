namespace ProductMan
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CHSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_NewProduct = new System.Windows.Forms.ToolStripButton();
            this.stbtn_ModProduct = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_DeleteProduct = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_AddOne = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_AddN = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_DelOne = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_DelN = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.productToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productEditorToolStripMenuItem,
            this.productParametersToolStripMenuItem});
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            resources.ApplyResources(this.productToolStripMenuItem, "productToolStripMenuItem");
            // 
            // productEditorToolStripMenuItem
            // 
            resources.ApplyResources(this.productEditorToolStripMenuItem, "productEditorToolStripMenuItem");
            this.productEditorToolStripMenuItem.Name = "productEditorToolStripMenuItem";
            this.productEditorToolStripMenuItem.Click += new System.EventHandler(this.productEditorToolStripMenuItem_Click);
            // 
            // productParametersToolStripMenuItem
            // 
            this.productParametersToolStripMenuItem.Name = "productParametersToolStripMenuItem";
            resources.ApplyResources(this.productParametersToolStripMenuItem, "productParametersToolStripMenuItem");
            this.productParametersToolStripMenuItem.Click += new System.EventHandler(this.productParametersToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languagesToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.updateUserToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.CHSToolStripMenuItem});
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            resources.ApplyResources(this.languagesToolStripMenuItem, "languagesToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // CHSToolStripMenuItem
            // 
            this.CHSToolStripMenuItem.Name = "CHSToolStripMenuItem";
            resources.ApplyResources(this.CHSToolStripMenuItem, "CHSToolStripMenuItem");
            this.CHSToolStripMenuItem.Click += new System.EventHandler(this.CHSToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            resources.ApplyResources(this.changePasswordToolStripMenuItem, "changePasswordToolStripMenuItem");
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // updateUserToolStripMenuItem
            // 
            this.updateUserToolStripMenuItem.Name = "updateUserToolStripMenuItem";
            resources.ApplyResources(this.updateUserToolStripMenuItem, "updateUserToolStripMenuItem");
            this.updateUserToolStripMenuItem.Click += new System.EventHandler(this.updateUserToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_NewProduct,
            this.stbtn_ModProduct,
            this.tsbtn_DeleteProduct,
            this.tsbtn_AddOne,
            this.tsbtn_AddN,
            this.tsbtn_DelOne,
            this.tsbtn_DelN});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsbtn_NewProduct
            // 
            resources.ApplyResources(this.tsbtn_NewProduct, "tsbtn_NewProduct");
            this.tsbtn_NewProduct.Name = "tsbtn_NewProduct";
            this.tsbtn_NewProduct.Click += new System.EventHandler(this.tsbtn_NewProduct_Click);
            // 
            // stbtn_ModProduct
            // 
            resources.ApplyResources(this.stbtn_ModProduct, "stbtn_ModProduct");
            this.stbtn_ModProduct.Name = "stbtn_ModProduct";
            this.stbtn_ModProduct.Click += new System.EventHandler(this.stbtn_ModProduct_Click);
            // 
            // tsbtn_DeleteProduct
            // 
            resources.ApplyResources(this.tsbtn_DeleteProduct, "tsbtn_DeleteProduct");
            this.tsbtn_DeleteProduct.Name = "tsbtn_DeleteProduct";
            this.tsbtn_DeleteProduct.Click += new System.EventHandler(this.tsbtn_DeleteProduct_Click);
            // 
            // tsbtn_AddOne
            // 
            resources.ApplyResources(this.tsbtn_AddOne, "tsbtn_AddOne");
            this.tsbtn_AddOne.Name = "tsbtn_AddOne";
            this.tsbtn_AddOne.Click += new System.EventHandler(this.tsbtn_AddOne_Click);
            // 
            // tsbtn_AddN
            // 
            resources.ApplyResources(this.tsbtn_AddN, "tsbtn_AddN");
            this.tsbtn_AddN.Name = "tsbtn_AddN";
            this.tsbtn_AddN.Click += new System.EventHandler(this.tsbtn_AddN_Click);
            // 
            // tsbtn_DelOne
            // 
            resources.ApplyResources(this.tsbtn_DelOne, "tsbtn_DelOne");
            this.tsbtn_DelOne.Name = "tsbtn_DelOne";
            this.tsbtn_DelOne.Click += new System.EventHandler(this.tsbtn_DelOne_Click);
            // 
            // tsbtn_DelN
            // 
            resources.ApplyResources(this.tsbtn_DelN, "tsbtn_DelN");
            this.tsbtn_DelN.Name = "tsbtn_DelN";
            this.tsbtn_DelN.Click += new System.EventHandler(this.tsbtn_DelN_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CHSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbtn_NewProduct;
        private System.Windows.Forms.ToolStripButton stbtn_ModProduct;
        private System.Windows.Forms.ToolStripButton tsbtn_DeleteProduct;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbtn_AddOne;
        private System.Windows.Forms.ToolStripButton tsbtn_AddN;
        private System.Windows.Forms.ToolStripButton tsbtn_DelOne;
        private System.Windows.Forms.ToolStripButton tsbtn_DelN;
    }
}

