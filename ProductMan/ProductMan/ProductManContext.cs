using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ProductMan.Helpers;

namespace ProductMan
{
    public class ProductManContext : ApplicationContext
    {
        protected LoginForm login;

        public ProductManContext()
        {
            SplashScreen.Instance.Status = ResourceHelper.Instance.GetString("SplashScreen.InitialLogin");
            login = new LoginForm();
            MainForm = login;
            login.OnLogin += new EventHandler<LoginEventArgs>(login_OnLogin);
            SplashScreen.Instance.Hide();
            login.Show();
        }

        private void login_OnLogin(object sender, LoginEventArgs e)
        {
            UserInfo ui = DataService.Instance.Authenticate(e.ID, e.Password);
            if (ui != null)
            {
                login.Hide();
                SplashScreen.Instance.Visible = true;
                MainForm main = new MainForm();
                main.InitData();
                MainForm = main;
                login.Dispose();
                SplashScreen.Instance.Dispose();
                MainForm.Show();
            }
            else
            {
                login.HandleLoginFailed();
            }
        }
    }
}
