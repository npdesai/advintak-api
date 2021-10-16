using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common.DTOs.Master;
using IPAM_Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

            return _mapper.Map<List<SubnetMaskDto>>(subnetMasks);
        }
    }
}
