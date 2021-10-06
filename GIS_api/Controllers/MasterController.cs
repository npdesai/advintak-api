using GIS_api.Models.DTO.Master;
using GIS_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Controllers
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

        [HttpGet("getsubnetgroups")]
        public async Task<IEnumerable<SubnetGroupDto>> GetSubnetGroups()
        {
            return await _masterService.GetSubnetGroups();
        }

        [HttpGet("getsubnetmask")]
        public async Task<IEnumerable<SubnetMaskDto>> GetSubnetMask()
        {
            return await _masterService.GetSubnetMask();
        }
    }
}
