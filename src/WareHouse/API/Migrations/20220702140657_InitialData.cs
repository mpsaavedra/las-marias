using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LasMarias.WareHouse.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeNames",
                columns: table => new
                {
                    AttributeNameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Enable = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeNames", x => x.AttributeNameId);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Enable = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Enable = table.Column<bool>(type: "boolean", nullable: false),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeasureUnits",
                columns: table => new
                {
                    MeasureUnitId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Cast = table.Column<int>(type: "integer", nullable: false),
                    Enable = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureUnits", x => x.MeasureUnitId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Enable = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    AttributeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Enable = table.Column<bool>(type: "boolean", nullable: false),
                    MeasureUnitId = table.Column<long>(type: "bigint", nullable: false),
                    AttributeNameId = table.Column<long>(type: "bigint", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_Attributes_AttributeNames_AttributeNameId",
                        column: x => x.AttributeNameId,
                        principalTable: "AttributeNames",
                        principalColumn: "AttributeNameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attributes_MeasureUnits_MeasureUnitId",
                        column: x => x.MeasureUnitId,
                        principalTable: "MeasureUnits",
                        principalColumn: "MeasureUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Decription = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    ReOrderLevel = table.Column<decimal>(type: "numeric", nullable: true),
                    MeasureUnitId = table.Column<long>(type: "bigint", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_MeasureUnits_MeasureUnitId",
                        column: x => x.MeasureUnitId,
                        principalTable: "MeasureUnits",
                        principalColumn: "MeasureUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    MovementId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    VendorId = table.Column<long>(type: "bigint", nullable: false),
                    StandType = table.Column<int>(type: "integer", nullable: false),
                    MovementType = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.MovementId);
                    table.ForeignKey(
                        name: "FK_Movements_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorBrand",
                columns: table => new
                {
                    VendorBrandId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VendorId = table.Column<long>(type: "bigint", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorBrand", x => x.VendorBrandId);
                    table.ForeignKey(
                        name: "FK_VendorBrand_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorBrand_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeProduct",
                columns: table => new
                {
                    AttributesAttributeId = table.Column<long>(type: "bigint", nullable: false),
                    ProductsProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeProduct", x => new { x.AttributesAttributeId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_AttributeProduct_Attributes_AttributesAttributeId",
                        column: x => x.AttributesAttributeId,
                        principalTable: "Attributes",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ProductsProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesCategoryId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceHistories",
                columns: table => new
                {
                    PriceHistoryId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    OldPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    NewPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistories", x => x.PriceHistoryId);
                    table.ForeignKey(
                        name: "FK_PriceHistories_Products_PriceHistoryId",
                        column: x => x.PriceHistoryId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrand",
                columns: table => new
                {
                    ProductBrandId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrand", x => x.ProductBrandId);
                    table.ForeignKey(
                        name: "FK_ProductBrand_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBrand_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhotos",
                columns: table => new
                {
                    ProductPhotoId = table.Column<long>(type: "bigint", nullable: false),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true),
                    DesignColor = table.Column<string>(type: "text", nullable: true),
                    IsInitialPhoto = table.Column<bool>(type: "boolean", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhotos", x => x.ProductPhotoId);
                    table.ForeignKey(
                        name: "FK_ProductPhotos_Products_ProductPhotoId",
                        column: x => x.ProductPhotoId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMovements",
                columns: table => new
                {
                    ProductMovementId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    MovementId = table.Column<long>(type: "bigint", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMovements", x => x.ProductMovementId);
                    table.ForeignKey(
                        name: "FK_ProductMovements_Movements_MovementId",
                        column: x => x.MovementId,
                        principalTable: "Movements",
                        principalColumn: "MovementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMovements_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeNames_Name",
                table: "AttributeNames",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeProduct_ProductsProductId",
                table: "AttributeProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_AttributeNameId",
                table: "Attributes",
                column: "AttributeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_MeasureUnitId",
                table: "Attributes",
                column: "MeasureUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsProductId",
                table: "CategoryProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_VendorId",
                table: "Movements",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrand_BrandId",
                table: "ProductBrand",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrand_ProductId",
                table: "ProductBrand",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovements_MovementId",
                table: "ProductMovements",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovements_ProductId",
                table: "ProductMovements",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MeasureUnitId",
                table: "Products",
                column: "MeasureUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorBrand_BrandId",
                table: "VendorBrand",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorBrand_VendorId",
                table: "VendorBrand",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeProduct");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "PriceHistories");

            migrationBuilder.DropTable(
                name: "ProductBrand");

            migrationBuilder.DropTable(
                name: "ProductMovements");

            migrationBuilder.DropTable(
                name: "ProductPhotos");

            migrationBuilder.DropTable(
                name: "VendorBrand");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "AttributeNames");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "MeasureUnits");
        }
    }
}
