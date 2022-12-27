using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movtrack8backend.Migrations
{
    /// <inheritdoc />
    public partial class addeddbsets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TEpisode_Oeuvres_OeuvreId",
                table: "TEpisode");

            migrationBuilder.DropForeignKey(
                name: "FK_TEpisode_TWebsite_WebsiteId",
                table: "TEpisode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TWebsite",
                table: "TWebsite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TEpisode",
                table: "TEpisode");

            migrationBuilder.RenameTable(
                name: "TWebsite",
                newName: "Websites");

            migrationBuilder.RenameTable(
                name: "TEpisode",
                newName: "Episodes");

            migrationBuilder.RenameIndex(
                name: "IX_TWebsite_UpdatedAt",
                table: "Websites",
                newName: "IX_Websites_UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_TWebsite_CreatedAt",
                table: "Websites",
                newName: "IX_Websites_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_TEpisode_WebsiteId",
                table: "Episodes",
                newName: "IX_Episodes_WebsiteId");

            migrationBuilder.RenameIndex(
                name: "IX_TEpisode_UpdatedAt",
                table: "Episodes",
                newName: "IX_Episodes_UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_TEpisode_Title",
                table: "Episodes",
                newName: "IX_Episodes_Title");

            migrationBuilder.RenameIndex(
                name: "IX_TEpisode_OeuvreId",
                table: "Episodes",
                newName: "IX_Episodes_OeuvreId");

            migrationBuilder.RenameIndex(
                name: "IX_TEpisode_JackettId",
                table: "Episodes",
                newName: "IX_Episodes_JackettId");

            migrationBuilder.RenameIndex(
                name: "IX_TEpisode_CreatedAt",
                table: "Episodes",
                newName: "IX_Episodes_CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Websites",
                table: "Websites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Oeuvres_OeuvreId",
                table: "Episodes",
                column: "OeuvreId",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Websites_WebsiteId",
                table: "Episodes",
                column: "WebsiteId",
                principalTable: "Websites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Oeuvres_OeuvreId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Websites_WebsiteId",
                table: "Episodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Websites",
                table: "Websites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes");

            migrationBuilder.RenameTable(
                name: "Websites",
                newName: "TWebsite");

            migrationBuilder.RenameTable(
                name: "Episodes",
                newName: "TEpisode");

            migrationBuilder.RenameIndex(
                name: "IX_Websites_UpdatedAt",
                table: "TWebsite",
                newName: "IX_TWebsite_UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Websites_CreatedAt",
                table: "TWebsite",
                newName: "IX_TWebsite_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_WebsiteId",
                table: "TEpisode",
                newName: "IX_TEpisode_WebsiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_UpdatedAt",
                table: "TEpisode",
                newName: "IX_TEpisode_UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_Title",
                table: "TEpisode",
                newName: "IX_TEpisode_Title");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_OeuvreId",
                table: "TEpisode",
                newName: "IX_TEpisode_OeuvreId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_JackettId",
                table: "TEpisode",
                newName: "IX_TEpisode_JackettId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_CreatedAt",
                table: "TEpisode",
                newName: "IX_TEpisode_CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TWebsite",
                table: "TWebsite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TEpisode",
                table: "TEpisode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TEpisode_Oeuvres_OeuvreId",
                table: "TEpisode",
                column: "OeuvreId",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TEpisode_TWebsite_WebsiteId",
                table: "TEpisode",
                column: "WebsiteId",
                principalTable: "TWebsite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
