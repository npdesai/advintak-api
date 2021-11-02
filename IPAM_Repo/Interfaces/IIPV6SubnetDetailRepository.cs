using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Interfaces
{
    public interface IIPV6SubnetDetailRepository
    {
        Task<Guid> Create(IPV6SubnetDetail iPV6SubnetDetail);
        Task<List<IPV6SubnetDetail>> GetList(Guid iPV6SubnetId);
        Task<IPV6SubnetDetail> Get(Guid iPV6SubnetDetailId);
        Task<bool> UpdateIPV6Detail(IPV6SubnetDetail iPV6SubnetDetail);
    }
}
