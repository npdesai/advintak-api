using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs.Subnet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _treeService;

        public TreeController(ITreeService treeService)
        {
            _treeService = treeService;
        }

        /// <summary>
        /// Get Subnet Tree
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<SubnetTreeDto>), StatusCodes.Status200OK)]        
        [HttpGet]
        [Route("api/Tree", Name = "Get Tree")]
        public async Task<List<SubnetTreeDto>> GetSubnetTree()
        {
            return await _treeService.GetSubnetTree();
        }
    }
}
