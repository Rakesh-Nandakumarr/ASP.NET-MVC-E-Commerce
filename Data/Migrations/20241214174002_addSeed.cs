using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "Slug", "Status" },
                values: new object[,]
                {
                    { 1, "Description for Category 1", "Category 1", "category-1", true },
                    { 2, "Description for Category 2", "Category 2", "category-2", true },
                    { 3, "Description for Category 3", "Category 3", "category-3", true },
                    { 4, "Description for Category 4", "Category 4", "category-4", true },
                    { 5, "Description for Category 5", "Category 5", "category-5", true },
                    { 6, "Description for Category 6", "Category 6", "category-6", true },
                    { 7, "Description for Category 7", "Category 7", "category-7", true }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "Price", "Rating", "Slug", "Status", "Stock" },
                values: new object[,]
                {
                    { 1, "Brand 1", 1, "Description for Product 1-1", "Meta Description for Product 1-1", "keyword-1-1", "Meta Title for Product 1-1", "Product 1-1", 11.99m, 2, "product-1-1", true, 101 },
                    { 2, "Brand 2", 1, "Description for Product 1-2", "Meta Description for Product 1-2", "keyword-1-2", "Meta Title for Product 1-2", "Product 1-2", 12.99m, 3, "product-1-2", true, 102 },
                    { 3, "Brand 3", 1, "Description for Product 1-3", "Meta Description for Product 1-3", "keyword-1-3", "Meta Title for Product 1-3", "Product 1-3", 13.99m, 4, "product-1-3", true, 103 },
                    { 4, "Brand 4", 1, "Description for Product 1-4", "Meta Description for Product 1-4", "keyword-1-4", "Meta Title for Product 1-4", "Product 1-4", 14.99m, 5, "product-1-4", true, 104 },
                    { 5, "Brand 5", 1, "Description for Product 1-5", "Meta Description for Product 1-5", "keyword-1-5", "Meta Title for Product 1-5", "Product 1-5", 15.99m, 1, "product-1-5", true, 105 },
                    { 6, "Brand 6", 1, "Description for Product 1-6", "Meta Description for Product 1-6", "keyword-1-6", "Meta Title for Product 1-6", "Product 1-6", 16.99m, 2, "product-1-6", true, 106 },
                    { 7, "Brand 7", 1, "Description for Product 1-7", "Meta Description for Product 1-7", "keyword-1-7", "Meta Title for Product 1-7", "Product 1-7", 17.99m, 3, "product-1-7", true, 107 },
                    { 8, "Brand 8", 1, "Description for Product 1-8", "Meta Description for Product 1-8", "keyword-1-8", "Meta Title for Product 1-8", "Product 1-8", 18.99m, 4, "product-1-8", true, 108 },
                    { 9, "Brand 1", 2, "Description for Product 2-1", "Meta Description for Product 2-1", "keyword-2-1", "Meta Title for Product 2-1", "Product 2-1", 11.99m, 2, "product-2-1", true, 101 },
                    { 10, "Brand 2", 2, "Description for Product 2-2", "Meta Description for Product 2-2", "keyword-2-2", "Meta Title for Product 2-2", "Product 2-2", 12.99m, 3, "product-2-2", true, 102 },
                    { 11, "Brand 3", 2, "Description for Product 2-3", "Meta Description for Product 2-3", "keyword-2-3", "Meta Title for Product 2-3", "Product 2-3", 13.99m, 4, "product-2-3", true, 103 },
                    { 12, "Brand 4", 2, "Description for Product 2-4", "Meta Description for Product 2-4", "keyword-2-4", "Meta Title for Product 2-4", "Product 2-4", 14.99m, 5, "product-2-4", true, 104 },
                    { 13, "Brand 5", 2, "Description for Product 2-5", "Meta Description for Product 2-5", "keyword-2-5", "Meta Title for Product 2-5", "Product 2-5", 15.99m, 1, "product-2-5", true, 105 },
                    { 14, "Brand 6", 2, "Description for Product 2-6", "Meta Description for Product 2-6", "keyword-2-6", "Meta Title for Product 2-6", "Product 2-6", 16.99m, 2, "product-2-6", true, 106 },
                    { 15, "Brand 7", 2, "Description for Product 2-7", "Meta Description for Product 2-7", "keyword-2-7", "Meta Title for Product 2-7", "Product 2-7", 17.99m, 3, "product-2-7", true, 107 },
                    { 16, "Brand 8", 2, "Description for Product 2-8", "Meta Description for Product 2-8", "keyword-2-8", "Meta Title for Product 2-8", "Product 2-8", 18.99m, 4, "product-2-8", true, 108 },
                    { 17, "Brand 1", 3, "Description for Product 3-1", "Meta Description for Product 3-1", "keyword-3-1", "Meta Title for Product 3-1", "Product 3-1", 11.99m, 2, "product-3-1", true, 101 },
                    { 18, "Brand 2", 3, "Description for Product 3-2", "Meta Description for Product 3-2", "keyword-3-2", "Meta Title for Product 3-2", "Product 3-2", 12.99m, 3, "product-3-2", true, 102 },
                    { 19, "Brand 3", 3, "Description for Product 3-3", "Meta Description for Product 3-3", "keyword-3-3", "Meta Title for Product 3-3", "Product 3-3", 13.99m, 4, "product-3-3", true, 103 },
                    { 20, "Brand 4", 3, "Description for Product 3-4", "Meta Description for Product 3-4", "keyword-3-4", "Meta Title for Product 3-4", "Product 3-4", 14.99m, 5, "product-3-4", true, 104 },
                    { 21, "Brand 5", 3, "Description for Product 3-5", "Meta Description for Product 3-5", "keyword-3-5", "Meta Title for Product 3-5", "Product 3-5", 15.99m, 1, "product-3-5", true, 105 },
                    { 22, "Brand 6", 3, "Description for Product 3-6", "Meta Description for Product 3-6", "keyword-3-6", "Meta Title for Product 3-6", "Product 3-6", 16.99m, 2, "product-3-6", true, 106 },
                    { 23, "Brand 7", 3, "Description for Product 3-7", "Meta Description for Product 3-7", "keyword-3-7", "Meta Title for Product 3-7", "Product 3-7", 17.99m, 3, "product-3-7", true, 107 },
                    { 24, "Brand 8", 3, "Description for Product 3-8", "Meta Description for Product 3-8", "keyword-3-8", "Meta Title for Product 3-8", "Product 3-8", 18.99m, 4, "product-3-8", true, 108 },
                    { 25, "Brand 1", 4, "Description for Product 4-1", "Meta Description for Product 4-1", "keyword-4-1", "Meta Title for Product 4-1", "Product 4-1", 11.99m, 2, "product-4-1", true, 101 },
                    { 26, "Brand 2", 4, "Description for Product 4-2", "Meta Description for Product 4-2", "keyword-4-2", "Meta Title for Product 4-2", "Product 4-2", 12.99m, 3, "product-4-2", true, 102 },
                    { 27, "Brand 3", 4, "Description for Product 4-3", "Meta Description for Product 4-3", "keyword-4-3", "Meta Title for Product 4-3", "Product 4-3", 13.99m, 4, "product-4-3", true, 103 },
                    { 28, "Brand 4", 4, "Description for Product 4-4", "Meta Description for Product 4-4", "keyword-4-4", "Meta Title for Product 4-4", "Product 4-4", 14.99m, 5, "product-4-4", true, 104 },
                    { 29, "Brand 5", 4, "Description for Product 4-5", "Meta Description for Product 4-5", "keyword-4-5", "Meta Title for Product 4-5", "Product 4-5", 15.99m, 1, "product-4-5", true, 105 },
                    { 30, "Brand 6", 4, "Description for Product 4-6", "Meta Description for Product 4-6", "keyword-4-6", "Meta Title for Product 4-6", "Product 4-6", 16.99m, 2, "product-4-6", true, 106 },
                    { 31, "Brand 7", 4, "Description for Product 4-7", "Meta Description for Product 4-7", "keyword-4-7", "Meta Title for Product 4-7", "Product 4-7", 17.99m, 3, "product-4-7", true, 107 },
                    { 32, "Brand 8", 4, "Description for Product 4-8", "Meta Description for Product 4-8", "keyword-4-8", "Meta Title for Product 4-8", "Product 4-8", 18.99m, 4, "product-4-8", true, 108 },
                    { 33, "Brand 1", 5, "Description for Product 5-1", "Meta Description for Product 5-1", "keyword-5-1", "Meta Title for Product 5-1", "Product 5-1", 11.99m, 2, "product-5-1", true, 101 },
                    { 34, "Brand 2", 5, "Description for Product 5-2", "Meta Description for Product 5-2", "keyword-5-2", "Meta Title for Product 5-2", "Product 5-2", 12.99m, 3, "product-5-2", true, 102 },
                    { 35, "Brand 3", 5, "Description for Product 5-3", "Meta Description for Product 5-3", "keyword-5-3", "Meta Title for Product 5-3", "Product 5-3", 13.99m, 4, "product-5-3", true, 103 },
                    { 36, "Brand 4", 5, "Description for Product 5-4", "Meta Description for Product 5-4", "keyword-5-4", "Meta Title for Product 5-4", "Product 5-4", 14.99m, 5, "product-5-4", true, 104 },
                    { 37, "Brand 5", 5, "Description for Product 5-5", "Meta Description for Product 5-5", "keyword-5-5", "Meta Title for Product 5-5", "Product 5-5", 15.99m, 1, "product-5-5", true, 105 },
                    { 38, "Brand 6", 5, "Description for Product 5-6", "Meta Description for Product 5-6", "keyword-5-6", "Meta Title for Product 5-6", "Product 5-6", 16.99m, 2, "product-5-6", true, 106 },
                    { 39, "Brand 7", 5, "Description for Product 5-7", "Meta Description for Product 5-7", "keyword-5-7", "Meta Title for Product 5-7", "Product 5-7", 17.99m, 3, "product-5-7", true, 107 },
                    { 40, "Brand 8", 5, "Description for Product 5-8", "Meta Description for Product 5-8", "keyword-5-8", "Meta Title for Product 5-8", "Product 5-8", 18.99m, 4, "product-5-8", true, 108 },
                    { 41, "Brand 1", 6, "Description for Product 6-1", "Meta Description for Product 6-1", "keyword-6-1", "Meta Title for Product 6-1", "Product 6-1", 11.99m, 2, "product-6-1", true, 101 },
                    { 42, "Brand 2", 6, "Description for Product 6-2", "Meta Description for Product 6-2", "keyword-6-2", "Meta Title for Product 6-2", "Product 6-2", 12.99m, 3, "product-6-2", true, 102 },
                    { 43, "Brand 3", 6, "Description for Product 6-3", "Meta Description for Product 6-3", "keyword-6-3", "Meta Title for Product 6-3", "Product 6-3", 13.99m, 4, "product-6-3", true, 103 },
                    { 44, "Brand 4", 6, "Description for Product 6-4", "Meta Description for Product 6-4", "keyword-6-4", "Meta Title for Product 6-4", "Product 6-4", 14.99m, 5, "product-6-4", true, 104 },
                    { 45, "Brand 5", 6, "Description for Product 6-5", "Meta Description for Product 6-5", "keyword-6-5", "Meta Title for Product 6-5", "Product 6-5", 15.99m, 1, "product-6-5", true, 105 },
                    { 46, "Brand 6", 6, "Description for Product 6-6", "Meta Description for Product 6-6", "keyword-6-6", "Meta Title for Product 6-6", "Product 6-6", 16.99m, 2, "product-6-6", true, 106 },
                    { 47, "Brand 7", 6, "Description for Product 6-7", "Meta Description for Product 6-7", "keyword-6-7", "Meta Title for Product 6-7", "Product 6-7", 17.99m, 3, "product-6-7", true, 107 },
                    { 48, "Brand 8", 6, "Description for Product 6-8", "Meta Description for Product 6-8", "keyword-6-8", "Meta Title for Product 6-8", "Product 6-8", 18.99m, 4, "product-6-8", true, 108 },
                    { 49, "Brand 1", 7, "Description for Product 7-1", "Meta Description for Product 7-1", "keyword-7-1", "Meta Title for Product 7-1", "Product 7-1", 11.99m, 2, "product-7-1", true, 101 },
                    { 50, "Brand 2", 7, "Description for Product 7-2", "Meta Description for Product 7-2", "keyword-7-2", "Meta Title for Product 7-2", "Product 7-2", 12.99m, 3, "product-7-2", true, 102 },
                    { 51, "Brand 3", 7, "Description for Product 7-3", "Meta Description for Product 7-3", "keyword-7-3", "Meta Title for Product 7-3", "Product 7-3", 13.99m, 4, "product-7-3", true, 103 },
                    { 52, "Brand 4", 7, "Description for Product 7-4", "Meta Description for Product 7-4", "keyword-7-4", "Meta Title for Product 7-4", "Product 7-4", 14.99m, 5, "product-7-4", true, 104 },
                    { 53, "Brand 5", 7, "Description for Product 7-5", "Meta Description for Product 7-5", "keyword-7-5", "Meta Title for Product 7-5", "Product 7-5", 15.99m, 1, "product-7-5", true, 105 },
                    { 54, "Brand 6", 7, "Description for Product 7-6", "Meta Description for Product 7-6", "keyword-7-6", "Meta Title for Product 7-6", "Product 7-6", 16.99m, 2, "product-7-6", true, 106 },
                    { 55, "Brand 7", 7, "Description for Product 7-7", "Meta Description for Product 7-7", "keyword-7-7", "Meta Title for Product 7-7", "Product 7-7", 17.99m, 3, "product-7-7", true, 107 },
                    { 56, "Brand 8", 7, "Description for Product 7-8", "Meta Description for Product 7-8", "keyword-7-8", "Meta Title for Product 7-8", "Product 7-8", 18.99m, 4, "product-7-8", true, 108 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
