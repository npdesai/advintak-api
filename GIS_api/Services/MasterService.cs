using AutoMapper;
using GIS_api.Models;
using GIS_api.Models.DTO.Master;
using GIS_api.Models.Subnet;
using GIS_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Services
{
    public class MasterService : IMasterService
    {

        private readonly IMapper _mapper;
        private readonly GisContext _gisContext;

        public MasterService(
          IMapper mapper,
          GisContext gisContext
          ) : base()
        {
            _mapper = mapper;
            _gisContext = gisContext;
        }


        public async Task<IEnumerable<SubnetGroupDto>> GetSubnetGroups()
        {
            IEnumerable<SubnetGroupDto> SubnetGroupList = _mapper.Map<IEnumerable<SubnetGroupDto>>(await _gisContext.SubnetGroup.ToListAsync());            

            return SubnetGroupList;
        }

        public async Task<IEnumerable<SubnetMaskDto>> GetSubnetMask()
        {
            IEnumerable<SubnetMaskDto> SubnetMaskList = _mapper.Map<IEnumerable<SubnetMaskDto>>(await _gisContext.SubnetMask.ToListAsync());

            return SubnetMaskList;
        }
    }
}
