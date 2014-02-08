namespace ProductMan
{
    partial class ParameterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterForm));
            this.lbl_ParameterType = new System.Windows.Forms.Label();
            this.cbx_ParamType = new System.Windows.Forms.ComboBox();
            this.gbx_Parameters = new System.Windows.Forms.GroupBox();
            this.rtbx_Remark = new System.Windows.Forms.RichTextBox();
            this.lbl_Remark = new System.Windows.Forms.Label();
            this.cbx_ParamName = new System.Windows.Forms.ComboBox();
            this.lbl_ParamName = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.gbx_Parameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_ParameterType
            // 
            resources.ApplyResources(this.lbl_ParameterType, "lbl_ParameterType");
            this.lbl_ParameterType.Name = "lbl_ParameterType";
            // 
            // cbx_ParamType
            // 
            this.cbx_ParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ParamType.FormattingEnabled = true;
            this.cbx_ParamType.Items.AddRange(new object[] {
            resources.GetString("cbx_ParamType.Items"),
            resources.GetString("cbx_ParamType.Items1"),
            resources.GetString("cbx_ParamType.Items2"),
            resources.GetString("cbx_ParamType.Items3"),
            resources.GetString("cbx_ParamType.Items4")});
            resources.ApplyResources(this.cbx_ParamType, "cbx_ParamType");
            this.cbx_ParamType.Name = "cbx_ParamType";
            this.cbx_ParamType.SelectedIndexChanged += new System.EventHandler(this.cbx_ParamType_SelectedIndexChanged);
            // 
            // gbx_Parameters
            // 
            this.gbx_Parameters.Controls.Add(this.rtbx_Remark);
            this.gbx_Parameters.Controls.Add(this.lbl_Remark);
            this.gbx_Parameters.Controls.Add(this.cbx_ParamName);
            this.gbx_Parameters.Controls.Add(this.lbl_ParamName);
            this.gbx_Parameters.Controls.Add(this.lbl_ParameterType);
            this.gbx_Parameters.Controls.Add(this.cbx_ParamType);
            resources.ApplyResources(this.gbx_Parameters, "gbx_Parameters");
            this.gbx_Parameters.Name = "gbx_Parameters";
            this.gbx_Parameters.TabStop = false;
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
            // cbx_ParamName
            // 
            this.cbx_ParamName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ParamName.FormattingEnabled = true;
            resources.ApplyResources(this.cbx_ParamName, "cbx_ParamName");
            this.cbx_ParamName.Name = "cbx_ParamName";
            this.cbx_ParamName.SelectedIndexChanged += new System.EventHandler(this.cbx_ParamName_SelectedIndexChanged);
            // 
            // lbl_ParamName
            // 
            resources.ApplyResources(this.lbl_ParamName, "lbl_ParamName");
            this.lbl_ParamName.Name = "lbl_ParamName";
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
            // btn_New
            // 
            resources.ApplyResources(this.btn_New, "btn_New");
            this.btn_New.Name = "btn_New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // ParameterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.gbx_Parameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParameterForm";
            this.ShowInTaskbar = false;
            this.gbx_Parameters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ParameterType;
        private System.Windows.Forms.ComboBox cbx_ParamType;
        private System.Windows.Forms.GroupBox gbx_Parameters;
        private System.Windows.Forms.ComboBox cbx_ParamName;
        private System.Windows.Forms.Label lbl_ParamName;
        private System.Windows.Forms.RichTextBox rtbx_Remark;
        private System.Windows.Forms.Label lbl_Remark;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_New;
    }
}