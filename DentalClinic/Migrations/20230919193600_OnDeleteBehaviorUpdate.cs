using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteBehaviorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthProgresses_Employees_AdministeredById",
                table: "HealthProgresses");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthProgresses_Employees_AdministeredById",
                table: "HealthProgresses",
                column: "AdministeredById",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthProgresses_Employees_AdministeredById",
                table: "HealthProgresses");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthProgresses_Employees_AdministeredById",
                table: "HealthProgresses",
                column: "AdministeredById",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
