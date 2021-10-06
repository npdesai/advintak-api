using GIS_api.Models.DTO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Services.Interfaces
{
    public interface IMasterService
    {
        Task<IEnumerable<SubnetGroupDto>> GetSubnetGroups();
        Task<IEnumerable<SubnetMaskDto>> GetSubnetMask();
    }
}
