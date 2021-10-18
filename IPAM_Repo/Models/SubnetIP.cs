using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Models
{
    public class SubnetIP
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid SubnetIPId { get; set; }
        public Guid SubnetId { get; set; }
        public virtual Subnet Subnet { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public string DnsStatus { get; set; }
        public string Status { get; set; }
        public string DeviceType { get; set; }
        public string ConnectedSwitch { get; set; }
        public DateTime LastScan { get; set; }
    }
}
