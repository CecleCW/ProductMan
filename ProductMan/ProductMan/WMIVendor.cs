using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using ProductMan.Utilities;
using ProductMan.Win32;
using System.Reflection;

namespace ProductMan
{
    public class WMIVendor : IDisposable
    {
        protected static WMIVendor instance;
        protected ManagementScope scope;
        protected ConnectionOptions conn;
        protected ComputerSystem computer;
        protected NetworkAdapterConfiguration networkAdapterConfig;
        protected ProductMan.Win32.OperatingSystem os;
        protected static volatile object syncRoot = new object();

        private WMIVendor()
        {
            conn = new ConnectionOptions();
            scope = new ManagementScope("\\\\localhost", conn);
            scope.Options.Impersonation = ImpersonationLevel.Impersonate;
        }

        public ComputerSystem GetComputerSystem()
        {
            if (computer != null) return computer;
            computer = new ComputerSystem();
            try
            {
                ManagementObjectCollection res = Query("select * from win32_ComputerSystem");
                FieldInfo[] fields = typeof(ComputerSystem).GetFields();
                foreach (ManagementObject item in res)
                {
                    foreach (FieldInfo info in fields)
                    {
                        try
                        {
                            info.SetValue(computer, item[info.Name]);
                        }
                        catch { }
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return computer;
        }

        public NetworkAdapterConfiguration GetNetworkConfig()
        {
            if (networkAdapterConfig != null) return networkAdapterConfig;
            networkAdapterConfig = new NetworkAdapterConfiguration();
            try
            {
                ManagementObjectCollection res = Query("select * from win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
                FieldInfo[] fields = typeof(NetworkAdapterConfiguration).GetFields();
                foreach (ManagementObject item in res)
                {
                    foreach (FieldInfo info in fields)
                    {
                        try
                        {
                            info.SetValue(networkAdapterConfig, item[info.Name]);
                        }
                        catch { }
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }

            return networkAdapterConfig;
        }

        public ProductMan.Win32.OperatingSystem GetOS()
        {
            if (os != null) return os;
            os = new ProductMan.Win32.OperatingSystem();
            try
            {
                ManagementObjectCollection res = Query("select * from win32_OperatingSystem");
                FieldInfo[] fields = typeof(ProductMan.Win32.OperatingSystem).GetFields();
                foreach (ManagementObject item in res)
                {
                    foreach (FieldInfo info in fields)
                    {
                        try
                        {
                            info.SetValue(os, item[info.Name]);
                        }
                        catch { }
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return os;
        }

        private ManagementObjectCollection Query(string queryString)
        {
            try
            {
                ObjectQuery query = new ObjectQuery(queryString);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                return searcher.Get();
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return null;
        }

        public static WMIVendor Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null) instance = new WMIVendor();
                    }
                }
                return instance;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            //TODO
        }

        #endregion
    }
}
