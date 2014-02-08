using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ProductMan.Utilities.Win32
{
    public class User32
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto, PreserveSig = false)]
        public static extern IRichEditOle SendMessage(IntPtr hWnd, int message, int wParam);
    }
}
