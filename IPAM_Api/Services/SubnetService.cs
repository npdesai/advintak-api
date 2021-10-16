using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IPAM_Api.Services
{
    public class SubnetService : ISubnetService
    {
        private readonly IMapper _mapper;
        private readonly ISubnetRepository _subnetRepository;

        public SubnetService(            
          IMapper mapper,
          ISubnetRepository subnetRepository
          ) : base()
        {
            _mapper = mapper;
            _subnetRepository = subnetRepository;
        }

        public async Task<Guid> AddSubnet(SubnetDto subnetDto)
        {
            return await _subnetRepository.Create(_mapper.Map<Subnet>(subnetDto));
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
