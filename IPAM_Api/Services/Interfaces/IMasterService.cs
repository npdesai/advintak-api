using IPAM_Common.DTOs.Master;
using IPAM_Common.DTOs.Subnet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Api.Services.Interfaces
{
    public interface IMasterService
    {
        Task<List<SubnetGroupDto>> GetSubnetGroups();
        Task<List<SubnetMaskDto>> GetSubnetMasks();
        Task<List<ServerTypeDto>> GetServerTypes();
    }
}
