using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LasMarias.WareHouse.Migrations
{
    public partial class AttributeMeasureUnitIdSetOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_MeasureUnits_MeasureUnitId",
                table: "Attributes");

            migrationBuilder.AlterColumn<long>(
                name: "MeasureUnitId",
                table: "Attributes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_MeasureUnits_MeasureUnitId",
                table: "Attributes",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "MeasureUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_MeasureUnits_MeasureUnitId",
                table: "Attributes");

            migrationBuilder.AlterColumn<long>(
                name: "MeasureUnitId",
                table: "Attributes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_MeasureUnits_MeasureUnitId",
                table: "Attributes",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "MeasureUnitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
