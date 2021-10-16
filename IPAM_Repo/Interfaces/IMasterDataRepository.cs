using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Interfaces
{
    public interface IMasterDataRepository
    {
        Task<List<SubnetGroup>> GetSubnetGroups();
        Task<List<SubnetMask>> GetSubnetMasks();
    }
}
