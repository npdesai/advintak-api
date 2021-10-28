using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Common.DTOs.Setting
{
    public class DomainDto
    {
        public Guid DomainId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DomainName { get; set; }
        public string DomainControllerName { get; set; }
    }
}
