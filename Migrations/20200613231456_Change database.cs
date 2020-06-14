using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApplying.Migrations
{
    public partial class Changedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appliers_Positions_PositionId",
                table: "Appliers");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "PreviousWorks");

            migrationBuilder.DropIndex(
                name: "IX_Appliers_PositionId",
                table: "Appliers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Appliers");

            migrationBuilder.AlterColumn<string>(
                name: "MicrosoftOfficeGrade",
                table: "Appliers",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Appliers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Appliers");

            migrationBuilder.AlterColumn<double>(
                name: "MicrosoftOfficeGrade",
                table: "Appliers",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Appliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplierId = table.Column<int>(type: "int", nullable: false),
                    ExperienceItem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Appliers_ApplierId",
                        column: x => x.ApplierId,
                        principalTable: "Appliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Pos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreviousWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplierId = table.Column<int>(type: "int", nullable: false),
                    PlaceAndLefReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviousWorks_Appliers_ApplierId",
                        column: x => x.ApplierId,
                        principalTable: "Appliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appliers_PositionId",
                table: "Appliers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ApplierId",
                table: "Experiences",
                column: "ApplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousWorks_ApplierId",
                table: "PreviousWorks",
                column: "ApplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appliers_Positions_PositionId",
                table: "Appliers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
