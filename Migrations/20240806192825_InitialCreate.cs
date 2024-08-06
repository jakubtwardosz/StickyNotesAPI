using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StickyNotesAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    Colors_Id = table.Column<string>(type: "TEXT", nullable: true),
                    Colors_ColorHeader = table.Column<string>(type: "TEXT", nullable: false),
                    Colors_ColorBody = table.Column<string>(type: "TEXT", nullable: false),
                    Colors_ColorText = table.Column<string>(type: "TEXT", nullable: false),
                    Position_X = table.Column<int>(type: "INTEGER", nullable: false),
                    Position_Y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
