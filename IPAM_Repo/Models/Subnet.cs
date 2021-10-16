using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAM_Repo.Models
{
    public class Subnet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid SubnetId { get; set; }
        public Guid SubnetGroupId { get; set; }
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
