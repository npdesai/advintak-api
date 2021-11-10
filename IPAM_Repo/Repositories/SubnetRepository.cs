using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Repo.Repositories
{
    public class SubnetRepository : ISubnetRepository
    {
        private readonly IPAMDbContext _dbContext;

        public SubnetRepository(IPAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Subnet>> GetSubnetsByGroupId(Guid subnetGroupId)
        {
            return await _dbContext.Subnet.Where(s=>s.SubnetGroupId == subnetGroupId).ToListAsync();
        }

        public async Task<Subnet> GetSubnetsById(Guid subnetId)
        {
            return await _dbContext.Subnet.FirstOrDefaultAsync(s => s.SubnetId == subnetId);
        }

        public async Task<Guid> Create(Subnet subnet)
        {
            if (subnet.SubnetAddress == null)
            {
                throw new ValidationException("SubnetAddress can't null");
            }

            await _dbContext.Subnet.AddAsync(subnet);
            await _dbContext.SaveChangesAsync();

            return subnet.SubnetId;
        }

        public async Task<bool> UpdateSubnetDetail(Subnet subnet)
        {
            _dbContext.Entry(subnet).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Subnet subnet)
        {
            _dbContext.Subnet.Remove(subnet);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
