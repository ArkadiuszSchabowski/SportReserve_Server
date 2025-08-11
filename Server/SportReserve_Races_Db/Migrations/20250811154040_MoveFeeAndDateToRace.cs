using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportReserve_Races_Db.Migrations
{
    /// <inheritdoc />
    public partial class MoveFeeAndDateToRace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfStart",
                table: "RaceTraces");

            migrationBuilder.DropColumn(
                name: "EntryFeeGBP",
                table: "RaceTraces");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfStart",
                table: "Races",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "EntryFeeGBP",
                table: "Races",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfStart",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "EntryFeeGBP",
                table: "Races");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfStart",
                table: "RaceTraces",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<double>(
                name: "EntryFeeGBP",
                table: "RaceTraces",
                type: "float",
                nullable: true);
        }
    }
}
