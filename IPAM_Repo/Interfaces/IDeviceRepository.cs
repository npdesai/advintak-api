using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Interfaces
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetDeviceList();
        Task<Guid> Create(Device device);
        Task<bool> Delete(Device device);
        Task<Device> GetDeviceById(Guid deviceId);
    }
}
