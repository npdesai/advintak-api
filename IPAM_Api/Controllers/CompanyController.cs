using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Api.Controllers
{
    [Route("")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        /// <summary>
        /// Get Companies
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<CompanyDto>), StatusCodes.Status200OK)]
        [Route("api/Company/Companies", Name = "Get Companies")]
        [HttpGet]
        public async Task<List<CompanyDto>> GetCompanies()
        {
            return await _companyService.GetCompanies();
        }
    }
}
