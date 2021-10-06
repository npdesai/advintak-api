using GIS_api.Services;
using GIS_api.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api
{
    public static class RegisterServices
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<ISubnetService, SubnetService>();
            services.AddScoped<IMasterService, MasterService>();
        }
    }
}
