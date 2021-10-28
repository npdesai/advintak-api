using IPAM_Common.DTOs.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<List<DeviceDto>> GetDeviceList();
        Task<Guid> AddDevice(DeviceDto deviceDto);
        Task<bool> DeleteDeviceList(List<DeviceDto> deviceList);
    }
}
