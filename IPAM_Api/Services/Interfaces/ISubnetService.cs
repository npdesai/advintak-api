using IPAM_Common.DTOs;
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
        Task<List<TracertResponseDto>> TraceRoute(string ipAddress);
        Task<PingReplyDto> Ping(string ipAddress);
        Task<List<SubnetIP>> GetSubnetIPs(Guid subnetId);
        Task<SubnetIPDetailDto> ScanAndUpdateSubnetIpDetail(Guid subnetIpId);
        Task<SubnetIPDetailDto> UpdateSubnetIpDetail(SubnetIPDetailDto subnetIPDetail);        
        Task<bool> UpdateSubnet(SubnetDto subnetDto);
        Task<SubnetDto> GetSubnetDetailBySubnetId(Guid subnetId);
        Task<List<SubnetDetailDto>> GetSubnetsByGroupId(Guid subnetGroupId);
        Task<List<SubnetIPHistory>> GetIpHistoryBySubnetId(Guid subnetId);
        Task<SubnetDetailDto> GetSubnetSummary(Guid subnetId);
        Task<bool> DeleteSubnet(Guid subnetId);
    }
}
