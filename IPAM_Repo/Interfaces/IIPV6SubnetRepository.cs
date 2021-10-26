using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Repo.Interfaces
{
    public interface IIPV6SubnetRepository
    {
        Task<Guid> Create(IPV6Subnet iPV6Subnet);
        Task<List<IPV6Subnet>> GetList();
    }
}
