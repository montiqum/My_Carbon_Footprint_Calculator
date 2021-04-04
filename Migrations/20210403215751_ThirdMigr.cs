using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCarbonFootprintCalculator.Migrations
{
    public partial class ThirdMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HH_Emm",
                table: "Footprint",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total_emm",
                table: "Footprint",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Travel_emm",
                table: "Footprint",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Waste_emm",
                table: "Footprint",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HH_Emm",
                table: "Footprint");

            migrationBuilder.DropColumn(
                name: "Total_emm",
                table: "Footprint");

            migrationBuilder.DropColumn(
                name: "Travel_emm",
                table: "Footprint");

            migrationBuilder.DropColumn(
                name: "Waste_emm",
                table: "Footprint");
        }
    }
}
