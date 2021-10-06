using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Models.Subnet
{
    public class Subnets
    {
        [Key]
        public int SubnetId { get; set; }
        public int SubnetGroupId { get; set; }
        public virtual SubnetGroup SubnetGroup { get; set; }
        public string SubnetAddress { get; set; }
        public int SubnetMaskId { get; set; }
        public virtual SubnetMask SubnetMask { get; set; }
        public string SubnetName { get; set; }
        public string SubnetDescription { get; set; }
        public string VlanName { get; set; }
        public string Location { get; set; }           
    }
}
