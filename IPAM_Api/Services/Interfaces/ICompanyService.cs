using IPAM_Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Api.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetCompanies();
    }
}
