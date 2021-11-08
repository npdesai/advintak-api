using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Models
{
    public class SubnetIPHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid SubnetIPHistoryId { get; set; }
        public Guid SubnetIPId { get; set; }
        public Guid SubnetId { get; set; }        
        public string IPAddress { get; set; }
        public DateTime DetectedTime { get; set; }
        public string DNSName { get; set; }
        public string MacAddress { get; set; }        
        public string DeviceType { get; set; }
        public string SysDescription { get; set; }
    }
}
