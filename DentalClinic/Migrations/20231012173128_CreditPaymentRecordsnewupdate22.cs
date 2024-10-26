using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class CreditPaymentRecordsnewupdate22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssuedBy",
                table: "CreditPaymentRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CreditPaymentRecords_IssuedBy",
                table: "CreditPaymentRecords",
                column: "IssuedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditPaymentRecords_Employees_IssuedBy",
                table: "CreditPaymentRecords",
                column: "IssuedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditPaymentRecords_Employees_IssuedBy",
                table: "CreditPaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_CreditPaymentRecords_IssuedBy",
                table: "CreditPaymentRecords");

            migrationBuilder.DropColumn(
                name: "IssuedBy",
                table: "CreditPaymentRecords");
        }
    }
}
