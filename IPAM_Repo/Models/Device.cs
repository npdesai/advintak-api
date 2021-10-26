using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Models
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid DeviceId { get; set; }
        public string DeviceType { get; set; }
        public string DeviceIPAddress { get; set; }
        public DateTime? LastScanTime { get; set; }
        public string? Status { get; set; }
    }
}
