using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicShop.Migrations
{
    public partial class IntitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    ArtworkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Artist = table.Column<string>(nullable: false),
                    ImageFilePath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.ArtworkID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherID);
                });

            migrationBuilder.CreateTable(
                name: "Comics",
                columns: table => new
                {
                    ComicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    PublisherID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comics", x => x.ComicId);
                    table.ForeignKey(
                        name: "FK_Comics_Publishers_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publishers",
                        principalColumn: "PublisherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "ArtworkID", "Artist", "ImageFilePath", "Title" },
                values: new object[] { -1, "pixelartlibrary", "~/images/spiderman.jpg", "Spidy" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherID", "Address", "City", "Country", "Email", "Phone", "Zipcode", "PublisherName", "State" },
                values: new object[,]
                {
                    { 1, null, "New York", "US", "OnlineSupport@marvel.com.", null, "10001", "Marvel Studios", "NY" },
                    { 2, "4000 Warner Boulevard", "Burbank", "US", null, "818.954.4430", "91522", "DC Comics", "CA" },
                    { 3, null, "Portland", "US", null, null, "97035", "Image Comics", "OR" }
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "ComicId", "PublisherID", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 4, 1, 3, "The Tomb of Dracula", 1973 },
                    { 5, 1, 4, "True Believers #1 - Venom Carnage", 2019 },
                    { 1, 2, 5, "Batman #608", 2019 },
                    { 2, 2, 5, "Superman Vs. Darkseid", 2015 },
                    { 3, 3, 5, "Spawn #306", 2020 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comics_PublisherID",
                table: "Comics",
                column: "PublisherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artworks");

            migrationBuilder.DropTable(
                name: "Comics");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
