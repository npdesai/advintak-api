using IPAM_Api.Services;
using IPAM_Api.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPAM_Api
{
    public static class RegisterServices
    {
        public static void RegisterIPAMServices(this IServiceCollection services)
        {
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<ISubnetService, SubnetService>();
            services.AddScoped<ITreeService, TreeService>();
        }
    }
}
