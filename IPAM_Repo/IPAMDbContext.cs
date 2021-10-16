using IPAM_Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=IPAM;Username=postgres;Password=postgress;Port=5432");
            }
        }
    }
}
