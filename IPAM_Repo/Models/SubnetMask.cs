using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Repo.Models
{
    public class SubnetMask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid MaskId { get; set; }
        public string MaskName { get; set; }
        public string MaskDescription { get; set; }
    }
}
