using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductMan.Helpers;
using System.Text.RegularExpressions;

namespace ProductMan
{
    public partial class LoginForm : Form
    {
        public event EventHandler<LoginEventArgs> OnLogin;

        public LoginForm()
        {
            InitializeComponent();
        }

        public void HandleLoginFailed()
        {
            UpdateStatusBar(ResourceHelper.Instance.GetString("LoginForm.LoginFailed"));
            MessageBox.Show(ResourceHelper.Instance.GetString("LoginForm.LoginFailed"), Text);
            ToggleUI(true);
            tbx_UserID.Focus();
            tbx_UserID.SelectAll();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            ToggleUI(false);
            UpdateStatusBar(ResourceHelper.Instance.GetString("LoginForm.StartLogin"));
            string id = tbx_UserID.Text.Trim();
            string password = tbx_Password.Text.Trim();
            if (!IsValid(id, password))
            {
                MessageBox.Show(ResourceHelper.Instance.GetString("LoginForm.InvalidIDPassword"), Text);
                UpdateStatusBar(ResourceHelper.Instance.GetString("LoginForm.InvalidIDPassword"));
                ToggleUI(true);
                return;
            }

            if (OnLogin != null) OnLogin(this, new LoginEventArgs(id, password));
        }

        private bool IsValid(string id, string password)
        {
            if (id == null || id.Trim() == "") return false;
            if (password == null || password.Trim() == "") return false;
            return true;
        }

        private void UpdateStatusBar(string msg)
        {
            if (InvokeRequired)
            {
                MethodInvoker mi = delegate
                {
                    status_State.Text = msg;
                };
                Invoke(mi);
            }
            else
            {
                status_State.Text = msg;
            }
        }

        private void ToggleUI(bool enabled)
        {
            tbx_Password.Enabled = enabled;
            tbx_UserID.Enabled = enabled;
            btn_Login.Enabled = enabled;
        }

        private void tbx_UserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tbx_Password.Focus();
                tbx_Password.SelectAll();
            }
        }

        private void tbx_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Login_Click(this, EventArgs.Empty);
            }
        }
    }

    public class LoginBaseEventArgs : EventArgs
    {
        protected string id;
        protected string password;

        public LoginBaseEventArgs(string id, string pwd)
        {
            this.id = id;
            this.password = pwd;
        }

        public string ID
        {
            get { return id; }
        }

        public string Password
        {
            get { return password; }
        }
    }

    public class LoginEventArgs : LoginBaseEventArgs
    {
        public LoginEventArgs(string id, string pwd)
            : base(id, pwd)
        { }
    }
}
