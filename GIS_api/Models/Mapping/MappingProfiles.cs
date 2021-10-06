using AutoMapper;
using GIS_api.Models.DTO.Master;
using GIS_api.Models.DTO.Subnet;
using GIS_api.Models.Subnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Models.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Subnets, SubnetsDTO>().ReverseMap();
            CreateMap<SubnetGroup, SubnetGroupDto>().ReverseMap();
            CreateMap<SubnetMask, SubnetMaskDto>().ReverseMap();
        }
    }
}
