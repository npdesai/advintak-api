using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Interfaces
{
    public interface IDomainRepository
    {
        Task<List<Domain>> GetDomainList();
        Task<Guid> Create(Domain domain);
        Task<Domain> GetDomainById(Guid domainId);
        Task<bool> Update(Domain domain);
        Task<bool> Delete(Domain domain);
    }
}
