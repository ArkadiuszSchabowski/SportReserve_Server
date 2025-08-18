using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportReserve_Races_Db.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultPosterUrlValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PosterUrl",
                table: "Races",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "images/default_poster.png",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PosterUrl",
                table: "Races",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "images/default_poster.png");
        }
    }
}
