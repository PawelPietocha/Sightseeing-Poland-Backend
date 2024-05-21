using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SightseeingInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MountainsRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainsRanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voivodeships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voivodeships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mountains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    VoivodeshipId = table.Column<int>(type: "INTEGER", nullable: false),
                    MountainsRangeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mountains_MountainsRanges_MountainsRangeId",
                        column: x => x.MountainsRangeId,
                        principalTable: "MountainsRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mountains_Voivodeships_VoivodeshipId",
                        column: x => x.VoivodeshipId,
                        principalTable: "Voivodeships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mountains_MountainsRangeId",
                table: "Mountains",
                column: "MountainsRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mountains_VoivodeshipId",
                table: "Mountains",
                column: "VoivodeshipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mountains");

            migrationBuilder.DropTable(
                name: "MountainsRanges");

            migrationBuilder.DropTable(
                name: "Voivodeships");
        }
    }
}
