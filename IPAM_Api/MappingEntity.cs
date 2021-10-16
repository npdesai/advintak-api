using AutoMapper;
using IPAM_Common.DTOs.Master;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Models;

namespace IPAM_Api
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<Subnet, SubnetDto>().ReverseMap();
            CreateMap<SubnetGroup, SubnetGroupDto>().ReverseMap();
            CreateMap<SubnetMask, SubnetMaskDto>().ReverseMap();
            CreateMap<ServerType, ServerTypeDto>().ReverseMap();
        }
    }
}
