namespace ProductMan
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.lbl_OldPassword = new System.Windows.Forms.Label();
            this.lbl_NewPassword = new System.Windows.Forms.Label();
            this.lbl_ConfirmPassword = new System.Windows.Forms.Label();
            this.tbx_OldPassword = new System.Windows.Forms.TextBox();
            this.tbx_NewPassword = new System.Windows.Forms.TextBox();
            this.tbx_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_OldPassword
            // 
            this.lbl_OldPassword.AccessibleDescription = null;
            this.lbl_OldPassword.AccessibleName = null;
            resources.ApplyResources(this.lbl_OldPassword, "lbl_OldPassword");
            this.lbl_OldPassword.Font = null;
            this.lbl_OldPassword.Name = "lbl_OldPassword";
            // 
            // lbl_NewPassword
            // 
            this.lbl_NewPassword.AccessibleDescription = null;
            this.lbl_NewPassword.AccessibleName = null;
            resources.ApplyResources(this.lbl_NewPassword, "lbl_NewPassword");
            this.lbl_NewPassword.Font = null;
            this.lbl_NewPassword.Name = "lbl_NewPassword";
            // 
            // lbl_ConfirmPassword
            // 
            this.lbl_ConfirmPassword.AccessibleDescription = null;
            this.lbl_ConfirmPassword.AccessibleName = null;
            resources.ApplyResources(this.lbl_ConfirmPassword, "lbl_ConfirmPassword");
            this.lbl_ConfirmPassword.Font = null;
            this.lbl_ConfirmPassword.Name = "lbl_ConfirmPassword";
            // 
            // tbx_OldPassword
            // 
            this.tbx_OldPassword.AccessibleDescription = null;
            this.tbx_OldPassword.AccessibleName = null;
            resources.ApplyResources(this.tbx_OldPassword, "tbx_OldPassword");
            this.tbx_OldPassword.BackgroundImage = null;
            this.tbx_OldPassword.Font = null;
            this.tbx_OldPassword.Name = "tbx_OldPassword";
            // 
            // tbx_NewPassword
            // 
            this.tbx_NewPassword.AccessibleDescription = null;
            this.tbx_NewPassword.AccessibleName = null;
            resources.ApplyResources(this.tbx_NewPassword, "tbx_NewPassword");
            this.tbx_NewPassword.BackgroundImage = null;
            this.tbx_NewPassword.Font = null;
            this.tbx_NewPassword.Name = "tbx_NewPassword";
            // 
            // tbx_ConfirmPassword
            // 
            this.tbx_ConfirmPassword.AccessibleDescription = null;
            this.tbx_ConfirmPassword.AccessibleName = null;
            resources.ApplyResources(this.tbx_ConfirmPassword, "tbx_ConfirmPassword");
            this.tbx_ConfirmPassword.BackgroundImage = null;
            this.tbx_ConfirmPassword.Font = null;
            this.tbx_ConfirmPassword.Name = "tbx_ConfirmPassword";
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = null;
            this.btn_OK.AccessibleName = null;
            resources.ApplyResources(this.btn_OK, "btn_OK");
            this.btn_OK.BackgroundImage = null;
            this.btn_OK.Font = null;
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = null;
            this.btn_Cancel.AccessibleName = null;
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.BackgroundImage = null;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Font = null;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // ChangePasswordForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.tbx_ConfirmPassword);
            this.Controls.Add(this.tbx_NewPassword);
            this.Controls.Add(this.tbx_OldPassword);
            this.Controls.Add(this.lbl_ConfirmPassword);
            this.Controls.Add(this.lbl_NewPassword);
            this.Controls.Add(this.lbl_OldPassword);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_OldPassword;
        private System.Windows.Forms.Label lbl_NewPassword;
        private System.Windows.Forms.Label lbl_ConfirmPassword;
        private System.Windows.Forms.TextBox tbx_OldPassword;
        private System.Windows.Forms.TextBox tbx_NewPassword;
        private System.Windows.Forms.TextBox tbx_ConfirmPassword;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}