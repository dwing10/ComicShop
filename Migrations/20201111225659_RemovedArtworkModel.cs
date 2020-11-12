using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicShop.Migrations
{
    public partial class RemovedArtworkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artworks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    ArtworkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.ArtworkID);
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "ArtworkID", "Artist", "Image", "ImageFilePath", "Title" },
                values: new object[] { -1, "pixelartlibrary", null, "~/images/spiderman.jpg", "Spidy" });
        }
    }
}
