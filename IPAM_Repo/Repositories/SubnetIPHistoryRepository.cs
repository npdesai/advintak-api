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
    public class SubnetIPHistoryRepository : ISubnetIPHistoryRepository
    {
        private readonly IPAMDbContext _dbContext;

        public SubnetIPHistoryRepository(IPAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<SubnetIPHistory>> GetIpHistoryBySubnetId(Guid subnetId)
        {
            return await _dbContext.SubnetIPHistory
                                    .Where(x => x.SubnetId == subnetId)
                                    .OrderBy(x => x.DetectedTime).ToListAsync();
        }

        public async Task<List<SubnetIPHistory>> GetIpHistoryBySubnetGroupId(Guid subnetGroupId)
        {
            return await _dbContext.SubnetIPHistory
                                    .Where(x => x.SubnetId == subnetGroupId)
                                    .OrderBy(x => x.DetectedTime).ToListAsync();
        }

        public async Task<Guid> Create(SubnetIPHistory subnetIPHistory)
        {
            await _dbContext.SubnetIPHistory.AddAsync(subnetIPHistory);
            await _dbContext.SaveChangesAsync();

            return subnetIPHistory.SubnetIPHistoryId;
        }
    }
}
