﻿// <auto-generated />
using System;
using LasMarias.PoS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LasMarias.PoS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220626174823_InitialMigrations")]
    partial class InitialMigrations
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

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Attribute", b =>
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

                    b.Property<Guid>("RowVersion")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AttributeId");

                    b.HasIndex("AttributeNameId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.AttributeName", b =>
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

                    b.Property<Guid>("RowVersion")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("AttributeNameId");

                    b.HasIndex("Name");

                    b.ToTable("AttributeNames");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CategoryId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("Enable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ParentCategoryId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("RowVersion")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ProductId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Decription")
                        .HasColumnType("text");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("RowVersion")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.ProductPhoto", b =>
                {
                    b.Property<long>("ProductPhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ProductPhotoId"));

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

                    b.Property<Guid>("RowVersion")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductPhotoId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Seat", b =>
                {
                    b.Property<long>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SeatId"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RowVersion")
                        .HasColumnType("uuid");

                    b.Property<int>("SeatType")
                        .HasColumnType("integer");

                    b.Property<long>("StandId")
                        .HasColumnType("bigint");

                    b.Property<long>("TableId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("SeatId");

                    b.HasIndex("Code");

                    b.HasIndex("StandId");

                    b.HasIndex("TableId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Stand", b =>
                {
                    b.Property<long>("StandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("StandId"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RowVersion")
                        .HasColumnType("uuid");

                    b.Property<int>("StandType")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("StandId");

                    b.ToTable("Stands");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Table", b =>
                {
                    b.Property<long>("TableId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOcuppied")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RowVersion")
                        .HasColumnType("uuid");

                    b.Property<long>("StandId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TableId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("AttributeProduct", b =>
                {
                    b.HasOne("LasMarias.PoS.Domain.Models.Attribute", null)
                        .WithMany()
                        .HasForeignKey("AttributesAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LasMarias.PoS.Domain.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("LasMarias.PoS.Domain.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LasMarias.PoS.Domain.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Attribute", b =>
                {
                    b.HasOne("LasMarias.PoS.Domain.Models.AttributeName", "AttributeName")
                        .WithMany("Attributes")
                        .HasForeignKey("AttributeNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeName");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Category", b =>
                {
                    b.HasOne("LasMarias.PoS.Domain.Models.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.ProductPhoto", b =>
                {
                    b.HasOne("LasMarias.PoS.Domain.Models.Product", "Product")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Seat", b =>
                {
                    b.HasOne("LasMarias.PoS.Domain.Models.Stand", "Stand")
                        .WithMany("Seats")
                        .HasForeignKey("StandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LasMarias.PoS.Domain.Models.Table", "Table")
                        .WithMany("Seats")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stand");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Table", b =>
                {
                    b.HasOne("LasMarias.PoS.Domain.Models.Stand", "Stand")
                        .WithMany("Tables")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stand");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.AttributeName", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Category", b =>
                {
                    b.Navigation("ChildCategories");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Product", b =>
                {
                    b.Navigation("ProductPhotos");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Stand", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("LasMarias.PoS.Domain.Models.Table", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}