using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicShop.Migrations
{
    public partial class AddedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "Comics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WriterID",
                table: "Comics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    WriterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.WriterID);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "ArtistName" },
                values: new object[,]
                {
                    { 1, "Jim Lee" },
                    { 2, "Alex Ross" },
                    { 3, "Multiple" },
                    { 4, "Philip Tan" },
                    { 5, "Gene Colan" },
                    { 6, "Mark Bagley" }
                });

            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "WriterID", "WriterName" },
                values: new object[,]
                {
                    { 1, "Jeph Loeb" },
                    { 2, "John Byrne" },
                    { 3, "Multiple" },
                    { 4, "Todd McFarlane" },
                    { 5, "Stan Lee" },
                    { 6, "David Michelinie" }
                });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 1,
                columns: new[] { "ArtistID", "WriterID" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 2,
                columns: new[] { "ArtistID", "WriterID" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 3,
                columns: new[] { "ArtistID", "WriterID" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 4,
                columns: new[] { "ArtistID", "WriterID" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 5,
                columns: new[] { "ArtistID", "WriterID" },
                values: new object[] { 6, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_Comics_ArtistID",
                table: "Comics",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_Comics_WriterID",
                table: "Comics",
                column: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comics_Artists_ArtistID",
                table: "Comics",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comics_Writers_WriterID",
                table: "Comics",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comics_Artists_ArtistID",
                table: "Comics");

            migrationBuilder.DropForeignKey(
                name: "FK_Comics_Writers_WriterID",
                table: "Comics");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Comics_ArtistID",
                table: "Comics");

            migrationBuilder.DropIndex(
                name: "IX_Comics_WriterID",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "WriterID",
                table: "Comics");
        }
    }
}
