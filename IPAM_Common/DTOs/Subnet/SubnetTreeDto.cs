using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Common.DTOs.Subnet
{
    public class SubnetTreeDto
    {
        public string Label { get; set; }
        public string Data { get; set; }
        public string Path { get; set; }
        public string ExpandedIcon { get; set; }
        public string CollapsedIcon { get; set; }
        public bool Expanded { get; set; }
        public List<SubnetTreeDto> Children { get; set; }
    }
}
