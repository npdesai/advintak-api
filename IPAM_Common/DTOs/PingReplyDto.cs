using System.Net.NetworkInformation;

namespace IPAM_Common.DTOs
{
    public class PingReplyDto
    {
        public string Address { get; set; }          
        public PingOptions? Options { get; set; }   
        public long RoundtripTime { get; set; }    
        public string Status { get; set; }
    }
}
