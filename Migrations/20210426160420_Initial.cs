using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCarbonFootprintCalculator.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grains = table.Column<int>(type: "int", nullable: false),
                    Meat = table.Column<int>(type: "int", nullable: false),
                    Vegetables = table.Column<int>(type: "int", nullable: false),
                    Fruits = table.Column<int>(type: "int", nullable: false),
                    Fish = table.Column<int>(type: "int", nullable: false),
                    Milk = table.Column<int>(type: "int", nullable: false),
                    Desserts = table.Column<int>(type: "int", nullable: false),
                    Fast_foods = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.DietId);
                });

            migrationBuilder.CreateTable(
                name: "Footprint",
                columns: table => new
                {
                    CFPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Travel_emm = table.Column<int>(type: "int", nullable: false),
                    HH_Emm = table.Column<int>(type: "int", nullable: false),
                    Waste_emm = table.Column<int>(type: "int", nullable: false),
                    Total_emm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footprint", x => x.CFPId);
                });

            migrationBuilder.CreateTable(
                name: "GenInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    AnnualIncome = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenInfo", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Energy_Usage = table.Column<int>(type: "int", nullable: false),
                    Energy_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Solar = table.Column<bool>(type: "bit", nullable: false),
                    Gas = table.Column<bool>(type: "bit", nullable: false),
                    Electric = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.HouseId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfVehicles = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Footprint");

            migrationBuilder.DropTable(
                name: "GenInfo");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
