using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class rlshipbnLocationsRemovedAndChronicsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_patientProfiles_Patients_patient_Id",
                table: "patientProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCities_Cities_CityID",
                table: "SubCities");

            migrationBuilder.DropIndex(
                name: "IX_SubCities_CityID",
                table: "SubCities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "SubCities");

            migrationBuilder.DropColumn(
                name: "FamilyHistory",
                table: "patientProfiles");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "patient_Id",
                table: "patientProfiles",
                newName: "Patient_Id");

            migrationBuilder.RenameColumn(
                name: "previousConditions",
                table: "patientProfiles",
                newName: "Chronics");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentDuration",
                table: "CompanySettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_patientProfiles_Patients_Patient_Id",
                table: "patientProfiles",
                column: "Patient_Id",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patientProfiles_Patients_Patient_Id",
                table: "patientProfiles");

            migrationBuilder.DropColumn(
                name: "AppointmentDuration",
                table: "CompanySettings");

            migrationBuilder.RenameColumn(
                name: "Patient_Id",
                table: "patientProfiles",
                newName: "patient_Id");

            migrationBuilder.RenameColumn(
                name: "Chronics",
                table: "patientProfiles",
                newName: "previousConditions");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "SubCities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FamilyHistory",
                table: "patientProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubCities_CityID",
                table: "SubCities",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patientProfiles_Patients_patient_Id",
                table: "patientProfiles",
                column: "patient_Id",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCities_Cities_CityID",
                table: "SubCities",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
