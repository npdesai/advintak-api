using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAM_Repo.Migrations
{
    public partial class SubnetIpHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubnetIPHistory",
                columns: table => new
                {
                    SubnetIPHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubnetIPId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubnetId = table.Column<Guid>(type: "uuid", nullable: false),
                    IPAddress = table.Column<string>(type: "text", nullable: true),
                    DetectedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DNSName = table.Column<string>(type: "text", nullable: true),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    SysDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubnetIPHistory", x => x.SubnetIPHistoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubnetIPHistory");
        }
    }
}
