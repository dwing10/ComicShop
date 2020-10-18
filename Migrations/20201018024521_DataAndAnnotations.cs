using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicShop.Migrations
{
    public partial class DataAndAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Publishers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Publishers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Publishers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Publishers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Publishers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "Publishers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Publishers",
                maxLength: 2,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherID",
                keyValue: 1,
                columns: new[] { "City", "Email", "State" },
                values: new object[] { "New York", "OnlineSupport@marvel.com.", "NY" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherID",
                keyValue: 2,
                columns: new[] { "Address", "City", "Phone", "State" },
                values: new object[] { "4000 Warner Boulevard", "Burbank", "818.954.4430", "CA" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublisherID",
                keyValue: 3,
                columns: new[] { "City", "State" },
                values: new object[] { "Portland", "OR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Publishers");
        }
    }
}
