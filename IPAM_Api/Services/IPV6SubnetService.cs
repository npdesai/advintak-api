using AutoMapper;
using IPAM_Api.Services.Interfaces;
using IPAM_Common;
using IPAM_Common.DTOs.Subnet;
using IPAM_Repo.Interfaces;
using IPAM_Repo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace IPAM_Api.Services
{
    public class IPV6SubnetService : IIPV6SubnetService
    {
        private readonly IIPV6SubnetRepository _iPV6SubnetRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IIPV6SubnetDetailRepository _iPV6SubnetDetailRepository;

        public IPV6SubnetService(IIPV6SubnetRepository iPV6SubnetRepository,
                                 ICompanyRepository companyRepository,
                                 IMapper mapper,
                                 IIPV6SubnetDetailRepository iPV6SubnetDetailRepository) : base()
        {
            _iPV6SubnetRepository = iPV6SubnetRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
            _iPV6SubnetDetailRepository = iPV6SubnetDetailRepository;
        }

        public async Task<List<IPV6SubnetDto>> GetIPV6SubnetList()
        {
            return _mapper.Map<List<IPV6SubnetDto>>(await _iPV6SubnetRepository.GetList());
        }

        public async Task<List<IPV6SubnetDetailDto>> GetIPV6SubnetDetailList(Guid iPV6SubnetId)
        {
            return _mapper.Map<List<IPV6SubnetDetailDto>>(await _iPV6SubnetDetailRepository.GetList(iPV6SubnetId));
        }

        public async Task<Guid> AddIPV6Subnet(IPV6SubnetDto iPV6Subnet)
        {
            if (iPV6Subnet.CompanyId == null)
            {
                iPV6Subnet.CompanyId = await _companyRepository.Create(new Company
                {
                    Name = iPV6Subnet.CompanyName
                });
            }

            Guid ipv6SubnetId = await _iPV6SubnetRepository.Create(_mapper.Map<IPV6Subnet>(iPV6Subnet));

            if (ipv6SubnetId.ToString() != "00000000-0000-0000-0000-000000000000")
            {

                string strIn = string.Join("::/", iPV6Subnet.PrefixAddress, iPV6Subnet.PrefixLength); //"2405:0201:200c:91b8::/180";

                //Split the string in parts for address and prefix
                string strAddress = strIn.Substring(0, strIn.IndexOf('/'));
                string strPrefix = strIn.Substring(strIn.IndexOf('/') + 1);

                int iPrefix = Int32.Parse(strPrefix);
                IPAddress ipAddress = IPAddress.Parse(strAddress);

                //Convert the prefix length to a valid SubnetMask

                int iMaskLength = 32;

                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    iMaskLength = 128;
                }

                BitArray btArray = new BitArray(iMaskLength);
                for (int iC1 = 0; iC1 < iMaskLength; iC1++)
                {
                    //Index calculation is a bit strange, since you have to make your mind about byte order.
                    int iIndex = (int)((iMaskLength - iC1 - 1) / 8) * 8 + (iC1 % 8);

                    if (iC1 < (iMaskLength - iPrefix))
                    {
                        btArray.Set(iIndex, false);
                    }
                    else
                    {
                        btArray.Set(iIndex, true);
                    }
                }

                byte[] bMaskData = new byte[iMaskLength / 8];

                btArray.CopyTo(bMaskData, 0);

                //Create subnetmask
                SubnetmaskHelper smMask = new SubnetmaskHelper(bMaskData);

                //Get the IP range
                IPAddress ipaStart = IPAddressAnalysis.GetClasslessNetworkAddress(ipAddress, smMask);
                IPAddress ipaEnd = IPAddressAnalysis.GetClasslessBroadcastAddress(ipAddress, smMask);

                //Omit the following lines if your network range is large
                IPAddress[] ipaRange = IPAddressAnalysis.GetIPRange(ipaStart, ipaEnd);

                //Debug output
                foreach (IPAddress ipa in ipaRange)
                {
                    await _iPV6SubnetDetailRepository.Create(new IPV6SubnetDetail()
                    {
                        IPV6Address = ipa.ToString(),
                        Status = "Not Scanned",
                        IPV6SubnetId = ipv6SubnetId
                    });
                }
            }

            return ipv6SubnetId;
        }


        public async Task<IPV6SubnetDetailDto> UpdateIPV6SubnetDetail(IPV6SubnetDetailDto iPV6SubnetDetail)
        {
            IPV6SubnetDetail iPV6Detail = await _iPV6SubnetDetailRepository.Get(iPV6SubnetDetail.IPV6SubnetDetailId);
            if (iPV6Detail != null)
            {
                iPV6Detail.Status = iPV6SubnetDetail.Status;
                iPV6Detail.MacAddress = iPV6SubnetDetail.MacAddress;
                iPV6Detail.LastUpdatedTime = DateTime.Now;
                iPV6Detail.VendorName = iPV6SubnetDetail.VendorName;

                await _iPV6SubnetDetailRepository.UpdateIPV6Detail(iPV6Detail);
            }

            return _mapper.Map<IPV6SubnetDetailDto>(iPV6Detail);
        }
    }
}
