using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Models.DTO.Subnet
{
    public class SubnetIpDetail
    {
        public string ipAddress { get; set; }
        public string macAddress { get; set; }
        public string ipDNS { get; set; }
        public string dnsIp { get; set; }
        public string dnsStatus { get; set; }
        public string status { get; set; }
        public string deviceType { get; set; }
        public string connectedSwitch { get; set; }
        public int connectedPort { get; set; }
        public string dnsName { get; set; }
        public string leaseExpiryDate { get; set; }        
    }
}
