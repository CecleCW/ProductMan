using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMan.Win32
{
    public class CIM_UnitaryComputerSystem : CIM_System
    {
        public string InitialLoadInfo;
        public string LastLoadInfo;
        public UInt16 PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public UInt16 PowerState;
        public UInt16 ResetCapability;
    }
}