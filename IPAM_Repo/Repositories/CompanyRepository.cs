using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using System;
using System.Threading.Tasks;

namespace IPAM_Repo.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IPAMDbContext _dbContext;

        public CompanyRepository(IPAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Create(Company company)
        {
            await _dbContext.Company.AddAsync(company);
            await _dbContext.SaveChangesAsync();

            return company.CompanyId;
        }
    }
}
