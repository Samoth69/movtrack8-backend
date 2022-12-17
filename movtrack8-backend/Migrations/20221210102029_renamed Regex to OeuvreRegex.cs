using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movtrack8backend.Migrations
{
    /// <inheritdoc />
    public partial class renamedRegextoOeuvreRegex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Regex",
                table: "Oeuvres",
                newName: "OeuvreRegex");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OeuvreRegex",
                table: "Oeuvres",
                newName: "Regex");
        }
    }
}
