using IPAM_Repo.Interfaces;
using IPAM_Repo.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api
{
    public static class RegisterRepositories
    {
        public static void RegisterIPAMRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMasterDataRepository, MasterDataRepository>();
            services.AddScoped<ISubnetRepository, SubnetRepository>();
        }
    }
}
