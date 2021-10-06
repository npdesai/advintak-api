using AutoMapper;
using GIS_api.Models;
using GIS_api.Models.DTO.Subnet;
using GIS_api.Models.Subnet;
using GIS_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Services
{
    public class SubnetService : ISubnetService
    {
        private readonly IMapper _mapper;        
        private readonly GisContext _gisContext;

        public SubnetService(            
          IMapper mapper,
          GisContext gisContext          
          ) : base()
        {
            _mapper = mapper;
            _gisContext = gisContext;            
        }

        public async Task<int> AddSubnet(SubnetsDTO obj)
        {
            Subnets entity = _mapper.Map<Subnets>(obj);
            
            if (entity.SubnetAddress == null)
            {
                throw new ValidationException("SubnetAddress can't null");
            }

            if (entity.SubnetGroupId == 0)
            {
                SubnetGroup group = new SubnetGroup() { 
                  GroupName = obj.SubnetGroupName
                };

                _gisContext.SubnetGroup.Add(group);
                await _gisContext.SaveChangesAsync();
                entity.SubnetGroupId = group.GroupId;
            }

            _gisContext.Subnets.Add(entity);
            return await _gisContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SubnetTreeDto>> GetSubnetTree()
        {
            List<SubnetTreeDto> subnetTreeList =  new List<SubnetTreeDto>();
            IEnumerable <SubnetGroup> subnetGroupList = await _gisContext.SubnetGroup.OrderBy(o=>o.GroupId).ToListAsync();

            if(subnetGroupList.Count() > 0)
            {
                foreach(SubnetGroup subnetGroup in subnetGroupList)
                {
                    SubnetTreeDto subnetTree = new SubnetTreeDto(){
                        data = "Documents Folder",
                        label = subnetGroup.GroupName,
                        path = "/ipam/groups/" + subnetGroup.GroupId,
                        expandedIcon = "pi pi-folder-open",
                        collapsedIcon = "pi pi-folder",
                        expanded = true,
                        children = GetChildNodes(subnetGroup.GroupId)
                    };

                    subnetTreeList.Add(subnetTree);
                }
            }

            return subnetTreeList;
        }

        public IEnumerable<SubnetTreeDto> GetChildNodes(int subnetGroupId)
        {
            List<SubnetTreeDto> subnetChildList = new List<SubnetTreeDto>();
            IEnumerable<Subnets> SubnetsList = _gisContext.Subnets.Where(s=>s.SubnetGroupId == subnetGroupId).ToList();

            if (SubnetsList.Count() > 0)
            {
                foreach (Subnets subnets in SubnetsList)
                {
                    SubnetTreeDto subnetTree = new SubnetTreeDto()
                    {
                        data = "Work Folder",
                        label = subnets.SubnetAddress,
                        path = "/ipam/subnets/" + subnets.SubnetAddress.Split("/")[0],
                        expandedIcon = "pi pi-cloud",
                        collapsedIcon = "pi pi-cloud"
                    };

                    subnetChildList.Add(subnetTree);
                }
            }

            return subnetChildList;
        }
    }
}
