using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Common
{
    public class AppSettingsConfig
    {
        public string SubnetMaskMasterDataFilePath { get; set; }
        public string ServerTypeMasterDataFilePath { get; set; }
        public string DefaultGroupMasterDataFilePath { get; set; }
        public string ReservedDay { get; set; }
    }
}
