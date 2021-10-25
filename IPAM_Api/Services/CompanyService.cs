using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs;
using IPAM_Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(
          IMapper mapper,
         ICompanyRepository companyRepository
          ) : base()
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyDto>> GetCompanies()
        {
            var companies = await _companyRepository.GetCompanies();

            return _mapper.Map<List<CompanyDto>>(companies);
        }
    }
}
