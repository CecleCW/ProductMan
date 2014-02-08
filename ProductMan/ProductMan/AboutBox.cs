using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Text;

namespace ProductMan
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            richTextBox1.Text += typeof(AboutBox).Assembly.GetName().Version.ToString() + "\r\n\r\n" + AssemblyDescription;
        }

        public string AssemblyDescription
        {
            get
            {
                AssemblyName[] other = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
                StringBuilder sb = new StringBuilder();
                foreach (AssemblyName a in other)
                {
                    sb.Append(string.Format("{0} ({1})\r\n", a.Name, a.Version));
                }
                return sb.ToString();
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
