using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LasMarias.WareHouse.Migrations
{
    public partial class AddBrandsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBrand_Brand_BrandId",
                table: "ProductBrand");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorBrand_Brand_BrandId",
                table: "VendorBrand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBrand_Brands_BrandId",
                table: "ProductBrand",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorBrand_Brands_BrandId",
                table: "VendorBrand",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBrand_Brands_BrandId",
                table: "ProductBrand");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorBrand_Brands_BrandId",
                table: "VendorBrand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBrand_Brand_BrandId",
                table: "ProductBrand",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorBrand_Brand_BrandId",
                table: "VendorBrand",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
