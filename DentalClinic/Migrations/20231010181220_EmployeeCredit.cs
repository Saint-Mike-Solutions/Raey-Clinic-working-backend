using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeCredit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssuedBy",
                table: "Credits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Credits_IssuedBy",
                table: "Credits",
                column: "IssuedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Employees_IssuedBy",
                table: "Credits",
                column: "IssuedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Employees_IssuedBy",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_IssuedBy",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "IssuedBy",
                table: "Credits");
        }
    }
}
