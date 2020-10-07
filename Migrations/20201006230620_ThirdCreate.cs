using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicShop.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Comics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Comics",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
