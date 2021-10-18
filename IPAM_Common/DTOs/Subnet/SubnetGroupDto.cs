using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Common.DTOs.Subnet
{
    public class SubnetGroupDto
    {
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupAddress { get; set; }
    }
}
