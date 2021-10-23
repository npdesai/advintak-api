using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common;
using IPAM_Common.DTOs;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace IPAM_Api.Services
{
    public class SubnetService : ISubnetService
    {
        private readonly IMapper _mapper;
        private readonly ISubnetRepository _subnetRepository;
        private readonly IMasterDataRepository _masterDataRepository;
        private readonly ISubnetIpRepository _subnetIpRepository;

        public SubnetService(
          IMapper mapper,
          ISubnetRepository subnetRepository,
          IMasterDataRepository masterDataRepository,
          ISubnetIpRepository subnetIpRepository
          ) : base()
        {
            _mapper = mapper;
            _subnetRepository = subnetRepository;
            _masterDataRepository = masterDataRepository;
            _subnetIpRepository = subnetIpRepository;
        }

        public async Task<Guid> AddSubnet(SubnetDto subnetDto)
        {
            if (subnetDto.SubnetGroupId == null)
            {
                SubnetGroup subnetGroup = new SubnetGroup()
                {
                    GroupName = subnetDto.SubnetGroupName
                };

                subnetDto.SubnetGroupId = await _masterDataRepository.AddGroup(subnetGroup);
            }

            string modifyIP = subnetDto.SubnetAddress.Split(".").Length >= 3 ?
                                      string.Join(".", subnetDto.SubnetAddress.Split(".")[0],
                                                      subnetDto.SubnetAddress.Split(".")[1],
                                                      subnetDto.SubnetAddress.Split(".")[2]) :
                                      subnetDto.SubnetAddress;

            var mask = await _masterDataRepository.GetSubnetMasksById(subnetDto.SubnetMaskId);
            if (mask != null)
            {
                subnetDto.SubnetAddress = string.Join(".", modifyIP, "0") + mask.CIDR;
                var subnetId = await _subnetRepository.Create(_mapper.Map<Subnet>(subnetDto));

                for (int i = 1; i <= mask.Hosts; i++)
                {
                    SubnetIP subnetIP = new SubnetIP()
                    {
                        IPAddress = string.Join(".", modifyIP, i),
                        SubnetId = subnetId
                    };

                    await _subnetIpRepository.Create(subnetIP);
                }

                return subnetId;
            }

            return subnetDto.SubnetId;
        }


        public async Task<List<TracertResponseDto>> TraceRoute(string ipAddress)
        {
            List<TracertResponseDto> tracertResponse = new List<TracertResponseDto>();
            var traceRoute = IPHelper.TraceRoute(ipAddress, 1000);
            if (traceRoute.ToList().Count > 2)
            {
                tracertResponse = _mapper.Map<List<TracertResponseDto>>(traceRoute);
            }
            //if (traceRoute.Any(t => t.Status == IPStatus.Success))
            //{
            //    tracertResponse = traceRoute
            //        .GroupBy(t => t.Address)
            //        .Select(c => new TracertResponseDto()
            //        {
            //            DNSName = c.FirstOrDefault().Hostname,
            //            Hop = c.FirstOrDefault().Hop,
            //            IPAddress = c.LastOrDefault().Address,
            //            ResponseTime1 = c.FirstOrDefault(x => x.Hop == 1).ResponseTime,
            //            ResponseTime2 = c.FirstOrDefault(x => x.Hop == 2).ResponseTime,
            //            ResponseTime3 = c.FirstOrDefault(x => x.Hop == 2).ResponseTime,
            //            Status = true
            //        }).FirstOrDefault();
            //}

            return tracertResponse;
        }


        public async Task<PingReplyDto> Ping(string ipAddress)
        {
            return _mapper.Map<PingReplyDto>(await IPHelper.Ping(ipAddress));
        }


        public async Task<List<SubnetIP>> GetSubnetIPs(Guid subnetId)
        {
            List<SubnetIP> SubnetIpList = await _subnetIpRepository.GetIpListBySubnetId(subnetId);

            return SubnetIpList;
        }

        public async Task<SubnetIPDetailDto> ScanAndUpdateSubnetIpDetail(Guid subnetIpId)
        {
            SubnetIP subnetIP = await _subnetIpRepository.GetSubnetIpDetailById(subnetIpId);
            if (subnetIP != null)
            {
                subnetIP.MacAddress = MacHelper.GetMACAddress(subnetIP.IPAddress);
                subnetIP.Status = IPHelper.Ping(subnetIP.IPAddress).Result.Status == 0 ? "Used" : "Not Reachable";
                subnetIP.ConnectedSwitch = GatewayHelper.GetDefaultGatewayIP(subnetIP.IPAddress);
                subnetIP.LastScan = DateTime.Now;

                await _subnetIpRepository.UpdateSubnetIpDetail(subnetIP);
            }

            subnetIP = await _subnetIpRepository.GetSubnetIpDetailById(subnetIpId);

            return _mapper.Map<SubnetIPDetailDto>(subnetIP);
        }


        public async Task<SubnetIPDetailDto> UpdateSubnetIpDetail(SubnetIPDetailDto subnetIPDetail)
        {
            SubnetIP subnetIP = await _subnetIpRepository.GetSubnetIpDetailById(subnetIPDetail.SubnetIPId);
            if (subnetIP != null)
            {
                subnetIP.Status = subnetIPDetail.Status;
                subnetIP.ReservedStatus = subnetIPDetail.ReservedStatus;
                subnetIP.AliasName = subnetIPDetail.AliasName;
                subnetIP.AssetTag = subnetIPDetail.AssetTag;
                subnetIP.SystemLocation = subnetIPDetail.SystemLocation;
                subnetIP.DeviceType = subnetIPDetail.DeviceType;

                await _subnetIpRepository.UpdateSubnetIpDetail(subnetIP);
            }

            subnetIP = await _subnetIpRepository.GetSubnetIpDetailById(subnetIPDetail.SubnetId);

            return _mapper.Map<SubnetIPDetailDto>(subnetIP);
        }
    }
}
