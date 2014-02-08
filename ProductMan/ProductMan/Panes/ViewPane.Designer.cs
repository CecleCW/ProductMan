namespace ProductMan.Panes
{
    partial class ViewPane
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
            BinaryComponents.SuperTree.Renderers.StandardRenderer standardRenderer1 = new BinaryComponents.SuperTree.Renderers.StandardRenderer();
            this.captionPane1 = new ProductMan.Panes.CaptionPane();
            this.treeControl1 = new BinaryComponents.SuperTree.TreeControl();
            this.SuspendLayout();
            // 
            // captionPane1
            // 
            this.captionPane1.AllowActive = false;
            this.captionPane1.AntiAlias = false;
            this.captionPane1.Caption = "View";
            this.captionPane1.Dock = System.Windows.Forms.DockStyle.Top;
            this.captionPane1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.captionPane1.Location = new System.Drawing.Point(0, 0);
            this.captionPane1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.captionPane1.Name = "captionPane1";
            this.captionPane1.Size = new System.Drawing.Size(229, 38);
            this.captionPane1.TabIndex = 0;
            // 
            // treeControl1
            // 
            this.treeControl1.Animate = false;
            this.treeControl1.AutoScroll = true;
            this.treeControl1.AutoScrollMinSize = new System.Drawing.Size(0, 8);
            this.treeControl1.BackColor = System.Drawing.SystemColors.Window;
            this.treeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeControl1.Location = new System.Drawing.Point(0, 38);
            this.treeControl1.Name = "treeControl1";
            this.treeControl1.Renderer = standardRenderer1;
            this.treeControl1.SelectedNode = null;
            this.treeControl1.Size = new System.Drawing.Size(229, 374);
            this.treeControl1.TabIndex = 1;
            // 
            // ViewPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeControl1);
            this.Controls.Add(this.captionPane1);
            this.Name = "ViewPane";
            this.Size = new System.Drawing.Size(229, 412);
            this.ResumeLayout(false);

        }

        #endregion

        private CaptionPane captionPane1;
        private BinaryComponents.SuperTree.TreeControl treeControl1;
    }
}
