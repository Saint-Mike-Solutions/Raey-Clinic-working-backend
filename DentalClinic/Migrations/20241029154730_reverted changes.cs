using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class revertedchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequestLists_LaboratoryRequests_laboratoryrequestId",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequestLists_laboratoryrequestId",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropColumn(
                name: "laboratoryrequestId",
                table: "LaboratoryRequestLists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "laboratoryrequestId",
                table: "LaboratoryRequestLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequestLists_laboratoryrequestId",
                table: "LaboratoryRequestLists",
                column: "laboratoryrequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequestLists_LaboratoryRequests_laboratoryrequestId",
                table: "LaboratoryRequestLists",
                column: "laboratoryrequestId",
                principalTable: "LaboratoryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
