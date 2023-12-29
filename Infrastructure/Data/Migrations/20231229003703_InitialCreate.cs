using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mountains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    Voivodeship = table.Column<string>(type: "TEXT", nullable: false),
                    MountainsRange = table.Column<string>(type: "TEXT", nullable: false),
                    Visited = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateOfVisit = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TripTimeInMinutes = table.Column<int>(type: "INTEGER", nullable: true),
                    StartPlace = table.Column<string>(type: "TEXT", nullable: true),
                    EndPlace = table.Column<string>(type: "TEXT", nullable: true),
                    TripLenghtInKm = table.Column<int>(type: "INTEGER", nullable: true),
                    ElevationGainInMeters = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountains", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mountains");
        }
    }
}
