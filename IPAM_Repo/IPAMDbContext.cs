using IPAM_Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace IPAM_Repo
{
    public class IPAMDbContext : DbContext
    {
        public IPAMDbContext()
        {
        }

        public IPAMDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Subnet> Subnet { get; set; }
        public DbSet<SubnetGroup> SubnetGroup { get; set; }
        public DbSet<SubnetMask> SubnetMask { get; set; }
        public DbSet<ServerType> ServerType { get; set; }
        public DbSet<SubnetIP> SubnetIP { get; set; }
        public DbSet<IPV6Subnet> IPV6Subnet { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<IPV6SubnetDetail> IPV6SubnetDetail { get; set; }
        public DbSet<SubnetIPHistory> SubnetIPHistory { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=IPAM;Username=postgres;Password=postgress;Port=5432");
            }
        }
    }
}
