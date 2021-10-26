using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api.Services
{
    public class TreeService : ITreeService
    {
        private readonly IMapper _mapper;
        private readonly ISubnetRepository _subnetRepository;
        private readonly ISubnetGroupRepository _subnetGroupRepository;
        private readonly IIPV6SubnetService _iPV6SubnetService;

        public TreeService(
          IMapper mapper,
          ISubnetRepository subnetRepository,
          ISubnetGroupRepository subnetGroupRepository,
          IIPV6SubnetService iPV6SubnetService
          ) : base()
        {
            _mapper = mapper;
            _subnetRepository = subnetRepository;
            _subnetGroupRepository = subnetGroupRepository;
            _iPV6SubnetService = iPV6SubnetService;
        }

        public async Task<List<SubnetTreeDto>> GetSubnetTree()
        {
            List<SubnetTreeDto> subnetTreeList = new List<SubnetTreeDto>();
            List<SubnetGroup> subnetGroupList = await _subnetGroupRepository.GetSubnetGroups();
            List<IPV6SubnetDto> ipv6List = await _iPV6SubnetService.GetIPV6SubnetList();

            if (subnetGroupList.Count() > 0)
            {
                foreach (SubnetGroup subnetGroup in subnetGroupList)
                {
                    SubnetTreeDto subnetTree = new SubnetTreeDto()
                    {
                        Data = "Documents Folder",
                        Label = subnetGroup.GroupName,
                        Path = "/ipam/groups/" + subnetGroup.GroupId,
                        ExpandedIcon = "pi pi-folder-open",
                        CollapsedIcon = "pi pi-folder",
                        Expanded = true,
                        Children = await GetChildNodes(subnetGroup.GroupId)
                    };

                    subnetTreeList.Add(subnetTree);
                }
            }

            if (ipv6List.Count() > 0)
            {
                foreach (IPV6SubnetDto iPV6Subnet in ipv6List)
                {
                    SubnetTreeDto subnetTree = new SubnetTreeDto()
                    {
                        Data = "Documents Folder",
                        Label = iPV6Subnet.PrefixName,
                        Path = "/ipam/groups/",
                        ExpandedIcon = "pi pi-folder-open",
                        CollapsedIcon = "pi pi-folder",
                        Expanded = true                        
                    };

                    subnetTreeList.Add(subnetTree);
                }
            }

            return subnetTreeList;
        }

        public async Task<List<SubnetTreeDto>> GetChildNodes(Guid subnetGroupId)
        {
            List<SubnetTreeDto> subnetChildList = new List<SubnetTreeDto>();
            List<Subnet> SubnetsList = await _subnetRepository.GetSubnetsByGroupId(subnetGroupId);

            if (SubnetsList.Count() > 0)
            {
                foreach (Subnet subnets in SubnetsList)
                {
                    SubnetTreeDto subnetTree = new SubnetTreeDto()
                    {
                        Data = "Work Folder",
                        Label = subnets.SubnetAddress,
                        Path = "/ipam/subnets/" + subnets.SubnetId, //subnets.SubnetAddress.Split("/")[0],
                        ExpandedIcon = "pi pi-cloud",
                        CollapsedIcon = "pi pi-cloud"
                    };

                    subnetChildList.Add(subnetTree);
                }
            }

            return subnetChildList;
        }
    }
}
