using GIS_api.Models.DTO.Subnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Services.Interfaces
{
    public interface ISubnetService
    {
        Task<int> AddSubnet(SubnetsDTO obj);
        Task<IEnumerable<SubnetTreeDto>> GetSubnetTree();
        Task<IEnumerable<SubnetIpDetail>> GetSubnetDetail(string subnet);
    }
}
