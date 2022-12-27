using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace movtrack8backend.Migrations
{
    /// <inheritdoc />
    public partial class addedTEpisodeandwebsite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TWebsite",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MainAddress = table.Column<string>(type: "text", nullable: false),
                    RssAddress = table.Column<string>(type: "text", nullable: true),
                    WebsiteRegex = table.Column<string>(type: "text", nullable: true),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    CloudFlareProtected = table.Column<bool>(type: "boolean", nullable: false),
                    LastSuccessfulFetch = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWebsite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEpisode",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OeuvreId = table.Column<long>(type: "bigint", nullable: false),
                    WebsiteId = table.Column<long>(type: "bigint", nullable: false),
                    JackettId = table.Column<int>(type: "integer", nullable: false),
                    PubDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    WebsiteLink = table.Column<string>(type: "text", nullable: false),
                    DlLink = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEpisode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TEpisode_Oeuvres_OeuvreId",
                        column: x => x.OeuvreId,
                        principalTable: "Oeuvres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TEpisode_TWebsite_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "TWebsite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TEpisode_CreatedAt",
                table: "TEpisode",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisode_JackettId",
                table: "TEpisode",
                column: "JackettId");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisode_OeuvreId",
                table: "TEpisode",
                column: "OeuvreId");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisode_Title",
                table: "TEpisode",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisode_UpdatedAt",
                table: "TEpisode",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisode_WebsiteId",
                table: "TEpisode",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_TWebsite_CreatedAt",
                table: "TWebsite",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TWebsite_UpdatedAt",
                table: "TWebsite",
                column: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TEpisode");

            migrationBuilder.DropTable(
                name: "TWebsite");
        }
    }
}
