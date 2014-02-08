namespace ProductMan
{
    partial class NewParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewParameter));
            this.lbl_Name = new System.Windows.Forms.Label();
            this.wtbx_Name = new ProductMan.Components.WaterMarkTextBox();
            this.lbl_Remark = new System.Windows.Forms.Label();
            this.rtbx_Remark = new System.Windows.Forms.RichTextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            resources.ApplyResources(this.lbl_Name, "lbl_Name");
            this.lbl_Name.Name = "lbl_Name";
            // 
            // wtbx_Name
            // 
            this.wtbx_Name.FocusSelect = true;
            resources.ApplyResources(this.wtbx_Name, "wtbx_Name");
            this.wtbx_Name.Name = "wtbx_Name";
            this.wtbx_Name.WaterMark = "Parameter name...";
            this.wtbx_Name.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wtbx_Name.WaterMarkForeColor = System.Drawing.SystemColors.GrayText;
            // 
            // lbl_Remark
            // 
            resources.ApplyResources(this.lbl_Remark, "lbl_Remark");
            this.lbl_Remark.Name = "lbl_Remark";
            // 
            // rtbx_Remark
            // 
            resources.ApplyResources(this.rtbx_Remark, "rtbx_Remark");
            this.rtbx_Remark.Name = "rtbx_Remark";
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
            // NewParameter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.rtbx_Remark);
            this.Controls.Add(this.lbl_Remark);
            this.Controls.Add(this.wtbx_Name);
            this.Controls.Add(this.lbl_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewParameter";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private ProductMan.Components.WaterMarkTextBox wtbx_Name;
        private System.Windows.Forms.Label lbl_Remark;
        private System.Windows.Forms.RichTextBox rtbx_Remark;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}