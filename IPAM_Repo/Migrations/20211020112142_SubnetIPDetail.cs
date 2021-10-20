using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAM_Repo.Migrations
{
    public partial class SubnetIPDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AliasName",
                table: "SubnetIP",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetTag",
                table: "SubnetIP",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReservedStatus",
                table: "SubnetIP",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemLocation",
                table: "SubnetIP",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AliasName",
                table: "SubnetIP");

            migrationBuilder.DropColumn(
                name: "AssetTag",
                table: "SubnetIP");

            migrationBuilder.DropColumn(
                name: "ReservedStatus",
                table: "SubnetIP");

            migrationBuilder.DropColumn(
                name: "SystemLocation",
                table: "SubnetIP");
        }
    }
}
