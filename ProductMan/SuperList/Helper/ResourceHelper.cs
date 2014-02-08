using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;

namespace BinaryComponents.SuperList.Helper
{
    public class ResourceHelper
    {
        protected ResourceManager resxMan;
        protected static ResourceHelper m_instance = new ResourceHelper();

        private ResourceHelper()
        {
            resxMan = new ResourceManager("BinaryComponents.SuperList.Resources.Strings", typeof(ListControl).Assembly);
        }

        public static ResourceHelper Instance
        {
            get { return m_instance; }
        }

        public string GetString(string name)
        {
            return resxMan.GetString(name);
        }

        public string GetString(string name, System.Globalization.CultureInfo culture)
        {
            return resxMan.GetString(name, culture);
        }
    }
}
