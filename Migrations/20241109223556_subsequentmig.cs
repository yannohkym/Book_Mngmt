using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book_Management.Migrations
{
    /// <inheritdoc />
    public partial class subsequentmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cartitem",
                columns: new[] { "CartId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "swahili Novels", "swahili Novels only" },
                    { 2, "Religion books", "Religion books and  buddism" },
                    { 3, "Business related", "Business related books and artricles" },
                    { 4, "Technology ", "Technology and   Cloud " },
                    { 5, "Space and Austronomy", "Space and Austronomy" },
                    { 6, "English  and  Foreign  Languages ", "English  and  Foreign  Languages" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CartId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Kirinyaga  Kamau", 1, 400.0, "Romeo and  Juliet" },
                    { 2, "Abdi Hakim", 1, 410.0, " Kidagaa Kimemwozea" },
                    { 3, "Jane  Atieno", 3, 420.0, "How to thrive in business" },
                    { 4, "Pascal Kazungu", 2, 430.0, "Taste Jesus" },
                    { 5, "Jane  Atieno", 3, 420.0, "Good to great" },
                    { 6, "Jane  Atieno", 2, 420.0, "Great is great" },
                    { 7, "Jane  Atieno", 3, 420.0, "Entreprenuership" },
                    { 8, "Jane  Atieno", 4, 420.0, "Java" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cartitem",
                keyColumn: "CartId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cartitem",
                keyColumn: "CartId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cartitem",
                keyColumn: "CartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cartitem",
                keyColumn: "CartId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cartitem",
                keyColumn: "CartId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cartitem",
                keyColumn: "CartId",
                keyValue: 4);
        }
    }
}
