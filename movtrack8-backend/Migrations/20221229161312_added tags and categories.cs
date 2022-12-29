using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace movtrack8backend.Migrations
{
    /// <inheritdoc />
    public partial class addedtagsandcategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TEpisodeTTag_TTag_TagId",
                table: "TEpisodeTTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TTag",
                table: "TTag");

            migrationBuilder.RenameTable(
                name: "TTag",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_TTag_UpdatedAt",
                table: "Tags",
                newName: "IX_Tags_UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_TTag_CreatedAt",
                table: "Tags",
                newName: "IX_Tags_CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WebsiteId = table.Column<long>(type: "bigint", nullable: false),
                    WebsiteSlug = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Show = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TEpisodeTCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EpisodeId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEpisodeTCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TEpisodeTCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TEpisodeTCategory_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedAt",
                table: "Categories",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedAt",
                table: "Categories",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_WebsiteId_WebsiteSlug",
                table: "Categories",
                columns: new[] { "WebsiteId", "WebsiteSlug" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_WebsiteSlug",
                table: "Categories",
                column: "WebsiteSlug");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisodeTCategory_CategoryId",
                table: "TEpisodeTCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisodeTCategory_CreatedAt",
                table: "TEpisodeTCategory",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisodeTCategory_EpisodeId",
                table: "TEpisodeTCategory",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisodeTCategory_UpdatedAt",
                table: "TEpisodeTCategory",
                column: "UpdatedAt");

            migrationBuilder.AddForeignKey(
                name: "FK_TEpisodeTTag_Tags_TagId",
                table: "TEpisodeTTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TEpisodeTTag_Tags_TagId",
                table: "TEpisodeTTag");

            migrationBuilder.DropTable(
                name: "TEpisodeTCategory");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "TTag");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_UpdatedAt",
                table: "TTag",
                newName: "IX_TTag_UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_CreatedAt",
                table: "TTag",
                newName: "IX_TTag_CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TTag",
                table: "TTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TEpisodeTTag_TTag_TagId",
                table: "TEpisodeTTag",
                column: "TagId",
                principalTable: "TTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
