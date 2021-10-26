using IPAM_Common.DTOs.Subnet;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Api.Services.Interfaces
{
    public interface IIPV6SubnetService
    {
        Task<Guid> AddIPV6Subnet(IPV6SubnetDto iPV6Subnet);
        Task<List<IPV6SubnetDto>> GetIPV6SubnetList();
    }
}
