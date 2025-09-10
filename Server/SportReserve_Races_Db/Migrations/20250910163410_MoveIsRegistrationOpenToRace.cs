using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportReserve_Races_Db.Migrations
{
    /// <inheritdoc />
    public partial class MoveIsRegistrationOpenToRace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistrationOpen",
                table: "RaceTraces");

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistrationOpen",
                table: "Races",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistrationOpen",
                table: "Races");

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistrationOpen",
                table: "RaceTraces",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
