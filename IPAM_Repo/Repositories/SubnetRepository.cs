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

        public async Task<Guid> Create(Subnet subnet)
        {
            if (subnet.SubnetAddress == null)
            {
                throw new ValidationException("SubnetAddress can't null");
            }

            if (!string.IsNullOrEmpty(subnet.SubnetGroup.GroupName))
            {
                SubnetGroup subnetGroup = new SubnetGroup()
                {
                    GroupName = subnet.SubnetGroup.GroupName
                };

                await _dbContext.SubnetGroup.AddAsync(subnetGroup);
                await _dbContext.SaveChangesAsync();
                subnet.SubnetGroupId = subnetGroup.GroupId;
            }
            else
            {
                throw new ValidationException("SubnetGroupName can't null");
            }

            await _dbContext.Subnet.AddAsync(subnet);
            await _dbContext.SaveChangesAsync();

            return subnet.SubnetId;
        }
    }
}
