using Microsoft.EntityFrameworkCore.Migrations;

namespace Tone.LibraryManagement.Data.Migrations
{
    public partial class CoverPageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverPicture",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPicture",
                table: "Books");
        }
    }
}
