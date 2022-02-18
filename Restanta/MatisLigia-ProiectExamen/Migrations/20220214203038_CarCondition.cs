using Microsoft.EntityFrameworkCore.Migrations;

namespace MatisLigia_ProiectExamen.Migrations
{
    public partial class CarCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarCondition",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(nullable: false),
                    ConditonID = table.Column<int>(nullable: false),
                    ConditionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCondition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarCondition_Condition_ConditionID",
                        column: x => x.ConditionID,
                        principalTable: "Condition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarCondition_Car_CarID",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_BrandID",
                table: "Car",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_CarCondition_ConditionID",
                table: "CarCondition",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_CarCondition_CarID",
                table: "CarCondition",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Brand_BrandID",
                table: "Car",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Brand_BrandID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "CarCondition");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropIndex(
                name: "IX_Car_BrandID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Car");
        }
    }
}
