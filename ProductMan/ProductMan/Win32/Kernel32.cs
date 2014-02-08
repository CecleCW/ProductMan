using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ProductMan.Utilities.Win32
{
    public class Kernel32
    {
        [DllImport("kernel32")]
        public static extern IntPtr LocalFree(IntPtr hMem);
    }
}
