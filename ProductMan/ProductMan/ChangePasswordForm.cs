using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductMan.Helpers;
using ProductMan.Utilities;

namespace ProductMan
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string oldPassword = tbx_OldPassword.Text;
            string newPassword = tbx_NewPassword.Text;
            string confirmPassword = tbx_ConfirmPassword.Text;

            oldPassword = DataProtection.Encrypt(oldPassword, DataService.Instance.CurrentUser.UserID);

            if (oldPassword == DataService.Instance.CurrentUser.Password)
            {
                if (newPassword == null || newPassword.Trim() == "")
                {
                    MessageBox.Show(ResourceHelper.Instance.GetString("ChangePassword.WrongNewPwd"), Text);
                    return;
                }
                if (newPassword == confirmPassword)
                {
                    if (DataService.Instance.ChangePassword(newPassword))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(ResourceHelper.Instance.GetString("ChangePassword.ChangeFailed"), Text);
                    }
                }
                else
                {
                    MessageBox.Show(ResourceHelper.Instance.GetString("ChangePassword.WrongConfirmPwd"), Text);
                }
            }
            else
            {
                MessageBox.Show(ResourceHelper.Instance.GetString("ChangePassword.WrongOldPwd"), Text);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
