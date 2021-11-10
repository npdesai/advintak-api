using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Interfaces
{
    public interface ISubnetRepository
    {
        Task<Guid> Create(Subnet subnet);
        Task<List<Subnet>> GetSubnetsByGroupId(Guid subnetGroupId);
        Task<bool> UpdateSubnetDetail(Subnet subnet);
        Task<Subnet> GetSubnetsById(Guid subnetId);
        Task<bool> Delete(Subnet subnet);
    }
}
