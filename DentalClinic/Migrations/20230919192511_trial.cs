using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class trial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdministeredById",
                table: "HealthProgresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HealthProgresses_AdministeredById",
                table: "HealthProgresses",
                column: "AdministeredById");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthProgresses_Employees_AdministeredById",
                table: "HealthProgresses",
                column: "AdministeredById",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthProgresses_Employees_AdministeredById",
                table: "HealthProgresses");

            migrationBuilder.DropIndex(
                name: "IX_HealthProgresses_AdministeredById",
                table: "HealthProgresses");

            migrationBuilder.DropColumn(
                name: "AdministeredById",
                table: "HealthProgresses");
        }
    }
}
