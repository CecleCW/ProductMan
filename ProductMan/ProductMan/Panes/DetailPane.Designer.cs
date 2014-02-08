using ProductMan.Components;
namespace ProductMan.Panes
{
    partial class DetailPane
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailPane));
            this.panel_Title = new System.Windows.Forms.Panel();
            this.lbl_AssignedTo = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.cpPane_Remark = new ProductMan.Panes.CaptionPane();
            this.cpPane_Description = new ProductMan.Panes.CaptionPane();
            this.captionPane1 = new ProductMan.Panes.CaptionPane();
            this.panel_DetailRemark = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbx_Description = new System.Windows.Forms.RichTextBox();
            this.rtbx_Remark = new System.Windows.Forms.RichTextBox();
            this.panel_Title.SuspendLayout();
            this.panel_DetailRemark.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Title
            // 
            this.panel_Title.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Title.BackgroundImage")));
            this.panel_Title.Controls.Add(this.lbl_AssignedTo);
            this.panel_Title.Controls.Add(this.lbl_Title);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(400, 78);
            this.panel_Title.TabIndex = 2;
            // 
            // lbl_AssignedTo
            // 
            this.lbl_AssignedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_AssignedTo.AutoEllipsis = true;
            this.lbl_AssignedTo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_AssignedTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AssignedTo.Location = new System.Drawing.Point(8, 53);
            this.lbl_AssignedTo.Name = "lbl_AssignedTo";
            this.lbl_AssignedTo.Size = new System.Drawing.Size(381, 15);
            this.lbl_AssignedTo.TabIndex = 1;
            this.lbl_AssignedTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Title.AutoEllipsis = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(8, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(381, 35);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cpPane_Remark
            // 
            this.cpPane_Remark.AllowActive = false;
            this.cpPane_Remark.AntiAlias = false;
            this.cpPane_Remark.Caption = "Remark";
            this.cpPane_Remark.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpPane_Remark.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpPane_Remark.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.cpPane_Remark.InactiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(250)))));
            this.cpPane_Remark.InactiveTextColor = System.Drawing.Color.Black;
            this.cpPane_Remark.Location = new System.Drawing.Point(0, 0);
            this.cpPane_Remark.Name = "cpPane_Remark";
            this.cpPane_Remark.Size = new System.Drawing.Size(400, 24);
            this.cpPane_Remark.TabIndex = 7;
            // 
            // cpPane_Description
            // 
            this.cpPane_Description.AllowActive = false;
            this.cpPane_Description.AntiAlias = false;
            this.cpPane_Description.Caption = "Description";
            this.cpPane_Description.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpPane_Description.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpPane_Description.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.cpPane_Description.InactiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(250)))));
            this.cpPane_Description.InactiveTextColor = System.Drawing.Color.Black;
            this.cpPane_Description.Location = new System.Drawing.Point(0, 0);
            this.cpPane_Description.Name = "cpPane_Description";
            this.cpPane_Description.Size = new System.Drawing.Size(400, 24);
            this.cpPane_Description.TabIndex = 5;
            // 
            // captionPane1
            // 
            this.captionPane1.AllowActive = false;
            this.captionPane1.AntiAlias = false;
            this.captionPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.captionPane1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.captionPane1.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.captionPane1.InactiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.captionPane1.Location = new System.Drawing.Point(0, 0);
            this.captionPane1.Margin = new System.Windows.Forms.Padding(5);
            this.captionPane1.Name = "captionPane1";
            this.captionPane1.Size = new System.Drawing.Size(400, 537);
            this.captionPane1.TabIndex = 1;
            // 
            // panel_DetailRemark
            // 
            this.panel_DetailRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.panel_DetailRemark.Controls.Add(this.splitContainer1);
            this.panel_DetailRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DetailRemark.Location = new System.Drawing.Point(0, 78);
            this.panel_DetailRemark.Name = "panel_DetailRemark";
            this.panel_DetailRemark.Size = new System.Drawing.Size(400, 459);
            this.panel_DetailRemark.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbx_Description);
            this.splitContainer1.Panel1.Controls.Add(this.cpPane_Description);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbx_Remark);
            this.splitContainer1.Panel2.Controls.Add(this.cpPane_Remark);
            this.splitContainer1.Size = new System.Drawing.Size(400, 459);
            this.splitContainer1.SplitterDistance = 243;
            this.splitContainer1.TabIndex = 0;
            // 
            // rtbx_Description
            // 
            this.rtbx_Description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(250)))));
            this.rtbx_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbx_Description.Location = new System.Drawing.Point(0, 24);
            this.rtbx_Description.Name = "rtbx_Description";
            this.rtbx_Description.ReadOnly = true;
            this.rtbx_Description.Size = new System.Drawing.Size(400, 219);
            this.rtbx_Description.TabIndex = 6;
            this.rtbx_Description.Text = "";
            // 
            // rtbx_Remark
            // 
            this.rtbx_Remark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(250)))));
            this.rtbx_Remark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbx_Remark.Location = new System.Drawing.Point(0, 24);
            this.rtbx_Remark.Name = "rtbx_Remark";
            this.rtbx_Remark.ReadOnly = true;
            this.rtbx_Remark.Size = new System.Drawing.Size(400, 188);
            this.rtbx_Remark.TabIndex = 8;
            this.rtbx_Remark.Text = "";
            // 
            // DetailPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel_DetailRemark);
            this.Controls.Add(this.panel_Title);
            this.Controls.Add(this.captionPane1);
            this.Name = "DetailPane";
            this.Size = new System.Drawing.Size(400, 537);
            this.panel_Title.ResumeLayout(false);
            this.panel_DetailRemark.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CaptionPane captionPane1;
        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.Label lbl_Title;
        private CaptionPane cpPane_Description;
        private System.Windows.Forms.Label lbl_AssignedTo;
        private CaptionPane cpPane_Remark;
        private System.Windows.Forms.Panel panel_DetailRemark;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbx_Description;
        private System.Windows.Forms.RichTextBox rtbx_Remark;

    }
}
