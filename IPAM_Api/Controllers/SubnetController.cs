﻿using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("")]
    public class SubnetController : ControllerBase
    {
        private readonly ISubnetService _subnetService;

        public SubnetController(ISubnetService subnetService)
        {
            _subnetService = subnetService;
        }

        /// <summary>
        /// Add Subnet
        /// </summary>
        /// <param name="subnetDto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [Route("api/Subnet/Add", Name = "Add Subnet")]
        [HttpPost]        
        public async Task<ActionResult<Guid>> AddSubnet(SubnetDto subnetDto)
        {
            return await _subnetService.AddSubnet(subnetDto);
        }

        /// <summary>
        /// SubnetIpList
        /// </summary>
        /// <param name="subnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SubnetIP), StatusCodes.Status200OK)]
        [Route("api/Subnet/SubnetIpList", Name = "SubnetIpList")]
        [HttpGet]
        public async Task<List<SubnetIP>> GetSubnetIpList(Guid subnetId)
        {
            return await _subnetService.GetSubnetIPs(subnetId);
        }

        /// <summary>
        /// Scan Subnet IP By Id, 
        /// And get IP details.
        /// </summary>
        /// <param name="subnetIpId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SubnetIPDetailDto), StatusCodes.Status200OK)]
        [Route("api/Subnet/ScanIP", Name = "Scan Subnet IP")]
        [HttpPatch]
        public async Task<SubnetIPDetailDto> ScanIPById(Guid subnetIpId)
        {
            return await _subnetService.ScanAndUpdateSubnetIpDetail(subnetIpId);
        }

        /// <summary>
        /// Update Subnet IP,         
        /// </summary>
        /// <param name="subnetIPDetail"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SubnetIPDetailDto), StatusCodes.Status200OK)]
        [Route("api/Subnet/UpdateIPById", Name = "Update Subnet IP")]
        [HttpPatch]
        public async Task<SubnetIPDetailDto> UpdateIPById(SubnetIPDetailDto subnetIPDetail)
        {
            return await _subnetService.UpdateSubnetIpDetail(subnetIPDetail);
        }

        /// <summary>
        /// Trace Route
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TracertResponseDto), StatusCodes.Status200OK)]
        [Route("api/Subnet/TraceRoute", Name = "Trace Route")]
        [HttpGet]
        public async Task<TracertResponseDto> TraceRoute(string ipAddress)
        {
            return await _subnetService.TraceRoute(ipAddress);
        }

        /// <summary>
        /// Ping
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(PingReplyDto), StatusCodes.Status200OK)]
        [Route("api/Subnet/Ping", Name = "Ping")]
        [HttpGet]
        public async Task<PingReplyDto> Ping(string ipAddress)
        {
            return await _subnetService.Ping(ipAddress);
        }
    }
}
