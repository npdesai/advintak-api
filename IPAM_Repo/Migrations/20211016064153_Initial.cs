using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAM_Repo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubnetGroup",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: true),
                    GroupAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubnetGroup", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "SubnetMask",
                columns: table => new
                {
                    MaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaskName = table.Column<string>(type: "text", nullable: true),
                    MaskDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubnetMask", x => x.MaskId);
                });

            migrationBuilder.CreateTable(
                name: "Subnet",
                columns: table => new
                {
                    SubnetId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubnetGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubnetAddress = table.Column<string>(type: "text", nullable: true),
                    SubnetMaskId = table.Column<Guid>(type: "uuid", nullable: false),                    
                    SubnetName = table.Column<string>(type: "text", nullable: true),
                    SubnetDescription = table.Column<string>(type: "text", nullable: true),
                    VlanName = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subnet", x => x.SubnetId);
                    table.ForeignKey(
                        name: "FK_Subnet_SubnetGroup_SubnetGroupId",
                        column: x => x.SubnetGroupId,
                        principalTable: "SubnetGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subnet_SubnetMask_SubnetMaskId",
                        column: x => x.SubnetMaskId,
                        principalTable: "SubnetMask",
                        principalColumn: "MaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subnet_SubnetGroupId",
                table: "Subnet",
                column: "SubnetGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Subnet_SubnetMaskId",
                table: "Subnet",
                column: "SubnetMaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subnet");

            migrationBuilder.DropTable(
                name: "SubnetGroup");

            migrationBuilder.DropTable(
                name: "SubnetMask");
        }
    }
}
