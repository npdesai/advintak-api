using IPAM_Common.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace IPAM_Common
{
    public class IPHelper
    {
        public static async Task<PingReply> Ping(string ip)
        {
            Ping ping = new Ping();
            var res = await ping.SendPingAsync(ip);
            ping.Dispose();
            return res;                        
        }

        public static IEnumerable<TracertEntryDto> TraceRoute(string ipAddress, int maxHops, int timeout)
        {
            // Ensure that the argument address is valid.
            if (!IPAddress.TryParse(ipAddress, out IPAddress address))
                throw new ArgumentException(string.Format("{0} is not a valid IP address.", ipAddress));

            // Max hops should be at least one or else there won't be any data to return.
            if (maxHops < 1)
                throw new ArgumentException("Max hops can't be lower than 1.");

            // Ensure that the timeout is not set to 0 or a negative number.
            if (timeout < 1) throw new ArgumentException("Timeout value must be higher than 0."); 
            Ping ping = new Ping(); 
            PingOptions pingOptions = new PingOptions(1, true); 
            Stopwatch pingReplyTime = new Stopwatch(); 
            PingReply reply; 
            do
            {
                pingReplyTime.Start(); 
                reply = ping.Send(address, timeout, new byte[] { 0 }, pingOptions); 
                pingReplyTime.Stop(); string hostname = string.Empty; 
                if (reply.Address != null)
                {
                    try
                    {
                        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); 
                        hostname = ipHostInfo.HostName;
                                                                                                                                      
                    }
                    catch (SocketException) { /* No host available for that address. */ }
                }

                // Return out TracertEntry object with all the information about the hop.
                yield return new TracertEntryDto()
                {
                    Hop = pingOptions.Ttl,
                    Address = reply.Address == null ? "N/A" : reply.Address.ToString(),
                    Hostname = hostname,
                    ResponseTime = pingReplyTime.ElapsedMilliseconds,
                    Status = reply.Status
                };

                pingOptions.Ttl++;
                pingReplyTime.Reset();
            }
            while (pingOptions.Ttl <= maxHops);
        }
    }
}
