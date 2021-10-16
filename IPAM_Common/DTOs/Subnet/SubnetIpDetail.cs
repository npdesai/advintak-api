using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Common.DTOs.Subnet
{
    public class SubnetIpDetail
    {
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public string DnsStatus { get; set; }
        public string Status { get; set; }
        public string DeviceType { get; set; }
        public string ConnectedSwitch { get; set; }
        public DateTime LastScan { get; set; }        
    }
}
