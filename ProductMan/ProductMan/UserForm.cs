using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductMan.Helpers;

namespace ProductMan
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            PaintUserInfo();
        }

        private void PaintUserInfo()
        {
            tbx_Email.Text = DataService.Instance.CurrentUser.Email;
            tbx_FullName.Text = DataService.Instance.CurrentUser.FullName;
            tbx_UserID.Text = DataService.Instance.CurrentUser.UserID;
            tbx_UserName.Text = DataService.Instance.CurrentUser.UserName;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string userName = tbx_UserName.Text.Trim();
            if (userName == "")
            {
                MessageBox.Show(ResourceHelper.Instance.GetString("UserForm.InvalidUserName"), Text);
                return;
            }
            string fullName = tbx_FullName.Text.Trim();
            if (fullName == "")
            {
                MessageBox.Show(ResourceHelper.Instance.GetString("UserForm.InvalidFullName"), Text);
                return;
            }
            UserInfo ui = new UserInfo();
            ui.Email = tbx_Email.Text.Trim();
            ui.FullName = fullName;
            ui.UserName = userName;
            if (DataService.Instance.UpdateUserInfo(ui))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(ResourceHelper.Instance.GetString("UserForm.UpdateUser.Failed"), Text);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
