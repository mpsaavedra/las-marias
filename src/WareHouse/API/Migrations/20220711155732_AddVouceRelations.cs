using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LasMarias.WareHouse.Migrations
{
    public partial class AddVouceRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsInitialPhoto",
                table: "ProductPhotos",
                newName: "DefaultPhoto");

            migrationBuilder.AddColumn<long>(
                name: "VouceId",
                table: "ProductMovements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Vouce",
                columns: table => new
                {
                    VouceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationUser = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    MovementType = table.Column<int>(type: "integer", nullable: false),
                    StandType = table.Column<int>(type: "integer", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    RowVersion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouce", x => x.VouceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovements_VouceId",
                table: "ProductMovements",
                column: "VouceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMovements_Vouce_VouceId",
                table: "ProductMovements",
                column: "VouceId",
                principalTable: "Vouce",
                principalColumn: "VouceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMovements_Vouce_VouceId",
                table: "ProductMovements");

            migrationBuilder.DropTable(
                name: "Vouce");

            migrationBuilder.DropIndex(
                name: "IX_ProductMovements_VouceId",
                table: "ProductMovements");

            migrationBuilder.DropColumn(
                name: "VouceId",
                table: "ProductMovements");

            migrationBuilder.RenameColumn(
                name: "DefaultPhoto",
                table: "ProductPhotos",
                newName: "IsInitialPhoto");
        }
    }
}
