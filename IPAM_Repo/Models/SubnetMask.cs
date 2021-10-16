using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAM_Repo.Models
{
    public class SubnetMask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid MaskId { get; set; }
        public string Class { get; set; }
        public int Addresses { get; set; }
        public string CIDR { get; set; }
        public int Hosts { get; set; }
        public string NetMask { get; set; }
    }
}
