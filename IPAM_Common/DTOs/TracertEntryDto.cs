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
        public string IPAddress { get; set; }
        public string DNSName { get; set; }
        public long ResponseTime1 { get; set; }
        public long ResponseTime2 { get; set; }
        public long ResponseTime3 { get; set; }
        public bool Status { get; set; }
    }
}
