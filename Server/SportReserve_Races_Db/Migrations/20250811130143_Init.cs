using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportReserve_Races_Db.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceTraces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfStart = table.Column<DateOnly>(type: "date", nullable: false),
                    HourOfStart = table.Column<TimeOnly>(type: "time", nullable: false),
                    DistanceKm = table.Column<double>(type: "float", nullable: false),
                    EntryFeeGBP = table.Column<double>(type: "float", nullable: true),
                    Slots = table.Column<int>(type: "int", nullable: true),
                    IsRegistrationOpen = table.Column<bool>(type: "bit", nullable: false),
                    ParentRaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceTraces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceTraces_Races_ParentRaceId",
                        column: x => x.ParentRaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceTraces_ParentRaceId",
                table: "RaceTraces",
                column: "ParentRaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceTraces");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
