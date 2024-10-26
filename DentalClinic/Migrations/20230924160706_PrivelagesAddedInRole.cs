using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class PrivelagesAddedInRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanControlPayment",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanGenerateReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanMagEmploy",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanManageAppointment",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanManageMedicalRecord",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanManagePatient",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanManageSetting",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanManageUserPrivalage",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanControlPayment",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CanGenerateReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CanMagEmploy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CanManageAppointment",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CanManageMedicalRecord",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CanManagePatient",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CanManageSetting",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CanManageUserPrivalage",
                table: "Roles");
        }
    }
}
