using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class foriegnkeychagne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Employees_IssuedByID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_IssuedByID",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EmployeeId",
                table: "Payments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Employees_EmployeeId",
                table: "Payments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Employees_EmployeeId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_EmployeeId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Payments");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IssuedByID",
                table: "Payments",
                column: "IssuedByID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Employees_IssuedByID",
                table: "Payments",
                column: "IssuedByID",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
