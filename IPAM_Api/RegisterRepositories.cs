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
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IIPV6SubnetRepository, IPV6SubnetRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IDomainRepository, DomainRepository>();
            services.AddScoped<IIPV6SubnetDetailRepository, IPV6SubnetDetailRepository>();
            services.AddScoped<ISubnetIPHistoryRepository, SubnetIPHistoryRepository>();
        }
    }
}
