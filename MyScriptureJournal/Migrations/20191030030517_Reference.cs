using Microsoft.EntityFrameworkCore.Migrations;

namespace MyScriptureJournal.Migrations
{
    public partial class Reference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chapter",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "Verse",
                table: "JournalEntry");

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "JournalEntry",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference",
                table: "JournalEntry");

            migrationBuilder.AddColumn<int>(
                name: "Chapter",
                table: "JournalEntry",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Verse",
                table: "JournalEntry",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
