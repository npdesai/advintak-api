using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GIS_api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubnetGroup",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    MaskId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaskName = table.Column<string>(type: "text", nullable: true),
                    MaskDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubnetMask", x => x.MaskId);
                });

            migrationBuilder.CreateTable(
                name: "Subnets",
                columns: table => new
                {
                    SubnetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubnetGroupId = table.Column<int>(type: "integer", nullable: false),
                    SubnetAddress = table.Column<string>(type: "text", nullable: true),
                    SubnetMaskId = table.Column<int>(type: "integer", nullable: false),
                    SubnetName = table.Column<string>(type: "text", nullable: true),
                    SubnetDescription = table.Column<string>(type: "text", nullable: true),
                    VlanName = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subnets", x => x.SubnetId);
                    table.ForeignKey(
                        name: "FK_Subnets_SubnetGroup_SubnetGroupId",
                        column: x => x.SubnetGroupId,
                        principalTable: "SubnetGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subnets_SubnetMask_SubnetMaskId",
                        column: x => x.SubnetMaskId,
                        principalTable: "SubnetMask",
                        principalColumn: "MaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subnets_SubnetGroupId",
                table: "Subnets",
                column: "SubnetGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Subnets_SubnetMaskId",
                table: "Subnets",
                column: "SubnetMaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subnets");

            migrationBuilder.DropTable(
                name: "SubnetGroup");

            migrationBuilder.DropTable(
                name: "SubnetMask");
        }
    }
}
