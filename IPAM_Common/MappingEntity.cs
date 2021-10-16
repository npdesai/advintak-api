using AutoMapper;
using IPAM_Common.DTOs.Master;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Common
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<Subnet, SubnetDto>().ReverseMap();
            CreateMap<SubnetGroup, SubnetGroupDto>().ReverseMap();
            CreateMap<SubnetMask, SubnetMaskDto>().ReverseMap();
        }
    }
}
