using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class CompanyLabPricesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BacterologyPrice",
                table: "CompanySettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChemistryPrice",
                table: "CompanySettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HematologyPrice",
                table: "CompanySettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MicroscopyPrice",
                table: "CompanySettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SerologyPrice",
                table: "CompanySettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoolExamPrice",
                table: "CompanySettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UrinalysisPrice",
                table: "CompanySettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompanyLabPrices",
                columns: table => new
                {
                    CompanyLabPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoolExamPrice = table.Column<int>(type: "int", nullable: false),
                    BacterologyPrice = table.Column<int>(type: "int", nullable: false),
                    MicroscopyPrice = table.Column<int>(type: "int", nullable: false),
                    UrinalysisPrice = table.Column<int>(type: "int", nullable: false),
                    HematologyPrice = table.Column<int>(type: "int", nullable: false),
                    ChemistryPrice = table.Column<int>(type: "int", nullable: false),
                    SerologyPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLabPrices", x => x.CompanyLabPriceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyLabPrices");

            migrationBuilder.DropColumn(
                name: "BacterologyPrice",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "ChemistryPrice",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "HematologyPrice",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "MicroscopyPrice",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "SerologyPrice",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "StoolExamPrice",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "UrinalysisPrice",
                table: "CompanySettings");
        }
    }
}
