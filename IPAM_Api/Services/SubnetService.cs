using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common;
using IPAM_Common.DTOs;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private readonly ISubnetIPHistoryRepository _subnetIPHistoryRepository;

        public SubnetService(
          IMapper mapper,
          ISubnetRepository subnetRepository,
          IMasterDataRepository masterDataRepository,
          ISubnetIpRepository subnetIpRepository,
          ISubnetIPHistoryRepository subnetIPHistoryRepository
          ) : base()
        {
            _mapper = mapper;
            _subnetRepository = subnetRepository;
            _masterDataRepository = masterDataRepository;
            _subnetIpRepository = subnetIpRepository;
            _subnetIPHistoryRepository = subnetIPHistoryRepository;
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
                        SubnetId = subnetId,
                        VlanId = subnetDto.VlanId,
                        VlanName = subnetDto.VlanName,
                        AccessMode = subnetDto.AccessMode,
                        ScanStatus="Not Scanned"
                    };

                    await _subnetIpRepository.Create(subnetIP);
                }

                return subnetId;
            }

            return subnetDto.SubnetId;
        }


        public async Task<bool> UpdateSubnet(SubnetDto subnetDto)
        {
            Subnet subnet = await _subnetRepository.GetSubnetsById(subnetDto.SubnetId);
            if (subnet != null)
            {
                subnet.SubnetGroupId = (Guid)subnetDto.SubnetGroupId;
                subnet.Alert = subnetDto.Alert;
                subnet.Warning = subnetDto.Warning;
                subnet.Critical = subnetDto.Critical;
                subnet.Email = subnetDto.Email;
                subnet.SubnetName = subnetDto.SubnetName;
                subnet.SubnetDescription = subnetDto.SubnetDescription;
                subnet.VlanName = subnetDto.VlanName;
                subnet.Location = subnetDto.Location;

                await _subnetRepository.UpdateSubnetDetail(subnet);
                return true;
            }            

            return false;
        }

        public async Task<SubnetDto> GetSubnetDetailBySubnetId(Guid subnetId)
        {
            Subnet subnet = await _subnetRepository.GetSubnetsById(subnetId);
            if (subnet == null)
            {
                throw new ValidationException("Subnet detail not found");
            }

            SubnetDto subnetDto = _mapper.Map<SubnetDto>(subnet);
            subnetDto.SubnetIpList = _mapper.Map<List<SubnetIPDetailDto>>(await _subnetIpRepository.GetIpListBySubnetId(subnet.SubnetId));

            return subnetDto;
        }


        public async Task<SubnetIPDetailDto> GetSubnetIpDetailBySubnetIpId(Guid subnetIpId)
        {
            SubnetIP subnetIP = await _subnetIpRepository.GetSubnetIpDetailById(subnetIpId);
            if (subnetIP == null)
            {
                throw new ValidationException("Subnet detail not found");
            }

            SubnetIPDetailDto subnetIPDetailDto = _mapper.Map<SubnetIPDetailDto>(subnetIP);            

            return subnetIPDetailDto;
        }


        public async Task<List<TracertResponseDto>> TraceRoute(string ipAddress)
        {
            List<TracertResponseDto> tracertResponse = new List<TracertResponseDto>();
            var traceRoute = IPHelper.TraceRoute(ipAddress, 1000);
            if (traceRoute.ToList().Count > 0)
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

        public async Task<List<SubnetDetailDto>> GetSubnetsByGroupId(Guid subnetGroupId)
        {
            List<SubnetDetailDto> subnetDetailList = new List<SubnetDetailDto>();
            List<Subnet> subnets = await _subnetRepository.GetSubnetsByGroupId(subnetGroupId);

            foreach (var subnet in subnets)
            {
                List<SubnetIP> subnetIps = await _subnetIpRepository.GetIpListBySubnetId(subnet.SubnetId);

                if (subnetIps.Count > 0)
                {
                    subnetDetailList.Add(new SubnetDetailDto()
                    {
                        SubnetId = subnet.SubnetId,
                        SubnetGroupId = subnet.SubnetGroupId,
                        SubnetMaskId = subnet.SubnetMaskId,
                        SubnetAddress = subnet.SubnetAddress,
                        SubnetName = subnet.SubnetName,
                        SubnetSize = subnetIps.Count,
                        SubnetUsage = (subnetIps.Where(x => x.Status == "Used").ToList().Count() * 100 / subnetIps.Count),
                        ScanStatus = "Scanned",
                        Available = subnetIps.Where(x => x.Status != "Used" || x.Status != "Quarantine").ToList().Count(),
                        Used = subnetIps.Where(x => x.Status == "Used").ToList().Count(),
                        Quarantine = subnetIps.Where(x => x.Status == "Quarantine").ToList().Count(),
                        LastScanTime = DateTime.Now,
                    });
                }
            }

            return subnetDetailList;
        }

        public async Task<SubnetDetailDto> GetSubnetSummary(Guid subnetId)
        {
            SubnetDetailDto subnetSummary = new SubnetDetailDto();
            Subnet subnet = await _subnetRepository.GetSubnetsById(subnetId);

            if(subnet != null)
            {
                List<SubnetIP> subnetIps = await _subnetIpRepository.GetIpListBySubnetId(subnet.SubnetId);

                if (subnetIps.Count > 0)
                {
                    subnetSummary = new SubnetDetailDto()
                    {
                        SubnetId = subnet.SubnetId,
                        SubnetGroupId = subnet.SubnetGroupId,
                        SubnetGroupName = _masterDataRepository.GetSubnetGroupById(subnet.SubnetGroupId).Result.GroupName,
                        SubnetMaskId = subnet.SubnetMaskId,
                        SubnetMask = _masterDataRepository.GetSubnetMasksById(subnet.SubnetMaskId).Result.NetMask,
                        SubnetAddress = subnet.SubnetAddress,
                        SubnetName = subnet.SubnetName,
                        SubnetSize = subnetIps.Count,
                        SubnetUsage = (subnetIps.Where(x => x.Status == "Used").ToList().Count() * 100 / subnetIps.Count),
                        ScanStatus = "Scanned",
                        Available = subnetIps.Where(x => x.Status == "Available" ).ToList().Count(),
                        Used = subnetIps.Where(x => x.Status == "Used").ToList().Count(),
                        Quarantine = subnetIps.Where(x => x.Status == "Quarantine").ToList().Count(),
                        NotReachable = subnetIps.Where(x => x.Status == "Not Reachable").ToList().Count(),
                        LastScanTime = DateTime.Now,
                        VlanName = subnet.VlanName,
                        Description = subnet.SubnetDescription,
                        Location = subnet.Location,
                    };
                }
            }

            return subnetSummary;
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
                subnetIP.ScanStatus = subnetIP.Status == "Used"? "Scanned": "Not Reachable";

                await _subnetIpRepository.UpdateSubnetIpDetail(subnetIP);
            }

            await _subnetIPHistoryRepository.Create(new SubnetIPHistory() { 
                SubnetIPId = subnetIP.SubnetIPId,
                SubnetId = subnetIP.SubnetId,
                IPAddress = subnetIP.IPAddress,
                DNSName = "",
                MacAddress = subnetIP.MacAddress,
                DeviceType = subnetIP.DeviceType,
                DetectedTime = DateTime.Now,
                SysDescription = "test"
            });

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
                subnetIP.VlanId = subnetIPDetail.VlanId;
                subnetIP.VlanName = subnetIPDetail.VlanName;
                subnetIP.AccessMode = subnetIPDetail.AccessMode;

                await _subnetIpRepository.UpdateSubnetIpDetail(subnetIP);
            }

            subnetIP = await _subnetIpRepository.GetSubnetIpDetailById(subnetIPDetail.SubnetIPId);

            return _mapper.Map<SubnetIPDetailDto>(subnetIP);
        }

        public async Task<List<SubnetIPHistory>> GetIpHistoryBySubnetId(Guid subnetId)
        {
            return await _subnetIPHistoryRepository.GetIpHistoryBySubnetId(subnetId);
        }

        public async Task<bool> DeleteSubnet(Guid subnetId)
        {
            Subnet subnet = await _subnetRepository.GetSubnetsById(subnetId);

            if (subnet != null)
            {
                List<SubnetIP> subnetIps = await _subnetIpRepository.GetIpListBySubnetId(subnet.SubnetId);
                if (subnetIps.Count > 0)
                {
                    await _subnetIpRepository.DeleteBySubnetId(subnetIps);
                }
                
                return await _subnetRepository.Delete(subnet);
            }

            return false;
        }
    }
}
