namespace ProductMan
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.lbl_UserID = new System.Windows.Forms.Label();
            this.tbx_UserID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.tbx_Email = new System.Windows.Forms.TextBox();
            this.tbx_FullName = new System.Windows.Forms.TextBox();
            this.lbl_FullName = new System.Windows.Forms.Label();
            this.tbx_UserName = new System.Windows.Forms.TextBox();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_UserID
            // 
            resources.ApplyResources(this.lbl_UserID, "lbl_UserID");
            this.lbl_UserID.Name = "lbl_UserID";
            // 
            // tbx_UserID
            // 
            resources.ApplyResources(this.tbx_UserID, "tbx_UserID");
            this.tbx_UserID.Name = "tbx_UserID";
            this.tbx_UserID.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Email);
            this.groupBox1.Controls.Add(this.tbx_Email);
            this.groupBox1.Controls.Add(this.tbx_FullName);
            this.groupBox1.Controls.Add(this.lbl_FullName);
            this.groupBox1.Controls.Add(this.tbx_UserName);
            this.groupBox1.Controls.Add(this.lbl_UserName);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lbl_Email
            // 
            resources.ApplyResources(this.lbl_Email, "lbl_Email");
            this.lbl_Email.Name = "lbl_Email";
            // 
            // tbx_Email
            // 
            resources.ApplyResources(this.tbx_Email, "tbx_Email");
            this.tbx_Email.Name = "tbx_Email";
            // 
            // tbx_FullName
            // 
            resources.ApplyResources(this.tbx_FullName, "tbx_FullName");
            this.tbx_FullName.Name = "tbx_FullName";
            // 
            // lbl_FullName
            // 
            resources.ApplyResources(this.lbl_FullName, "lbl_FullName");
            this.lbl_FullName.Name = "lbl_FullName";
            // 
            // tbx_UserName
            // 
            resources.ApplyResources(this.tbx_UserName, "tbx_UserName");
            this.tbx_UserName.Name = "tbx_UserName";
            // 
            // lbl_UserName
            // 
            resources.ApplyResources(this.lbl_UserName, "lbl_UserName");
            this.lbl_UserName.Name = "lbl_UserName";
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
            // UserForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbx_UserID);
            this.Controls.Add(this.lbl_UserID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.ShowInTaskbar = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_UserID;
        private System.Windows.Forms.TextBox tbx_UserID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_FullName;
        private System.Windows.Forms.Label lbl_FullName;
        private System.Windows.Forms.TextBox tbx_UserName;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox tbx_Email;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}