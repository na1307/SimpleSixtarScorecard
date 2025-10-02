using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleSixtarScorecard.Migrations;

/// <inheritdoc />
public sealed partial class ResultsTableName : Migration {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder) {
        migrationBuilder.DropPrimaryKey(
            name: "PK_Result",
            table: "Result");

        migrationBuilder.RenameTable(
            name: "Result",
            newName: "Results");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Results",
            table: "Results",
            columns: ["SongId", "Mode", "Difficulty"]);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder) {
        migrationBuilder.DropPrimaryKey(
            name: "PK_Results",
            table: "Results");

        migrationBuilder.RenameTable(
            name: "Results",
            newName: "Result");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Result",
            table: "Result",
            columns: ["SongId", "Mode", "Difficulty"]);
    }
}
