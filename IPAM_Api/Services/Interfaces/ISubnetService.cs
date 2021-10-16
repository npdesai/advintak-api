using IPAM_Common.DTOs.Subnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api.Services.Interfaces
{
    public interface ISubnetService
    {
        Task<Guid> AddSubnet(SubnetDto subnetDto);
        //Task<IEnumerable<SubnetTreeDto>> GetSubnetTree();
        //Task<IEnumerable<SubnetIpDetail>> GetSubnetIPs(string subnet);
    }
}
