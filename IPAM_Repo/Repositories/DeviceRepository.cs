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
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IPAMDbContext _dbContext;

        public DeviceRepository(IPAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Device>> GetDeviceList()
        {
            return await _dbContext.Device.ToListAsync();
        }

        public async Task<Guid> Create(Device device)
        {
            await _dbContext.Device.AddAsync(device);
            await _dbContext.SaveChangesAsync();

            return device.DeviceId;
        }
    }
}
