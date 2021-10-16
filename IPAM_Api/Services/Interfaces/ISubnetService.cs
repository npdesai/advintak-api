using IPAM_Common.DTOs;
using IPAM_Common.DTOs.Subnet;
using System;
using System.Threading.Tasks;

namespace IPAM_Api.Services.Interfaces
{
    public interface ISubnetService
    {
        Task<Guid> AddSubnet(SubnetDto subnetDto);
        Task<TracertResponseDto> TraceRoute(string ipAddress);
        Task<PingReplyDto> Ping(string ipAddress);
        //Task<IEnumerable<SubnetTreeDto>> GetSubnetTree();
        //Task<IEnumerable<SubnetIpDetail>> GetSubnetIPs(string subnet);
    }
}
