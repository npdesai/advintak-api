using IPAM_Api.Services;
using IPAM_Api.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IPAM_Api
{
    public static class RegisterServices
    {
        public static void RegisterIPAMServices(this IServiceCollection services)
        {
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<ISubnetService, SubnetService>();
            services.AddScoped<ITreeService, TreeService>();
            services.AddScoped<IIPV6SubnetService, IPV6SubnetService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IDomainService, DomainService>();
        }
    }
}
