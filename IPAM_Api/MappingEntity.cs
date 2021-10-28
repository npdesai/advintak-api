using AutoMapper;
using IPAM_Common.DTOs;
using IPAM_Common.DTOs.Master;
using IPAM_Common.DTOs.Setting;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Models;
using System.Net.NetworkInformation;

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
            CreateMap<SubnetIP, SubnetIPDetailDto>().ReverseMap();
            CreateMap<PingReply, PingReplyDto>().ReverseMap();
            CreateMap<TracertEntryDto, TracertResponseDto>().ReverseMap();
            CreateMap<IPV6SubnetDto, IPV6Subnet>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<Domain, DomainDto>().ReverseMap();
        }
    }
}
