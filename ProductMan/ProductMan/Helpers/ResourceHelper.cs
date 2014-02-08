using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Reflection;

namespace ProductMan.Helpers
{
    public class ResourceHelper
    {
        protected ResourceManager resxMan;
        protected static ResourceHelper instance = new ResourceHelper();

        private ResourceHelper()
        {
            resxMan = new ResourceManager("ProductMan.Resources.Strings", Assembly.GetExecutingAssembly());
        }

        public static ResourceHelper Instance
        {
            get { return instance; }
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
