using IPAM_Common;
using IPAM_Repo.Models;
using System;
using System.IO;
using System.Linq;

namespace IPAM_Repo.Repositories
{
    public class SeederRepository
    {
        private readonly IPAMDbContext _dbContext;

        public SeederRepository(IPAMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Save Master Data
        /// </summary>
        public void SeedData()
        {
            SubnetMaskData();
            ServerTypeData();
        }

        /// <summary>
        /// Save SubnetMask Data
        /// </summary>
        private void SubnetMaskData()
        {
            var lines = File.ReadAllLines(MemCache.AppSettings.SubnetMaskMasterDataFilePath).Skip(1).Select(l => l.Split(","));
            var subnetMaskData = lines.Select(line => new SubnetMask
            {
                Class = line[0].Trim(),
                Addresses = Convert.ToInt32(line[1].Trim()),
                CIDR = line[2].Trim(),
                Hosts = Convert.ToInt32(line[3].Trim()),
                NetMask = line[4].Trim()
            }).Cast<SubnetMask>().ToList();

            subnetMaskData.ForEach(subnetMask =>
            {
                if (!_dbContext.SubnetMask.Any(b => b.Class == subnetMask.Class && b.Addresses == subnetMask.Addresses && b.CIDR == subnetMask.CIDR && b.Hosts == subnetMask.Hosts && b.NetMask == subnetMask.NetMask))
                {
                    _dbContext.SubnetMask.Add(subnetMask);
                }
            });

            _dbContext.SaveChanges();
        }


        /// <summary>
        /// Save ServerType Data
        /// </summary>
        private void ServerTypeData()
        {
            var lines = File.ReadAllLines(MemCache.AppSettings.ServerTypeMasterDataFilePath).Skip(1).Select(l => l.Split(","));
            var serverTypeData = lines.Select(line => new ServerType
            {
                Name = line[0].Trim()
            }).Cast<ServerType>().ToList();

            serverTypeData.ForEach(serverType =>
            {
                if (!_dbContext.ServerType.Any(b => b.Name == serverType.Name))
                {
                    _dbContext.ServerType.Add(serverType);
                }
            });

            _dbContext.SaveChanges();
        }
    }
}
