using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Common.DTOs.Setting
{
    public class DeviceDto
    {
        public Guid DeviceId { get; set; }
        public string DeviceType { get; set; }
        public string DeviceIPAddress { get; set; }
        public DateTime? LastScanTime { get; set; }
        public string? Status { get; set; }
    }
}
