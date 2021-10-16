using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Repo.Models
{
    public class SubnetGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid GroupId { get; set; }        
        public string GroupName { get; set; }
        public string GroupAddress { get; set; }
    }
}
