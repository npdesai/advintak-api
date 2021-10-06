using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Models.DTO.Subnet
{
    public class SubnetTreeDto
    {
        public string label { get; set; }
        public string data { get; set; }
        public string path { get; set; }
        public string expandedIcon { get; set; }
        public string collapsedIcon { get; set; }
        public bool expanded { get; set; }
        public IEnumerable<SubnetTreeDto> children { get; set; }
    }
}
