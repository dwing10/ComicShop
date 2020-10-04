using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicShop.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Comics",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Comics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherID);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherID", "PublisherName" },
                values: new object[] { 1, "Marvel Studios" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherID", "PublisherName" },
                values: new object[] { 2, "DC Comics" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherID", "PublisherName" },
                values: new object[] { 3, "Image Comics" });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 1,
                columns: new[] { "Publisher", "PublisherID" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 2,
                columns: new[] { "Publisher", "PublisherID" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 3,
                columns: new[] { "Publisher", "PublisherID" },
                values: new object[] { null, 3 });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 4,
                columns: new[] { "Publisher", "PublisherID" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 5,
                columns: new[] { "Publisher", "PublisherID" },
                values: new object[] { null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Comics_PublisherID",
                table: "Comics",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comics_Publishers_PublisherID",
                table: "Comics",
                column: "PublisherID",
                principalTable: "Publishers",
                principalColumn: "PublisherID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comics_Publishers_PublisherID",
                table: "Comics");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Comics_PublisherID",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Comics");

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Comics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 1,
                column: "Publisher",
                value: "DC");

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 2,
                column: "Publisher",
                value: "DC");

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 3,
                column: "Publisher",
                value: "Image Comics");

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 4,
                column: "Publisher",
                value: "Marvel");

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "ComicId",
                keyValue: 5,
                column: "Publisher",
                value: "Marvel");
        }
    }
}
