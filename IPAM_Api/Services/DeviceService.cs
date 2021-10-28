using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs.Setting;
using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api.Services
{
    public class DeviceService : IDeviceService
    {                
        private readonly IMapper _mapper;
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IMapper mapper, IDeviceRepository deviceRepository) : base()
        {
            _mapper = mapper;
            _deviceRepository = deviceRepository;
        }

        public async Task<List<DeviceDto>> GetDeviceList()
        {
            return _mapper.Map<List<DeviceDto>>(await _deviceRepository.GetDeviceList());
        }

        public async Task<Guid> AddDevice(DeviceDto deviceDto)
        {           
            return await _deviceRepository.Create(_mapper.Map<Device>(deviceDto));
        }

        public async Task<bool> DeleteDeviceList(List<Guid> devices)
        {
            foreach(Guid deviceId in devices)
            {
                Device device = await _deviceRepository.GetDeviceById(deviceId);
                if(device != null)
                {
                    await _deviceRepository.Delete(device);
                }
            }
            return true;
        }
    }
}
