using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAM_Repo.Migrations
{
    public partial class UpadateSubnetaccessmode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessMode",
                table: "SubnetIP",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessMode",
                table: "Subnet",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessMode",
                table: "SubnetIP");

            migrationBuilder.DropColumn(
                name: "AccessMode",
                table: "Subnet");
        }
    }
}
