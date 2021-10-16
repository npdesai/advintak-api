﻿using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs;
using IPAM_Common.DTOs.Subnet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
