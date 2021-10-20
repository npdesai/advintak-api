﻿using IPAM_Common.DTOs;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Api.Services.Interfaces
{
    public interface ISubnetService
    {
        Task<Guid> AddSubnet(SubnetDto subnetDto);
        Task<TracertResponseDto> TraceRoute(string ipAddress);
        Task<PingReplyDto> Ping(string ipAddress);
        Task<List<SubnetIP>> GetSubnetIPs(Guid subnetId);
        Task<SubnetIPDetailDto> UpdateSubnetIpDetail(Guid subnetIpId);
    }
}
