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
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace GIS_api.Services
{
    public class SubnetService : ISubnetService
    {
        private readonly IMapper _mapper;        
        private readonly GisContext _gisContext;
        
        [DllImport("IpHlpApi.dll", CharSet = CharSet.Ansi)]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        
        [DllImport("Ws2_32.dll", CharSet = CharSet.Ansi)]
        public static extern uint inet_addr(string cp);

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

            if (entity.SubnetGroupId == 0 && !string.IsNullOrEmpty(obj.SubnetGroupName))
            {
                SubnetGroup group = new SubnetGroup() { 
                  GroupName = obj.SubnetGroupName
                };

                _gisContext.SubnetGroup.Add(group);
                await _gisContext.SaveChangesAsync();
                entity.SubnetGroupId = group.GroupId;
            }
            else
            {
                throw new ValidationException("SubnetGroupName can't null");
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

        public async Task<IEnumerable<SubnetIpDetail>> GetSubnetDetail(string subnet)
        {
            List<SubnetIpDetail> SubnetIpList = new List<SubnetIpDetail>();
            string subnetmask = string.Join(".",subnet.Split(".")[0],subnet.Split(".")[1],subnet.Split(".")[2]);

            if (!string.IsNullOrEmpty(subnetmask))
            {
               for(int i=1; i <= 254; i++)
                {
                    SubnetIpDetail subnetIpDetail = new SubnetIpDetail() {
                        ipAddress = string.Join(".", subnetmask, i),
                        //macAddress = GetClientMAC(string.Join(".", subnetmask, i)),
                        ipDNS = GetIP(string.Join(".", subnetmask, i))
                    };

                    SubnetIpList.Add(subnetIpDetail);
                }
            }

            return SubnetIpList;
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

        public string GetIP(string strClientIP)
        {
            try
            {
                IPNetwork ipnetwork = IPNetwork.Parse(strClientIP);

                IPAddress strHostName = IPAddress.Parse(strClientIP);
                //strHostName = System.Net.Dns.GetHostName();

                IPHostEntry ipEntry = System.Net.Dns.GetHostByAddress(strHostName);

                IPAddress[] addr = ipEntry.AddressList;

                return addr[addr.Length - 1].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }         
        }

        private static string GetClientMAC(string strClientIP)
        {
            string mac_dest = "";
            try
            {
                Int32 ldest = (int)inet_addr(strClientIP);
                Int32 lhost = (int)inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("L?i " + err.Message);
            }
            return mac_dest;
        }
    }
}
