using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RSEC.Data.Migrations
{
    public partial class AddItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartChargingTime = table.Column<DateTime>(nullable: false),
                    BusNumber = table.Column<string>(nullable: true),
                    EnergyConsumed = table.Column<double>(nullable: false),
                    ChargingTime = table.Column<long>(nullable: false),
                    ChargingPower = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raports");
        }
    }
}
