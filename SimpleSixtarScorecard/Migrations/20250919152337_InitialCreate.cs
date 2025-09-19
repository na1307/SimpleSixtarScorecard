using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleSixtarScorecard.Migrations;

/// <inheritdoc />
public sealed partial class InitialCreate : Migration {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder) {
        migrationBuilder.CreateTable(
            name: "EtagSingle",
            columns: table => new {
                Etag = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_EtagSingle", x => x.Etag));

        migrationBuilder.CreateTable(
            name: "Result",
            columns: table => new {
                SongId = table.Column<string>(type: "TEXT", nullable: false),
                Mode = table.Column<string>(type: "TEXT", nullable: false),
                Difficulty = table.Column<string>(type: "TEXT", nullable: false),
                Score = table.Column<int>(type: "INTEGER", nullable: false),
                FullCombo = table.Column<bool>(type: "INTEGER", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Result", x => new { x.SongId, x.Mode, x.Difficulty }));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder) {
        migrationBuilder.DropTable(name: "EtagSingle");
        migrationBuilder.DropTable(name: "Result");
    }
}
