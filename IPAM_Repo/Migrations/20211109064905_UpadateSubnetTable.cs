using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAM_Repo.Migrations
{
    public partial class UpadateSubnetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VlanId",
                table: "SubnetIP",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VlanName",
                table: "SubnetIP",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VlanId",
                table: "Subnet",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VlanId",
                table: "SubnetIP");

            migrationBuilder.DropColumn(
                name: "VlanName",
                table: "SubnetIP");

            migrationBuilder.DropColumn(
                name: "VlanId",
                table: "Subnet");
        }
    }
}
