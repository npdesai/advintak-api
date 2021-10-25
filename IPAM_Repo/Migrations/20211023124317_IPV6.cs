using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAM_Repo.Migrations
{
    public partial class IPV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "IPV6Subnet",
                columns: table => new
                {
                    IPV6SubnetId = table.Column<Guid>(type: "uuid", nullable: false),
                    PrefixName = table.Column<string>(type: "text", nullable: true),
                    PrefixAddress = table.Column<string>(type: "text", nullable: true),
                    PrefixLength = table.Column<int>(type: "integer", nullable: false),
                    PrefixDescription = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPV6Subnet", x => x.IPV6SubnetId);
                    table.ForeignKey(
                        name: "FK_IPV6Subnet_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IPV6Subnet_CompanyId",
                table: "IPV6Subnet",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPV6Subnet");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
