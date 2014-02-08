using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMan.Win32
{
    public class CIM_System : CIM_ManagedSystemElement
    {
        public string CreationClassName;
        public string NameFormat;
        public string PrimaryOwnerContact;
        public string PrimaryOwnerName;
        public string[] Roles;
    }
}
