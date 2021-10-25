using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAM_Repo.Models
{
    public class IPV6Subnet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid IPV6SubnetId { get; set; }
        public string PrefixName { get; set; }
        public string PrefixAddress { get; set; }
        public int PrefixLength { get; set; }
        public string PrefixDescription { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
