using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPAM_Repo.Migrations
{
    public partial class addsubnetips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Subnet_SubnetMask_SubnetMaskMaskId",
            //    table: "Subnet");

            //migrationBuilder.DropIndex(
            //    name: "IX_Subnet_SubnetMaskMaskId",
            //    table: "Subnet");

            //migrationBuilder.DropColumn(
            //    name: "SubnetMaskMaskId",
            //    table: "Subnet");

            //migrationBuilder.AlterColumn<Guid>(
            //    name: "SubnetMaskId",
            //    table: "Subnet",
            //    type: "uuid",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "integer");

            migrationBuilder.CreateTable(
                name: "SubnetIP",
                columns: table => new
                {
                    SubnetIPId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubnetId = table.Column<Guid>(type: "uuid", nullable: false),
                    IPAddress = table.Column<string>(type: "text", nullable: true),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    DnsStatus = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    ConnectedSwitch = table.Column<string>(type: "text", nullable: true),
                    LastScan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubnetIP", x => x.SubnetIPId);
                    table.ForeignKey(
                        name: "FK_SubnetIP_Subnet_SubnetId",
                        column: x => x.SubnetId,
                        principalTable: "Subnet",
                        principalColumn: "SubnetId",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Subnet_SubnetMaskId",
            //    table: "Subnet",
            //    column: "SubnetMaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SubnetIP_SubnetId",
                table: "SubnetIP",
                column: "SubnetId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Subnet_SubnetMask_SubnetMaskId",
            //    table: "Subnet",
            //    column: "SubnetMaskId",
            //    principalTable: "SubnetMask",
            //    principalColumn: "MaskId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Subnet_SubnetMask_SubnetMaskId",
            //    table: "Subnet");

            migrationBuilder.DropTable(
                name: "SubnetIP");

            //migrationBuilder.DropIndex(
            //    name: "IX_Subnet_SubnetMaskId",
            //    table: "Subnet");

            //migrationBuilder.AlterColumn<int>(
            //    name: "SubnetMaskId",
            //    table: "Subnet",
            //    type: "integer",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uuid");

            //migrationBuilder.AddColumn<Guid>(
            //    name: "SubnetMaskMaskId",
            //    table: "Subnet",
            //    type: "uuid",
            //    nullable: false,
            //    defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            //migrationBuilder.CreateIndex(
            //    name: "IX_Subnet_SubnetMaskMaskId",
            //    table: "Subnet",
            //    column: "SubnetMaskMaskId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Subnet_SubnetMask_SubnetMaskMaskId",
            //    table: "Subnet",
            //    column: "SubnetMaskMaskId",
            //    principalTable: "SubnetMask",
            //    principalColumn: "MaskId",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
