using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Interfaces
{
    public interface ISubnetIpRepository
    {
        Task<Guid> Create(SubnetIP subnetIP);
        Task<List<SubnetIP>> GetIpListBySubnetId(Guid subnetId);
        Task<bool> UpdateSubnetIpDetail(SubnetIP subnetIP);
        Task<SubnetIP> GetSubnetIpDetailById(Guid Id);
        Task<bool> DeleteBySubnetId(List<SubnetIP> subnetIPs);
    }
}
