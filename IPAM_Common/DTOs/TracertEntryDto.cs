using System.Net.NetworkInformation;

namespace IPAM_Common.DTOs
{
    public class TracertEntryDto
    {
        public int Hop { get; set; }
        public string Address { get; set; }
        public string Hostname { get; set; }
        public long ResponseTime { get; set; }
        public IPStatus Status { get; set; }        
    }

    public class TracertResponseDto
    {
        public int Hop { get; set; }
        public string Address { get; set; }
        public string Hostname { get; set; }
        public long ResponseTime { get; set; }
        public string Status { get; set; }
    }
}
