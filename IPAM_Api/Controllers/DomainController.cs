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
    public class DomainController : ControllerBase
    {
        private readonly IDomainService _domainService;

        public DomainController(IDomainService domainService)
        {
            _domainService = domainService;
        }

        /// <summary>
        /// Get Domain List
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<DomainDto>), StatusCodes.Status200OK)]
        [Route("api/Domain/DomainList", Name = "Get Domains")]
        [HttpGet]
        public async Task<List<DomainDto>> GetDomainList()
        {
            return await _domainService.GetDomainList();
        }

        /// <summary>
        /// Add Domain
        /// </summary>
        /// <param name="domainDto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [Route("api/Domain/AddDomain", Name = "Add Domain")]
        [HttpPost]
        public async Task<ActionResult<Guid>> AddDomain(DomainDto domainDto)
        {
            return await _domainService.AddDomain(domainDto);
        }

        /// <summary>
        /// Update Domain
        /// </summary>
        /// <param name="domainDto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [Route("api/Domain/UpdateDomain", Name = "Update Domain")]
        [HttpPatch]
        public async Task<ActionResult<bool>> UpdateDomain(DomainDto domainDto)
        {
            return await _domainService.UpdateDomain(domainDto);
        }

        /// <summary>
        /// Delete Domain
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [Route("api/Domain/DeleteDomain", Name = "Delete Domain")]
        [HttpPatch]
        public async Task<ActionResult<bool>> DeleteDomain(Guid domainId)
        {
            return await _domainService.DeleteDomain(domainId);
        }
    }
}
