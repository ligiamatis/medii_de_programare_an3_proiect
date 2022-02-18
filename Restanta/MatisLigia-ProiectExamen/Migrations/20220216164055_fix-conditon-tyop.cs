using Microsoft.EntityFrameworkCore.Migrations;

namespace MatisLigia_ProiectExamen.Migrations
{
    public partial class fixconditontyop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCondition_Condition_ConditionID",
                table: "CarCondition");

            migrationBuilder.DropColumn(
                name: "ConditonID",
                table: "CarCondition");

            migrationBuilder.AlterColumn<int>(
                name: "ConditionID",
                table: "CarCondition",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarCondition_Condition_ConditionID",
                table: "CarCondition",
                column: "ConditionID",
                principalTable: "Condition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCondition_Condition_ConditionID",
                table: "CarCondition");

            migrationBuilder.AlterColumn<int>(
                name: "ConditionID",
                table: "CarCondition",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ConditonID",
                table: "CarCondition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CarCondition_Condition_ConditionID",
                table: "CarCondition",
                column: "ConditionID",
                principalTable: "Condition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
