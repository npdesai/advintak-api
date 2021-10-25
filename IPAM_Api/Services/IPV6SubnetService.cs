using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using System;
using System.Threading.Tasks;

namespace IPAM_Api.Services
{
    public class IPV6SubnetService : IIPV6SubnetService
    {
        private readonly IIPV6SubnetRepository _iPV6SubnetRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public IPV6SubnetService(IIPV6SubnetRepository iPV6SubnetRepository, ICompanyRepository companyRepository, IMapper mapper) : base()
        {
            _iPV6SubnetRepository = iPV6SubnetRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddIPV6Subnet(IPV6SubnetDto iPV6Subnet)
        {
            if (iPV6Subnet.CompanyId == null)
            {
                iPV6Subnet.CompanyId = await _companyRepository.Create(new Company { 
                    Name = iPV6Subnet.CompanyName
                });
            }

            return await _iPV6SubnetRepository.Create(_mapper.Map<IPV6Subnet>(iPV6Subnet));
        }
    }
}
