using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;

namespace ProductMan.Utilities
{
    public class Formatter
    {
        public static string GetStringValueFrom(DataRow row, string field)
        {
            if (row == null) return "";
            if (field == null || field.Trim() == "") return "";
            try
            {
                return (string)row[field.Trim()];
            }
            catch { }
            return "";
        }

        public static int GetIntValueFrom(DataRow row, string field)
        {
            if (row == null) return 0;
            if (field == null || field.Trim() == "") return 0;
            try
            {
                return (int)row[field.Trim()];
            }
            catch { }
            return 0;
        }

        public static bool GetBoolValueFrom(DataRow row, string field)
        {
            if (row == null) return false;
            if (field == null || field.Trim() == "") return false;
            try
            {
                return (bool)row[field.Trim()];
            }
            catch { }
            return false;
        }

        public static DateTime GetDateTimeValueFrom(DataRow row, string field)
        {
            if (row == null) return DateTime.Now;
            if (field == null || field.Trim() == "") return DateTime.Now;
            try
            {
                return (DateTime)row[field.Trim()];
            }
            catch { }
            return DateTime.Now;
        }

        public static Bitmap GetImageFrom(DataRow row, string field)
        {
            if (row == null) return null;
            if (field == null || field.Trim() == "") return null;
            try
            {
                byte[] imgBytes = (byte[])row[field.Trim()];
                MemoryStream ms = new MemoryStream(imgBytes);
                return new Bitmap(ms);
            }
            catch { }
            return null;
        }
    }
}
