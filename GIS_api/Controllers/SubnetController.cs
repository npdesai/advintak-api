using GIS_api.Models.DTO.Subnet;
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
    public class SubnetController : ControllerBase
    {
        private readonly ISubnetService _subnetService;

        public SubnetController(ISubnetService subnetService)
        {
            _subnetService = subnetService;
        }

        [HttpGet("getsubnettree")]
        public async Task<IEnumerable<SubnetTreeDto>> GetSubnetTree()
        {
            return await _subnetService.GetSubnetTree();
        }

        [HttpGet("getsubnetdetail")]
        public async Task<IEnumerable<SubnetIpDetail>> GetSubnetDetail(string subnet)
        {
            return await _subnetService.GetSubnetDetail(subnet);
        }

        [HttpPost]        
        public async Task<ActionResult<long>> AddAbuseNeglect(SubnetsDTO obj)
        {
            return await _subnetService.AddSubnet(obj);
        }
    }
}
