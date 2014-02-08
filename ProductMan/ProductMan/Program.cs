using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProductMan.Helpers;
using ProductMan.MultiLang;
using System.Globalization;
using ProductMan.Utilities;

namespace ProductMan
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if !DEBUG
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.ThreadExit += new EventHandler(Application_ThreadExit);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLanguageSwitchSingleton.Instance.ChangeCurrentThreadUICulture(new CultureInfo("zh-CHS"));
            SplashScreen.Instance.Status = ResourceHelper.Instance.GetString("SplashScreen.Startup");
            SplashScreen.Instance.Show();
            Application.Run(new ProductManContext());
        }

        static void Application_ThreadExit(object sender, EventArgs e)
        {
            Application.ThreadException -= new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.ThreadExit -= new EventHandler(Application_ThreadExit);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LoggerBase.Instance.Error("Unhandled Exception: " + e.ExceptionObject.ToString());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LoggerBase.Instance.Error("Thread Exception: " + e.Exception.ToString());
        }
    }
}
