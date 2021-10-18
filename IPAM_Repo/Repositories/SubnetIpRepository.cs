using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
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

        public async Task<Guid> Create(SubnetIP subnetIP)
        {
            await _dbContext.SubnetIP.AddAsync(subnetIP);
            await _dbContext.SaveChangesAsync();

            return subnetIP.SubnetId;
        }
    }
}
