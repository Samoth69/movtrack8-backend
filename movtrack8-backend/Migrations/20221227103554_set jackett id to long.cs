using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movtrack8backend.Migrations
{
    /// <inheritdoc />
    public partial class setjackettidtolong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>("JackettId", "Episodes", type: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>("JackettId", "Episodes", type: "integer");
        }
    }
}
