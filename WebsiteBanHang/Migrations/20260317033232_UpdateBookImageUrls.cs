using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteBanHang.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/71X8k8-A-hL._AC_UF1000,1000_QL80_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/81S6-n-8K5L._AC_UF1000,1000_QL80_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://product.hstatic.net/200000343865/product/100_072df29c782b4923bd09f90be0543f30.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/dac-nhan-tam.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/luoc-su-thoi-gian.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/conan-100.jpg");
        }
    }
}
