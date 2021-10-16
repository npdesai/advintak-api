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
    public class MasterDataRepository : IMasterDataRepository
    {
        private readonly IPAMDbContext _dbContext;

        public MasterDataRepository(IPAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SubnetGroup>> GetSubnetGroups()
        {
            return await _dbContext.SubnetGroup.ToListAsync();
        }

        public async Task<List<SubnetMask>> GetSubnetMasks()
        {
            return await _dbContext.SubnetMask.ToListAsync();
        }
    }
}
