using System.Net.NetworkInformation;

namespace IPAM_Common
{
    public class IPHelper
    {
        public static bool Ping(string ip)
        {
            Ping ping = new Ping();
            PingReply pingresult = ping.Send(ip);
            if (pingresult.Status.ToString() == "Success")
            {
                return true;
            }

            return false;
        }
    }
}
