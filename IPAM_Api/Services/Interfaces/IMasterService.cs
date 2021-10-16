using IPAM_Common.DTOs.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api.Services.Interfaces
{
    public interface IMasterService
    {
        Task<List<SubnetGroupDto>> GetSubnetGroups();
        Task<List<SubnetMaskDto>> GetSubnetMasks();
    }
}
