using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs.Setting;
using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api.Services
{
    public class DomainService : IDomainService
    {
        private readonly IMapper _mapper;
        private readonly IDomainRepository _domainRepository;

        public DomainService(IMapper mapper, IDomainRepository domainRepository) : base()
        {
            _mapper = mapper;
            _domainRepository = domainRepository;
        }

        public async Task<List<DomainDto>> GetDomainList()
        {
            return _mapper.Map<List<DomainDto>>(await _domainRepository.GetDomainList());
        }

        public async Task<Guid> AddDomain(DomainDto domainDto)
        {
            return await _domainRepository.Create(_mapper.Map<Domain>(domainDto));
        }

    }
}
