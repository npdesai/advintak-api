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
        public string VlanName { get; set; }
        public string Location { get; set; }
    }
}
