using IPAM_Api.Services;
using IPAM_Api.Services.Interfaces;
using IPAM_Repo.Interfaces;
using IPAM_Repo.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IPAM_Api
{
    public static class RegisterRepositories
    {
        public static void RegisterIPAMRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMasterDataRepository, MasterDataRepository>();
            services.AddScoped<ISubnetRepository, SubnetRepository>();
            services.AddScoped<ISubnetGroupRepository, SubnetGroupRepository>();
            services.AddScoped<ISubnetIpRepository, SubnetIpRepository>();
        }
    }
}
