using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportReserveDatabase.Migrations
{
    /// <inheritdoc />
    public partial class UserPropertyIsMaleToGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                table: "Users",
                type: "bit",
                nullable: true);
        }
    }
}
