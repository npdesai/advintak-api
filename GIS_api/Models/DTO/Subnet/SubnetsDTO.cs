using GIS_api.Models.Subnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Models.DTO.Subnet
{
    public class SubnetsDTO
    {
        public int SubnetId { get; set; }
        public int SubnetGroupId { get; set; }
        public string SubnetGroupName { get; set; }
        public string SubnetAddress { get; set; }
        public int SubnetMaskId { get; set; }
        public string SubnetName { get; set; }
        public string SubnetDescription { get; set; }
        public string VlanName { get; set; }
        public string Location { get; set; }
    }
}
