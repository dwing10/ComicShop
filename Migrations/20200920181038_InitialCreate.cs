using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comics",
                columns: table => new
                {
                    ComicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Publisher = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comics", x => x.ComicId);
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "ComicId", "Publisher", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "DC", 5, "Batman #608", 2019 },
                    { 2, "DC", 5, "Superman Vs. Darkseid", 2015 },
                    { 3, "Image Comics", 5, "Spawn #306", 2020 },
                    { 4, "Marvel", 3, "The Tomb of Dracula", 1973 },
                    { 5, "Marvel", 4, "True Believers #1 - Venom Carnage", 2019 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comics");
        }
    }
}
