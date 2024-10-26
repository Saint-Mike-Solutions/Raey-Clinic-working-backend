using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class SettingUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Cities_CityId1",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CityId1",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Cities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityId1",
                table: "Cities",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Cities_CityId1",
                table: "Cities",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "CityId");
        }
    }
}
