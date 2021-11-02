using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAM_Repo.Migrations
{
    public partial class ipv6detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IPV6SubnetDetail",
                columns: table => new
                {
                    IPV6SubnetDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    IPV6SubnetId = table.Column<Guid>(type: "uuid", nullable: false),
                    IPV6Address = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    IpToDns = table.Column<string>(type: "text", nullable: true),
                    DnsToIp = table.Column<string>(type: "text", nullable: true),
                    DnsStatus = table.Column<string>(type: "text", nullable: true),
                    VendorName = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPV6SubnetDetail", x => x.IPV6SubnetDetailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPV6SubnetDetail");
        }
    }
}
