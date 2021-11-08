using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Interfaces
{
    public interface ISubnetIPHistoryRepository
    {
        Task<List<SubnetIPHistory>> GetIpHistoryBySubnetId(Guid subnetId);
        Task<Guid> Create(SubnetIPHistory subnetIPHistory);
        Task<List<SubnetIPHistory>> GetIpHistoryBySubnetGroupId(Guid subnetGroupId);
    }
}
