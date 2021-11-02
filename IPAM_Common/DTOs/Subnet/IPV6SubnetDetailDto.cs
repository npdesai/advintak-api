using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Common.DTOs.Subnet
{
    public class IPV6SubnetDetailDto
    {
        public Guid IPV6SubnetDetailId { get; set; }
        public Guid IPV6SubnetId { get; set; }
        public string IPV6Address { get; set; }
        public string Status { get; set; }
        public string MacAddress { get; set; }
        public string IpToDns { get; set; }
        public string DnsToIp { get; set; }
        public string DnsStatus { get; set; }
        public string VendorName { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
