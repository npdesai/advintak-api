using System;

namespace IPAM_Common.DTOs.Master
{
    public class SubnetMaskDto
    {
        public Guid MaskId { get; set; }
        public string Class { get; set; }
        public int Addresses { get; set; }
        public string CIDR { get; set; }
        public int Hosts { get; set; }
        public string NetMask { get; set; }
        public string DisplaySubnetMask { get; set; }
    }
}
