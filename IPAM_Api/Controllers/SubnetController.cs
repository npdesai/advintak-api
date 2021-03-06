using IPAM_Api.Services.Interfaces;
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
        private readonly IIPV6SubnetService _iPV6SubnetService;

        public SubnetController(ISubnetService subnetService, IIPV6SubnetService iPV6SubnetService)
        {
            _subnetService = subnetService;
            _iPV6SubnetService = iPV6SubnetService;
        }

        /// <summary>
        /// Subnet Detail
        /// </summary>
        /// <param name="subnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SubnetDto), StatusCodes.Status200OK)]
        [Route("api/Subnet/GetSubnetDetailBySubnetId", Name = "Subnet Detail By SubnetId")]
        [HttpGet]
        public async Task<SubnetDto> GetSubnetDetailBySubnetId(Guid subnetId)
        {
            return await _subnetService.GetSubnetDetailBySubnetId(subnetId);
        }

        /// <summary>
        /// SubnetIP Detail
        /// </summary>
        /// <param name="subnetIPId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SubnetIPDetailDto), StatusCodes.Status200OK)]
        [Route("api/Subnet/GetSubnetIpDetailBySubnetIpId", Name = "SubnetIP Detail By SubnetIpId")]
        [HttpGet]
        public async Task<SubnetIPDetailDto> GetSubnetIpDetailBySubnetIpId(Guid subnetIPId)
        {
            return await _subnetService.GetSubnetIpDetailBySubnetIpId(subnetIPId);
        }

        /// <summary>
        /// Subnet Summary
        /// </summary>
        /// <param name="subnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SubnetDetailDto), StatusCodes.Status200OK)]
        [Route("api/Subnet/GetSubnetSummary", Name = "Subnet Summary By SubnetId")]
        [HttpGet]
        public async Task<SubnetDetailDto> GetSubnetSummary(Guid subnetId)
        {
            return await _subnetService.GetSubnetSummary(subnetId);
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
        /// Update Subnet
        /// </summary>
        /// <param name="subnetDto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [Route("api/Subnet/Update", Name = "Update Subnet")]
        [HttpPatch]
        public async Task<bool> UpdateSubnet(SubnetDto subnetDto)
        {
            return await _subnetService.UpdateSubnet(subnetDto);
        }

        /// <summary>
        /// SubnetIpList
        /// </summary>
        /// <param name="subnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<SubnetIP>), StatusCodes.Status200OK)]
        [Route("api/Subnet/SubnetIpList", Name = "SubnetIpList")]
        [HttpGet]
        public async Task<List<SubnetIP>> GetSubnetIpList(Guid subnetId)
        {
            return await _subnetService.GetSubnetIPs(subnetId);
        }

        /// <summary>
        /// Subnets By GroupId
        /// </summary>
        /// <param name="subnetGroupId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<SubnetDetailDto>), StatusCodes.Status200OK)]
        [Route("api/Subnet/GetSubnetListByGroupId", Name = "Subnet List By GroupId")]
        [HttpGet]
        public async Task<List<SubnetDetailDto>> GetSubnetListByGroupId(Guid subnetGroupId)
        {
            return await _subnetService.GetSubnetsByGroupId(subnetGroupId);
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
        [ProducesResponseType(typeof(List<TracertResponseDto>), StatusCodes.Status200OK)]
        [Route("api/Subnet/TraceRoute", Name = "Trace Route")]
        [HttpGet]
        public async Task<List<TracertResponseDto>> TraceRoute(string ipAddress)
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

        /// <summary>
        /// Add IPV6 Subnet
        /// </summary>
        /// <param name="iPV6SubnetDto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [Route("api/Subnet/AddIPV6", Name = "Add IPV6 Subnet")]
        [HttpPost]
        public async Task<ActionResult<Guid>> AddIPV6Subnet(IPV6SubnetDto iPV6SubnetDto)
        {
            return await _iPV6SubnetService.AddIPV6Subnet(iPV6SubnetDto);
        }

        /// <summary>
        /// Get IPV6 Subnet Detail List
        /// </summary>
        /// <param name="iPV6SubnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<IPV6SubnetDetailDto>), StatusCodes.Status200OK)]
        [Route("api/Subnet/GetIPV6SubnetDetailList", Name = "Get IPV6 Subnet Detail List")]
        [HttpGet]
        public async Task<List<IPV6SubnetDetailDto>> GetIPV6SubnetDetailList(Guid iPV6SubnetId)
        {
            return await _iPV6SubnetService.GetIPV6SubnetDetailList(iPV6SubnetId);
        }

        /// <summary>
        /// Update IPV6 Detail,         
        /// </summary>
        /// <param name="iPV6SubnetDetail"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IPV6SubnetDetailDto), StatusCodes.Status200OK)]
        [Route("api/Subnet/UpdateIPV6DetailById", Name = "Update IPV6 Detail")]
        [HttpPatch]
        public async Task<IPV6SubnetDetailDto> UpdateIPV6DetailById(IPV6SubnetDetailDto iPV6SubnetDetail)
        {
            return await _iPV6SubnetService.UpdateIPV6SubnetDetail(iPV6SubnetDetail);
        }

        /// <summary>
        /// Get Subnet History
        /// </summary>
        /// <param name="subnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<SubnetIPHistory>), StatusCodes.Status200OK)]
        [Route("api/Subnet/GetSubnetHistory", Name = "Get Subnet History")]
        [HttpGet]
        public async Task<List<SubnetIPHistory>> GetSubnetHistory(Guid subnetId)
        {
            return await _subnetService.GetIpHistoryBySubnetId(subnetId);
        }

        /// <summary>
        /// Get Delete Subnet
        /// </summary>
        /// <param name="subnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [Route("api/Subnet/DeleteSubnet", Name = "Delete Subnet")]
        [HttpDelete]
        public async Task<bool> DeleteSubnet(Guid subnetId)
        {
            return await _subnetService.DeleteSubnet(subnetId);
        }
    }
}
