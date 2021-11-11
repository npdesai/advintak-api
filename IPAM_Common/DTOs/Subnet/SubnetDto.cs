using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Common.DTOs.Subnet
{
    public class SubnetDto
    {
        public Guid SubnetId { get; set; }
        public Guid? SubnetGroupId { get; set; }
        public string SubnetGroupName { get; set; }
        public string SubnetAddress { get; set; }
        public Guid SubnetMaskId { get; set; }
        public string SubnetName { get; set; }
        public string SubnetDescription { get; set; }
        public string VlanId { get; set; }
        public string VlanName { get; set; }
        public string Location { get; set; }
        public int Alert { get; set; }
        public int Warning { get; set; }
        public int Critical { get; set; }
        public string Email { get; set; }
        public string AccessMode { get; set; }
        public List<SubnetIPDetailDto> SubnetIpList { get; set; }
    }

    public class SubnetDetailDto
    {
        public Guid SubnetId { get; set; }
        public Guid? SubnetGroupId { get; set; }
        public string SubnetGroupName { get; set; }
        public string SubnetAddress { get; set; }
        public Guid SubnetMaskId { get; set; }
        public string SubnetMask { get; set; }
        public string SubnetName { get; set; }
        public int SubnetSize { get; set; }
        public int SubnetUsage { get; set; }
        public string ScanStatus { get; set; }
        public int Available { get; set; }
        public int NotReachable { get; set; }
        public int Used { get; set; }
        public int Quarantine { get; set; }
        public DateTime LastScanTime { get; set; }
        public string VlanName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }        
    }
}
