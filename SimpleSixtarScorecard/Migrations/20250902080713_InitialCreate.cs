using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleSixtarScorecard.Migrations;

/// <inheritdoc />
public sealed partial class InitialCreate : Migration {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder) {
        migrationBuilder.CreateTable(
            name: "ReleasesEtag",
            columns: table => new {
                etag = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_ReleasesEtag", x => x.etag));

        migrationBuilder.CreateTable(
            name: "Result",
            columns: table => new {
                song_id = table.Column<string>(type: "TEXT", nullable: false),
                mode = table.Column<string>(type: "TEXT", nullable: false),
                difficulty = table.Column<string>(type: "TEXT", nullable: false),
                score = table.Column<int>(type: "INTEGER", nullable: false),
                full_combo = table.Column<bool>(type: "INTEGER", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Result", x => new { x.song_id, x.mode, x.difficulty }));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder) {
        migrationBuilder.DropTable(name: "ReleasesEtag");
        migrationBuilder.DropTable(name: "Result");
    }
}
