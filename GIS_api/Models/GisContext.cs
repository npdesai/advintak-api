using GIS_api.Models.Subnet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_api.Models
{
    public class GisContext: DbContext
    {
        public GisContext(DbContextOptions options) : base(options) { }
        public DbSet<Subnets> Subnets { get; set; }
        public DbSet<SubnetGroup> SubnetGroup { get; set; }
        public DbSet<SubnetMask> SubnetMask { get; set; }
    }
}
