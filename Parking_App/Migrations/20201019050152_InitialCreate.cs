using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking_App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(maxLength: 100, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Start_date = table.Column<string>(maxLength: 50, nullable: true),
                    End_date = table.Column<string>(maxLength: 50, nullable: true),
                    Plate = table.Column<string>(maxLength: 20, nullable: true),
                    CarCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Section = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarParkings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: false),
                    ParkingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarParkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarParkings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarParkings_Parkings_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "Parkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarParkings_ParkingId",
                table: "CarParkings",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_CarParkings_CarId_ParkingId",
                table: "CarParkings",
                columns: new[] { "CarId", "ParkingId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarParkings");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Parkings");
        }
    }
}
