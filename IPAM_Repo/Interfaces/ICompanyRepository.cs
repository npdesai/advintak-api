using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Repo.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Guid> Create(Company company);
        Task<List<Company>> GetCompanies();
    }
}
