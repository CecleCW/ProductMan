namespace ProductMan.Panes
{
    partial class FilterPane
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_FilterTitle = new System.Windows.Forms.Label();
            this.clb_Options = new System.Windows.Forms.CheckedListBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbl_FilterTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.clb_Options);
            this.splitContainer1.Size = new System.Drawing.Size(395, 20);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbl_FilterTitle
            // 
            this.lbl_FilterTitle.AutoSize = true;
            this.lbl_FilterTitle.Location = new System.Drawing.Point(5, 3);
            this.lbl_FilterTitle.Name = "lbl_FilterTitle";
            this.lbl_FilterTitle.Size = new System.Drawing.Size(34, 13);
            this.lbl_FilterTitle.TabIndex = 0;
            this.lbl_FilterTitle.Text = "Filters";
            // 
            // clb_Options
            // 
            this.clb_Options.CheckOnClick = true;
            this.clb_Options.ColumnWidth = 80;
            this.clb_Options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clb_Options.FormattingEnabled = true;
            this.clb_Options.Location = new System.Drawing.Point(0, 0);
            this.clb_Options.MultiColumn = true;
            this.clb_Options.Name = "clb_Options";
            this.clb_Options.Size = new System.Drawing.Size(347, 19);
            this.clb_Options.TabIndex = 0;
            // 
            // FilterPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FilterPane";
            this.Size = new System.Drawing.Size(395, 20);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_FilterTitle;
        private System.Windows.Forms.CheckedListBox clb_Options;

    }
}
