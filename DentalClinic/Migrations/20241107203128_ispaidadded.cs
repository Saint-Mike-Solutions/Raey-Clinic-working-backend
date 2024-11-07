using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class ispaidadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Urinalyses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "StoolExaminations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Serologies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Microscopies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Hematologies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Chemistries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Bacterologies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Urinalyses");

            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "StoolExaminations");

            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Serologies");

            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Microscopies");

            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Hematologies");

            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Chemistries");

            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Bacterologies");
        }
    }
}
