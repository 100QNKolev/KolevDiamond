using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolevDiamond.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedImagePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bd178f7-da47-412d-8d0e-f9e35130b99d", "AQAAAAIAAYagAAAAEOg8TO0RGCk32GfV+u2qLDYGJ/uygqcdZIoq/yrm+7XP1+fmgvjWrzcR714N5IEI4w==", "ab875002-6698-4ad7-962e-fa884b9a93d9" });

            migrationBuilder.UpdateData(
                table: "InvestmentCoins",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "https://img.tavex.bg/v7/_product_catalog_/1-oz-canadian-maple-leaf-silver-coin/canadian_maple_leaf_1oz_silver_coin_reverse.jpg?height=960&width=960&func=cropfit");

            migrationBuilder.UpdateData(
                table: "InvestmentDiamonds",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "https://www.aura.diamonds/skin/images/shape_pages/emerald/emerald.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50d6a46c-509a-4475-acac-8dc98a0d6580", "AQAAAAIAAYagAAAAEOf9x4e/wieOkLhwXaB3K0AD634/yK1hiixaZVzCvxe/01ozOuNNXTsnRCGPUTI93Q==", "4825edaf-0d26-4095-be0b-b913cedb0430" });

            migrationBuilder.UpdateData(
                table: "InvestmentCoins",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "https://media.tavid.ee/v7/_product_catalog_/1-oz-canadian-maple-leaf-silver-coin/canadian_maple_leaf_1oz_silver_coin_reverse.jpg?height=960&width=960&func=cropfit");

            migrationBuilder.UpdateData(
                table: "InvestmentDiamonds",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "https://www.capediamonds.co.za/wp-content/uploads/2020/09/Emerald-Cut-Diamonds-Cape-Diamonds-Cape-Town-South-Africa.jpg");
        }
    }
}
