using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs.Setting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api.Controllers
{
    [Route("")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public SettingController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        /// <summary>
        /// Get Routers List
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<DeviceDto>), StatusCodes.Status200OK)]
        [Route("api/Setting/Routers", Name = "Get Routers")]
        [HttpGet]
        public async Task<List<DeviceDto>> GetDeviceList()
        {
            return await _deviceService.GetDeviceList();
        }

        /// <summary>
        /// Add Router
        /// </summary>
        /// <param name="deviceDto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [Route("api/Setting/AddRouter", Name = "Add Router")]
        [HttpPost]
        public async Task<ActionResult<Guid>> AddDevice(DeviceDto deviceDto)
        {
            return await _deviceService.AddDevice(deviceDto);
        }
    }
}
