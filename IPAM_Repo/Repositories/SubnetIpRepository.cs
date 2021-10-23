using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Repositories
{
    public class SubnetIpRepository : ISubnetIpRepository
    {
        private readonly IPAMDbContext _dbContext;

        public SubnetIpRepository(IPAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SubnetIP>> GetIpListBySubnetId(Guid subnetId)
        {            
            return await _dbContext.SubnetIP.Where(x => x.SubnetId == subnetId).OrderBy(x=>x.IPAddress).ToListAsync();
        }

        public async Task<SubnetIP> GetSubnetIpDetailById(Guid Id)
        {
            return await _dbContext.SubnetIP.FirstOrDefaultAsync(x => x.SubnetIPId == Id);
        }

        public async Task<bool> UpdateSubnetIpDetail(SubnetIP subnetIP)
        {
            _dbContext.Entry(subnetIP).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Guid> Create(SubnetIP subnetIP)
        {
            await _dbContext.SubnetIP.AddAsync(subnetIP);
            await _dbContext.SaveChangesAsync();

            return subnetIP.SubnetId;
        }
    }
}
