using System;

namespace IPAM_Common.DTOs.Subnet
{
    public class IPV6SubnetDto
    {
        public Guid IPV6SubnetId { get; set; }
        public string PrefixName { get; set; }
        public string PrefixAddress { get; set; }
        public int PrefixLength { get; set; }
        public string PrefixDescription { get; set; }
        public Guid? CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
