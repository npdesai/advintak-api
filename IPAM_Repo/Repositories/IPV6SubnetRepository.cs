using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Repo.Repositories
{
    public class IPV6SubnetRepository : IIPV6SubnetRepository
    {
        private readonly IPAMDbContext _dbContext;

        public IPV6SubnetRepository(IPAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<IPV6Subnet>> GetList()
        {            
            return await _dbContext.IPV6Subnet.ToListAsync();
        }

        public async Task<Guid> Create(IPV6Subnet iPV6Subnet)
        {
            await _dbContext.IPV6Subnet.AddAsync(iPV6Subnet);
            await _dbContext.SaveChangesAsync();

            return iPV6Subnet.IPV6SubnetId;
        }
    }
}
