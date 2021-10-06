using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Models.Subnet
{
    public class SubnetMask
    {
        [Key]
        public int MaskId { get; set; }
        public string MaskName { get; set; }
        public string MaskDescription { get; set; }
    }
}
