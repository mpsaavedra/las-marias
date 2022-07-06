using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LasMarias.WareHouse.Migrations
{
    public partial class FixTypingErrorInProductDescriptionMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decription",
                table: "Products",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Decription");
        }
    }
}
