using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace movtrack8backend.Migrations
{
    /// <inheritdoc />
    public partial class changingpktypeandaddedindexonentitybase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Oeuvres",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Oeuvres_CreatedAt",
                table: "Oeuvres",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Oeuvres_UpdatedAt",
                table: "Oeuvres",
                column: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Oeuvres_CreatedAt",
                table: "Oeuvres");

            migrationBuilder.DropIndex(
                name: "IX_Oeuvres_UpdatedAt",
                table: "Oeuvres");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Oeuvres",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
