using System;

namespace IPAM_Common.DTOs.Subnet
{
    public class SubnetIPDetailDto
    {
        public Guid SubnetIPId { get; set; }
        public Guid SubnetId { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public string DnsStatus { get; set; }
        public string Status { get; set; }
        public string DeviceType { get; set; }
        public string ConnectedSwitch { get; set; }
        public string ReservedStatus { get; set; }
        public string AliasName { get; set; }
        public string AssetTag { get; set; }
        public string SystemLocation { get; set; }
        public DateTime LastScan { get; set; }        
    }
}
