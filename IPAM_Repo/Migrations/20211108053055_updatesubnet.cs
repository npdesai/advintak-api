using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAM_Repo.Migrations
{
    public partial class updatesubnet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Alert",
                table: "Subnet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Critical",
                table: "Subnet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Subnet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Warning",
                table: "Subnet",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alert",
                table: "Subnet");

            migrationBuilder.DropColumn(
                name: "Critical",
                table: "Subnet");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Subnet");

            migrationBuilder.DropColumn(
                name: "Warning",
                table: "Subnet");
        }
    }
}
