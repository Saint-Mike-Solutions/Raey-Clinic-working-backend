using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class MobileBankingPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobileBanking_Payments_PaymentID",
                table: "MobileBanking");

            migrationBuilder.DropIndex(
                name: "IX_MobileBanking_PaymentID",
                table: "MobileBanking");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "MobileBanking");

            migrationBuilder.AddColumn<int>(
                name: "MobileBankingID",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MobileBankingID",
                table: "Payments",
                column: "MobileBankingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_MobileBanking_MobileBankingID",
                table: "Payments",
                column: "MobileBankingID",
                principalTable: "MobileBanking",
                principalColumn: "MobileBankingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_MobileBanking_MobileBankingID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_MobileBankingID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "MobileBankingID",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "MobileBanking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MobileBanking_PaymentID",
                table: "MobileBanking",
                column: "PaymentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileBanking_Payments_PaymentID",
                table: "MobileBanking",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
