using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAM_Repo.Migrations
{
    public partial class SubnetMask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaskName",
                table: "SubnetMask",
                newName: "NetMask");

            migrationBuilder.RenameColumn(
                name: "MaskDescription",
                table: "SubnetMask",
                newName: "Class");

            migrationBuilder.AddColumn<int>(
                name: "Addresses",
                table: "SubnetMask",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CIDR",
                table: "SubnetMask",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hosts",
                table: "SubnetMask",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addresses",
                table: "SubnetMask");

            migrationBuilder.DropColumn(
                name: "CIDR",
                table: "SubnetMask");

            migrationBuilder.DropColumn(
                name: "Hosts",
                table: "SubnetMask");

            migrationBuilder.RenameColumn(
                name: "NetMask",
                table: "SubnetMask",
                newName: "MaskName");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "SubnetMask",
                newName: "MaskDescription");
        }
    }
}
