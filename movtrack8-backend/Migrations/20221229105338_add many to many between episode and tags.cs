using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace movtrack8backend.Migrations
{
    /// <inheritdoc />
    public partial class addmanytomanybetweenepisodeandtags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    BackgroundColor = table.Column<string>(type: "text", nullable: false),
                    ForegroundColor = table.Column<string>(type: "text", nullable: false),
                    Regex = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEpisodeTTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EpisodeId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEpisodeTTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TEpisodeTTag_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TEpisodeTTag_TTag_TagId",
                        column: x => x.TagId,
                        principalTable: "TTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TEpisodeTTag_CreatedAt",
                table: "TEpisodeTTag",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisodeTTag_EpisodeId_TagId",
                table: "TEpisodeTTag",
                columns: new[] { "EpisodeId", "TagId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TEpisodeTTag_TagId",
                table: "TEpisodeTTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TEpisodeTTag_UpdatedAt",
                table: "TEpisodeTTag",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TTag_CreatedAt",
                table: "TTag",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TTag_UpdatedAt",
                table: "TTag",
                column: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TEpisodeTTag");

            migrationBuilder.DropTable(
                name: "TTag");
        }
    }
}
