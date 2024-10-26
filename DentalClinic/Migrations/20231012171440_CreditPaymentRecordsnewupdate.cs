using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class CreditPaymentRecordsnewupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "CreditPaymentRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CreditPaymentRecords_PaymentType",
                table: "CreditPaymentRecords",
                column: "PaymentType");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditPaymentRecords_paymentTypes_PaymentType",
                table: "CreditPaymentRecords",
                column: "PaymentType",
                principalTable: "paymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditPaymentRecords_paymentTypes_PaymentType",
                table: "CreditPaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_CreditPaymentRecords_PaymentType",
                table: "CreditPaymentRecords");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "CreditPaymentRecords");
        }
    }
}
