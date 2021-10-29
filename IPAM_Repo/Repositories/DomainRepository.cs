using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Repositories
{
    public class DomainRepository : IDomainRepository
    {
        private readonly IPAMDbContext _dbContext;

        public DomainRepository(IPAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain>> GetDomainList()
        {
            return await _dbContext.Domains.ToListAsync();
        }

        public async Task<Domain> GetDomainById(Guid domainId)
        {
            return await _dbContext.Domains.FirstOrDefaultAsync(d=>d.DomainId == domainId);
        }

        public async Task<Guid> Create(Domain domain)
        {
            await _dbContext.Domains.AddAsync(domain);
            await _dbContext.SaveChangesAsync();

            return domain.DomainId;
        }

        public async Task<bool> Update(Domain domain)
        {
            _dbContext.Entry(domain).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Domain domain)
        {
            _dbContext.Domains.Remove(domain);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
