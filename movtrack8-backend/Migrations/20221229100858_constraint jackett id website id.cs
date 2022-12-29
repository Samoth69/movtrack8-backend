using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movtrack8backend.Migrations
{
    /// <inheritdoc />
    public partial class constraintjackettidwebsiteid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Episodes_WebsiteId_JackettId",
                table: "Episodes",
                columns: new[] { "WebsiteId", "JackettId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Episodes_WebsiteId_JackettId",
                table: "Episodes");
        }
    }
}
