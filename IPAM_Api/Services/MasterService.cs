using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs.Master;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAM_Api.Services
{
    public class MasterService : IMasterService
    {
        private readonly IMasterDataRepository _masterDataRepository;
        private readonly IMapper _mapper;

        public MasterService(
            IMasterDataRepository masterDataRepository,
          IMapper mapper
          ) : base()
        {
            _masterDataRepository = masterDataRepository;
            _mapper = mapper;
        }

        public async Task<List<SubnetGroupDto>> GetSubnetGroups()
        {
             var subnetGroups = await _masterDataRepository.GetSubnetGroups();            

            return _mapper.Map<List<SubnetGroupDto>>(subnetGroups);
        }

        public async Task<List<SubnetMaskDto>> GetSubnetMasks()
        {
            var subnetMasks = await _masterDataRepository.GetSubnetMasks();

            var subnetMaskData = _mapper.Map<List<SubnetMaskDto>>(subnetMasks);

            foreach (SubnetMaskDto subnetMask in subnetMaskData)
            {
                subnetMask.DisplaySubnetMask = $"{subnetMask.NetMask}{subnetMask.CIDR}-{subnetMask.Hosts} Hosts";
            }

            return subnetMaskData;
        }

        public async Task<List<ServerTypeDto>> GetServerTypes()
        {
            var serverTypes = await _masterDataRepository.GetServerTypes();

            return _mapper.Map<List<ServerTypeDto>>(serverTypes);
        }
    }
}
