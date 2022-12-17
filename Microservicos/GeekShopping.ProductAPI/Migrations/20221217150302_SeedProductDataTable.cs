using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
    public partial class SeedProductDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 2L, "Category2", "Description2", "https://www.google.com/2", "Name2", 20m },
                    { 3L, "Category3", "Description3", "https://www.google.com/3", "Name3", 30m },
                    { 4L, "Category4", "Description4", "https://www.google.com/4", "Name4", 40m },
                    { 5L, "Category5", "Description5", "https://www.google.com/5", "Name5", 50m },
                    { 6L, "Category6", "Description6", "https://www.google.com/6", "Name6", 60m },
                    { 7L, "Category7", "Description7", "https://www.google.com/7", "Name7", 70m },
                    { 8L, "Category8", "Description8", "https://www.google.com/8", "Name8", 80m },
                    { 9L, "Category9", "Description9", "https://www.google.com/9", "Name9", 90m },
                    { 10L, "Category10", "Description10", "https://www.google.com/10", "Name10", 100m },
                    { 11L, "Category11", "Description11", "https://www.google.com/11", "Name11", 110m },
                    { 12L, "Category12", "Description12", "https://www.google.com/12", "Name12", 120m },
                    { 13L, "Category13", "Description13", "https://www.google.com/13", "Name13", 130m },
                    { 14L, "Category14", "Description14", "https://www.google.com/14", "Name14", 140m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 14L);
        }
    }
}
