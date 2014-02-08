using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMan.Win32
{
    public class ComputerSystem : CIM_UnitaryComputerSystem
    {
        public UInt16 AdminPasswordStatus;
        public bool AutomaticManagedPagefile;
        public bool AutomaticResetBootOption;
        public bool AutomaticResetCapability;
        public UInt16 BootOptionOnLimit;
        public UInt16 BootOptionOnWatchDog;
        public bool BootROMSupported;
        public string BootupState;
        public UInt16 ChassisBootupState;
        public Int16 CurrentTimeZone;
        public bool DaylightInEffect;
        public string DNSHostName;
        public string Domain;
        public UInt16 DomainRole;
        public bool EnableDaylightSavingsTime;
        public UInt16 FrontPanelResetStatus;
        public bool InfraredSupported;
        public UInt16 KeyboardPasswordStatus;
        public string Manufacturer;
        public string Model;
        public bool NetworkServerModeEnabled;
        public UInt32 NumberOfLogicalProcessors;
        public UInt32 NumberOfProcessors;
        public uint OEMLogoBitmap;
        public string[] OEMStringArray;
        public bool PartOfDomain;
        public Int64 PauseAfterReset;
        public UInt16 PCSystemType;
        public UInt16 PowerOnPasswordStatus;
        public UInt16 PowerSupplyState;
        public Int16 ResetCount;
        public Int16 ResetLimit;
        public string SupportContactDescription;
        public UInt16 SystemStartupDelay;
        public string SystemStartupOptions;
        public uint SystemStartupSetting;
        public string SystemType;
        public UInt16 ThermalState;
        public UInt64 TotalPhysicalMemory;
        public string UserName;
        public UInt16 WakeUpType;
        public string Workgroup;
    }
}
