using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMan.Win32
{
    public class NetworkAdapterConfiguration
    {
        public string ArpAlwaysSourceRoute;
        public string ArpUseEtherSNAP;
        public string Caption;
        public string DatabasePath;
        public string DeadGWDetectEnabled;
        public string[] DefaultIPGateway;
        public string DefaultTOS;
        public string DefaultTTL;
        public string Description;
        public bool DHCPEnabled;
        public string DHCPLeaseExpires;
        public string DHCPLeaseObtained;
        public string DHCPServer;
        public string DSNDomain;
        public string DNSDomainSuffixSearchOrder;
        public bool DNSEnabledForWINSResolution;
        public string DNSHostName;
        public string[] DNSServerSearchOrder;
        public bool DomainDNSRegistrationEnabled;
        public string ForwardBufferMemory;
        public bool FullDNSRegistrationEanbled;
        public UInt32[] GatewayCostMetric;
        public string IGMPLevel;
        public UInt32 Index;
        public string[] IPAddress;
        public UInt32 IPConnectionMetric;
        public bool IPEnabled;
        public bool IPFilterSecurityEnabled;
        public bool IPPortSecurityEnabled;
        public string[] IPSecPermitIPProtocols;
        public string[] IPSecPermitTCPPorts;
        public string[] IPSecPermitUDPPorts;
        public string[] IPSubnet;
        public string IPUseZeroBroadcast;
        public string IPXAddress;
        public bool IPXEnabled;
        public string IPXFrameType;
        public string IPXMediaType;
        public string IPXNetworkNumber;
        public string IPXVirtualNetNumber;
        public string KeepAliveInterval;
        public string KeepAliveTime;
        public string MACAddress;
        public string MTU;
        public string NumForwardPackets;
        public bool PMTUBHDetectEnabled;
        public bool PMTUDiscoveryEnabled;
        public string ServiceName;
        public string SettingID;
        public string TcpipNetbiosOptions;
        public string TCP;
    }
}
