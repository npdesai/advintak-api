using IPAM_Common.DTOs.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api.Services.Interfaces
{
    public interface IDomainService
    {
        Task<List<DomainDto>> GetDomainList();
        Task<Guid> AddDomain(DomainDto domainDto);
    }
}
