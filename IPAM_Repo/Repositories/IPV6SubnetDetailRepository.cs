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
    public class IPV6SubnetDetailRepository: IIPV6SubnetDetailRepository
    {
        private readonly IPAMDbContext _dbContext;

        public IPV6SubnetDetailRepository(IPAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IPV6SubnetDetail> Get(Guid iPV6SubnetDetailId)
        {
            return await _dbContext.IPV6SubnetDetail.FirstOrDefaultAsync(x => x.IPV6SubnetDetailId == iPV6SubnetDetailId);
        }

        public async Task<List<IPV6SubnetDetail>> GetList(Guid iPV6SubnetId)
        {
            return await _dbContext.IPV6SubnetDetail.Where(x=>x.IPV6SubnetId== iPV6SubnetId).ToListAsync();
        }

        public async Task<Guid> Create(IPV6SubnetDetail iPV6SubnetDetail)
        {
            await _dbContext.IPV6SubnetDetail.AddAsync(iPV6SubnetDetail);
            await _dbContext.SaveChangesAsync();

            return iPV6SubnetDetail.IPV6SubnetDetailId;
        }

        public async Task<bool> UpdateIPV6Detail(IPV6SubnetDetail iPV6SubnetDetail)
        {
            _dbContext.Entry(iPV6SubnetDetail).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
