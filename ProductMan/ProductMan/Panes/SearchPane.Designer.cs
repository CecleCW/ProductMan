using ProductMan.Components;
namespace ProductMan.Panes
{
    partial class SearchPane
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchPane));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_Caption = new System.Windows.Forms.Label();
            this.wtbx_Input = new ProductMan.Components.WaterMarkTextBox();
            this.cbx_Type = new System.Windows.Forms.ComboBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
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
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Caption);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.wtbx_Input);
            this.splitContainer1.Panel2.Controls.Add(this.cbx_Type);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Size = new System.Drawing.Size(320, 18);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbl_Caption
            // 
            this.lbl_Caption.AutoSize = true;
            this.lbl_Caption.Location = new System.Drawing.Point(3, 1);
            this.lbl_Caption.Name = "lbl_Caption";
            this.lbl_Caption.Size = new System.Drawing.Size(0, 13);
            this.lbl_Caption.TabIndex = 0;
            // 
            // wtbx_Input
            // 
            this.wtbx_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wtbx_Input.FocusSelect = true;
            this.wtbx_Input.Location = new System.Drawing.Point(94, 0);
            this.wtbx_Input.Name = "wtbx_Input";
            this.wtbx_Input.Size = new System.Drawing.Size(158, 20);
            this.wtbx_Input.TabIndex = 2;
            this.wtbx_Input.WaterMark = "";
            this.wtbx_Input.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wtbx_Input.WaterMarkForeColor = System.Drawing.SystemColors.GrayText;
            // 
            // cbx_Type
            // 
            this.cbx_Type.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbx_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Type.FormattingEnabled = true;
            this.cbx_Type.Location = new System.Drawing.Point(0, 0);
            this.cbx_Type.Name = "cbx_Type";
            this.cbx_Type.Size = new System.Drawing.Size(94, 21);
            this.cbx_Type.TabIndex = 1;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(252, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(20, 18);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // SearchPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SearchPane";
            this.Size = new System.Drawing.Size(320, 18);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_Caption;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ComboBox cbx_Type;
        private WaterMarkTextBox wtbx_Input;
    }
}
