using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<SubnetGroup> GetSubnetGroupById(Guid groupId)
        {
            return await _dbContext.SubnetGroup.FirstOrDefaultAsync(x=>x.GroupId == groupId);
        }

        public async Task<List<SubnetMask>> GetSubnetMasks()
        {
            return await _dbContext.SubnetMask.ToListAsync();
        }

        public async Task<SubnetMask> GetSubnetMasksById(Guid maskId)
        {
            return await _dbContext.SubnetMask.FirstOrDefaultAsync(m=>m.MaskId == maskId);
        }

        public async Task<List<ServerType>> GetServerTypes()
        {
            return await _dbContext.ServerType.ToListAsync();
        }


        public async Task<Guid> AddGroup(SubnetGroup subnetGroup)
        {
            await _dbContext.SubnetGroup.AddAsync(subnetGroup);
            await _dbContext.SaveChangesAsync();
            return subnetGroup.GroupId;
        }
    }
}
