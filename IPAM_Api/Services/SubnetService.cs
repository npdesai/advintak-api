using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common;
using IPAM_Common.DTOs;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using System;
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

            var mask = await _masterDataRepository.GetSubnetMasksById(subnetDto.SubnetMaskId);
            if (mask != null)
            {
                for(int i=0; i <= mask.Addresses; i++)
                {
                    SubnetIP subnetIP = new SubnetIP()
                    {
                        IPAddress = subnetDto.SubnetAddress
                    };

                   await _subnetIpRepository.Create(subnetIP);
                }
            }

            return await _subnetRepository.Create(_mapper.Map<Subnet>(subnetDto));
        }


        public async Task<TracertResponseDto> TraceRoute(string ipAddress)
        {
            TracertResponseDto tracertResponse = new TracertResponseDto();
            var traceRoute = IPHelper.TraceRoute(ipAddress, 3, 1000);
            if (traceRoute.Any(t => t.Status == IPStatus.Success))
            {
                tracertResponse = traceRoute
                    .GroupBy(t => t.Address)
                    .Select(c => new TracertResponseDto()
                    {
                        DNSName = c.FirstOrDefault().Hostname,
                        Hop = c.FirstOrDefault().Hop,
                        IPAddress = c.LastOrDefault().Address,
                        ResponseTime1 = c.FirstOrDefault(x => x.Hop == 1).ResponseTime,
                        ResponseTime2 = c.FirstOrDefault(x => x.Hop == 2).ResponseTime,
                        ResponseTime3 = c.FirstOrDefault(x => x.Hop == 2).ResponseTime,
                        Status = true
                    }).FirstOrDefault();
            }

            return tracertResponse;
        }


        public async Task<PingReplyDto> Ping(string ipAddress)
        {
            return _mapper.Map<PingReplyDto>(await IPHelper.Ping(ipAddress));
        }

        //public async Task<IEnumerable<SubnetTreeDto>> GetSubnetTree()
        //{
        //    List<SubnetTreeDto> subnetTreeList =  new List<SubnetTreeDto>();
        //    IEnumerable <SubnetGroup> subnetGroupList = await _gisContext.SubnetGroup.OrderBy(o=>o.GroupId).ToListAsync();

        //    if(subnetGroupList.Count() > 0)
        //    {
        //        foreach(SubnetGroup subnetGroup in subnetGroupList)
        //        {
        //            SubnetTreeDto subnetTree = new SubnetTreeDto(){
        //                data = "Documents Folder",
        //                label = subnetGroup.GroupName,
        //                path = "/ipam/groups/" + subnetGroup.GroupId,
        //                expandedIcon = "pi pi-folder-open",
        //                collapsedIcon = "pi pi-folder",
        //                expanded = true,
        //                children = GetChildNodes(subnetGroup.GroupId)
        //            };

        //            subnetTreeList.Add(subnetTree);
        //        }
        //    }

        //    return subnetTreeList;
        //}

        //public async Task<IEnumerable<SubnetIpDetail>> GetSubnetIPs(string subnet)
        //{
        //    List<SubnetIpDetail> SubnetIpList = new List<SubnetIpDetail>();
        //    string subnetmask = string.Join(".",subnet.Split(".")[0],subnet.Split(".")[1],subnet.Split(".")[2]);

        //    if (!string.IsNullOrEmpty(subnetmask))
        //    {
        //       for(int i=1; i <= 254; i++)
        //        {
        //            SubnetIpDetail subnetIpDetail = new SubnetIpDetail() {
        //                ipAddress = string.Join(".", subnetmask, i),
        //                //macAddress = GetClientMAC(string.Join(".", subnetmask, i)),
        //                //ipDNS = GetIP(string.Join(".", subnetmask, i))
        //            };

        //            SubnetIpList.Add(subnetIpDetail);
        //        }
        //    }

        //    return SubnetIpList;
        //}

        //public IEnumerable<SubnetTreeDto> GetChildNodes(int subnetGroupId)
        //{
        //    List<SubnetTreeDto> subnetChildList = new List<SubnetTreeDto>();
        //    IEnumerable<Subnets> SubnetsList = _gisContext.Subnets.Where(s=>s.SubnetGroupId == subnetGroupId).ToList();        

        //    if (SubnetsList.Count() > 0)
        //    {
        //        foreach (Subnets subnets in SubnetsList)
        //        {
        //            SubnetTreeDto subnetTree = new SubnetTreeDto()
        //            {
        //                data = "Work Folder",
        //                label = subnets.SubnetAddress,
        //                path = "/ipam/subnets/" + subnets.SubnetAddress.Split("/")[0],
        //                expandedIcon = "pi pi-cloud",
        //                collapsedIcon = "pi pi-cloud"
        //            };

        //            subnetChildList.Add(subnetTree);
        //        }
        //    }

        //    return subnetChildList;
        //}
    }
}
