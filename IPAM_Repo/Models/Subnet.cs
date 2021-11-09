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
        public Guid SubnetMaskId { get; set; }
        public virtual SubnetMask SubnetMask { get; set; }
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
    }
}
