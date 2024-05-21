using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Sightseeing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MountainToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfVisit = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TripTimeMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    TripTimeHours = table.Column<int>(type: "INTEGER", nullable: false),
                    StartPlace = table.Column<string>(type: "TEXT", nullable: true),
                    EndPlace = table.Column<string>(type: "TEXT", nullable: true),
                    TripLenghtInKm = table.Column<int>(type: "INTEGER", nullable: false),
                    ElevationGainInMeters = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MountainId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainToUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MountainToUsers_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MountainToUsers_MountainId",
                table: "MountainToUsers",
                column: "MountainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MountainToUsers");
        }
    }
}
