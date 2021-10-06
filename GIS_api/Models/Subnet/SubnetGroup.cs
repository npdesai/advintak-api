using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Models.Subnet
{
    public class SubnetGroup
    {
        [Key]
        public int GroupId { get; set; }        
        public string GroupName { get; set; }
        public string GroupAddress { get; set; }
    }
}
