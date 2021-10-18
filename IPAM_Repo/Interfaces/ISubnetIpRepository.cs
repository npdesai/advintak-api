﻿using IPAM_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_Repo.Interfaces
{
    public interface ISubnetIpRepository
    {
        Task<Guid> Create(SubnetIP subnetIP);
    }
}