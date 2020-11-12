using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicShop.Migrations
{
    public partial class UpdatedArtworkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Artworks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Artworks");
        }
    }
}
