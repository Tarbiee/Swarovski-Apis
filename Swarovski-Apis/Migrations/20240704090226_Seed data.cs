using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swarovski_Apis.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Jewels",
                columns: new[] { "id", "description", "image", "material", "name", "price" },
                values: new object[,]
                {
                    { 1, "A beautiful diamond necklace made of 18k gold.", "https://jewelryexchange.com/wp-content/uploads/2022/02/NXX01-Z0002.jpg", "Gold", "Diamond Necklace", 1000 },
                    { 2, "Elegant sapphire earrings in white gold setting.", "https://www.levinsfinejewellery.co.uk/wp-content/uploads/2018/09/241000022.jpg", "White Gold", "Sapphire Earrings", 500 },
                    { 3, "A classic emerald ring set in platinum.", "https://static.austenblake.com/image/product_v2/clrn03028/rf0012580/detail/3d/ww/em1/0001.jpg", "Platinum", "Emerald Ring", 750 },
                    { 4, "A vibrant ruby bracelet with a sterling silver chain.", "https://www.gregoryjewellers.com.au/wp-content/uploads/2021/02/RGB006-308900-12-Bracelet-WG-B1.jpg", "Silver", "Ruby Bracelet", 350 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jewels",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jewels",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jewels",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jewels",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
