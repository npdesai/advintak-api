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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=IPAM;Username=postgres;Password=sa123;Port=5432");
            }
        }
    }
}
