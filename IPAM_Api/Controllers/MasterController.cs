using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs.Master;
using IPAM_Common.DTOs.Subnet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        /// <summary>
        /// Get Subnet Groups
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<SubnetGroupDto>), StatusCodes.Status200OK)]
        [Route("api/Master/SubnetGroups", Name = "Get Subnet Groups")]
        [HttpGet]
        public async Task<List<SubnetGroupDto>> GetSubnetGroups()
        {
            return await _masterService.GetSubnetGroups();
        }

        /// <summary>
        /// Get Subnet Masks
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<SubnetMaskDto>), StatusCodes.Status200OK)]
        [Route("api/Master/SubnetMasks", Name = "Get Subnet Masks")]
        [HttpGet]
        public async Task<List<SubnetMaskDto>> GetSubnetMasks()
        {
            return await _masterService.GetSubnetMasks();
        }

        /// <summary>
        /// Get Server Types
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<ServerTypeDto>), StatusCodes.Status200OK)]
        [Route("api/Master/ServerTypes", Name = "Get Server Types")]
        [HttpGet]
        public async Task<List<ServerTypeDto>> GetServerTypes()
        {
            return await _masterService.GetServerTypes();
        }
    }
}
