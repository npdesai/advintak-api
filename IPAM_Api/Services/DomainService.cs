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

        public async Task<DomainDto> UpdateDomain(DomainDto domainDto)
        {
            Domain domain = await _domainRepository.GetDomainById(domainDto.DomainId);
            if (domain != null)
            {
                domain.DomainName = domainDto.DomainName;
                domain.DomainControllerName = domainDto.DomainControllerName;
                domain.Password = domainDto.Password;
                domain.UserName = domainDto.UserName;
                await _domainRepository.Update(domain);
                return domainDto;
            }

            return domainDto;
        }


        public async Task<bool> DeleteDomain(Guid DomainId)
        {
            Domain domain = await _domainRepository.GetDomainById(DomainId);
            if (domain != null)
            {
                await _domainRepository.Delete(domain);
                return true;
            }
            return false;
        }
    }
}
