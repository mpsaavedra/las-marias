﻿// <auto-generated />
using System;
using LasMarias.WareHouse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LasMarias.WareHouse.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220705142128_AddBrandsEntity")]
    partial class AddBrandsEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AttributeProduct", b =>
                {
                    b.Property<long>("AttributesAttributeId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductsProductId")
                        .HasColumnType("bigint");

                    b.HasKey("AttributesAttributeId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("AttributeProduct");
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<long>("CategoriesCategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductsProductId")
                        .HasColumnType("bigint");

                    b.HasKey("CategoriesCategoryId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Attribute", b =>
                {
                    b.Property<long>("AttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("AttributeId"));

                    b.Property<long>("AttributeNameId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Enable")
                        .HasColumnType("boolean");

                    b.Property<long?>("MeasureUnitId")
                        .HasColumnType("bigint");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AttributeId");

                    b.HasIndex("AttributeNameId");

                    b.HasIndex("MeasureUnitId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.AttributeName", b =>
                {
                    b.Property<long>("AttributeNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("AttributeNameId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("Enable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("AttributeNameId");

                    b.HasIndex("Name");

                    b.ToTable("AttributeNames");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Brand", b =>
                {
                    b.Property<long>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("BrandId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("Enable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CategoryId"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("Enable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ParentCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.MeasureUnit", b =>
                {
                    b.Property<long>("MeasureUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("MeasureUnitId"));

                    b.Property<int>("Cast")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("Enable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("MeasureUnitId");

                    b.ToTable("MeasureUnits");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Movement", b =>
                {
                    b.Property<long>("MovementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("MovementId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("MovementType")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StandType")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("VendorId")
                        .HasColumnType("bigint");

                    b.HasKey("MovementId");

                    b.HasIndex("VendorId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.PriceHistory", b =>
                {
                    b.Property<long>("PriceHistoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("OldPrice")
                        .HasColumnType("numeric");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PriceHistoryId");

                    b.ToTable("PriceHistories");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ProductId"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Decription")
                        .HasColumnType("text");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<long?>("MeasureUnitId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("ReOrderLevel")
                        .HasColumnType("numeric");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductId");

                    b.HasIndex("MeasureUnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.ProductBrand", b =>
                {
                    b.Property<long>("ProductBrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ProductBrandId"));

                    b.Property<long>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductBrandId");

                    b.HasIndex("BrandId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductBrand");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.ProductMovement", b =>
                {
                    b.Property<long>("ProductMovementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ProductMovementId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<long>("MovementId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductMovementId");

                    b.HasIndex("MovementId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductMovements");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.ProductPhoto", b =>
                {
                    b.Property<long>("ProductPhotoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("DesignColor")
                        .HasColumnType("text");

                    b.Property<bool>("IsInitialPhoto")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductPhotoId");

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Vendor", b =>
                {
                    b.Property<long>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("VendorId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Enable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("VendorId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.VendorBrand", b =>
                {
                    b.Property<long>("VendorBrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("VendorBrandId"));

                    b.Property<long>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("VendorId")
                        .HasColumnType("bigint");

                    b.HasKey("VendorBrandId");

                    b.HasIndex("BrandId");

                    b.HasIndex("VendorId");

                    b.ToTable("VendorBrand");
                });

            modelBuilder.Entity("AttributeProduct", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.Attribute", null)
                        .WithMany()
                        .HasForeignKey("AttributesAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LasMarias.WareHouse.Domain.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LasMarias.WareHouse.Domain.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Attribute", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.AttributeName", "AttributeName")
                        .WithMany("Attributes")
                        .HasForeignKey("AttributeNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LasMarias.WareHouse.Domain.Models.MeasureUnit", "MeasureUnit")
                        .WithMany()
                        .HasForeignKey("MeasureUnitId");

                    b.Navigation("AttributeName");

                    b.Navigation("MeasureUnit");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Category", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Movement", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.Vendor", "Vendor")
                        .WithMany("Movements")
                        .HasForeignKey("VendorId");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.PriceHistory", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.Product", "Product")
                        .WithMany("PriceHistories")
                        .HasForeignKey("PriceHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Product", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.MeasureUnit", "MeasureUnit")
                        .WithMany("Products")
                        .HasForeignKey("MeasureUnitId");

                    b.Navigation("MeasureUnit");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.ProductBrand", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.Brand", "Brand")
                        .WithMany("ProductBrands")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LasMarias.WareHouse.Domain.Models.Product", "Product")
                        .WithMany("ProductBrands")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.ProductMovement", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.Movement", "Movement")
                        .WithMany("ProductMovements")
                        .HasForeignKey("MovementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LasMarias.WareHouse.Domain.Models.Product", "Product")
                        .WithMany("ProductMovements")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movement");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.ProductPhoto", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.Product", "Product")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("ProductPhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.VendorBrand", b =>
                {
                    b.HasOne("LasMarias.WareHouse.Domain.Models.Brand", "Brand")
                        .WithMany("VendorBrands")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LasMarias.WareHouse.Domain.Models.Vendor", "Vendor")
                        .WithMany("VendorBrands")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.AttributeName", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Brand", b =>
                {
                    b.Navigation("ProductBrands");

                    b.Navigation("VendorBrands");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Category", b =>
                {
                    b.Navigation("ChildCategories");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.MeasureUnit", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Movement", b =>
                {
                    b.Navigation("ProductMovements");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Product", b =>
                {
                    b.Navigation("PriceHistories");

                    b.Navigation("ProductBrands");

                    b.Navigation("ProductMovements");

                    b.Navigation("ProductPhotos");
                });

            modelBuilder.Entity("LasMarias.WareHouse.Domain.Models.Vendor", b =>
                {
                    b.Navigation("Movements");

                    b.Navigation("VendorBrands");
                });
#pragma warning restore 612, 618
        }
    }
}
