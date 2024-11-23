using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class isServiceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isBacterology",
                table: "LaboratoryRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isChemistry",
                table: "LaboratoryRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isHematology",
                table: "LaboratoryRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isMicroscopy",
                table: "LaboratoryRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isSerology",
                table: "LaboratoryRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isStoolExamination",
                table: "LaboratoryRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isUrinalyis",
                table: "LaboratoryRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBacterology",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "isChemistry",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "isHematology",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "isMicroscopy",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "isSerology",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "isStoolExamination",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "isUrinalyis",
                table: "LaboratoryRequests");
        }
    }
}
