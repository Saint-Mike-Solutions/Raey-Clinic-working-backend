﻿// <auto-generated />
using System;
using DentalClinic.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DentalClinic.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231014221630_LogDateAdded")]
    partial class LogDateAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DentalClinic.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<int?>("ActionByID")
                        .HasColumnType("int");

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AllDay")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AppointmentEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentSetDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DentistID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("ActionByID");

                    b.HasIndex("DentistID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("DentalClinic.Models.AppointmentLog", b =>
                {
                    b.Property<int>("LogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogID"));

                    b.Property<string>("ActionByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AllDay")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AppointmentEndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AppointmentSetDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentStartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DentistName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LogID");

                    b.ToTable("AppointmentLogs");
                });

            modelBuilder.Entity("DentalClinic.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DentalClinic.Models.CompanySetting", b =>
                {
                    b.Property<int>("CompanySettingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanySettingID"));

                    b.Property<int>("AppointmentDuration")
                        .HasColumnType("int");

                    b.Property<int>("CardExpireAfter")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EarlyReminderDate")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanExpireAfter")
                        .HasColumnType("int");

                    b.Property<decimal>("MaximumLoanAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CompanySettingID");

                    b.ToTable("CompanySettings");
                });

            modelBuilder.Entity("DentalClinic.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryID"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DentalClinic.Models.Credit", b =>
                {
                    b.Property<int>("CreditID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreditID"));

                    b.Property<DateTime>("ChargeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IssuedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("Paid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCreditAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnPaid")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CreditID");

                    b.HasIndex("IssuedBy");

                    b.HasIndex("PatientID");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("DentalClinic.Models.CreditPaymentRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("IssuedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("Paid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IssuedBy");

                    b.HasIndex("PatientID");

                    b.HasIndex("PaymentType");

                    b.ToTable("CreditPaymentRecords");
                });

            modelBuilder.Entity("DentalClinic.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfTermination")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCurrentlyActive")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DentalClinic.Models.HealthProgress", b =>
                {
                    b.Property<int>("ProgressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgressID"));

                    b.Property<int?>("AdministeredById")
                        .HasColumnType("int");

                    b.Property<string>("BloodPressure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Miko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotesOnProgress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherVitalSigns")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("ProgressID");

                    b.HasIndex("AdministeredById");

                    b.HasIndex("PatientID");

                    b.ToTable("HealthProgresses");
                });

            modelBuilder.Entity("DentalClinic.Models.MedicalRecord", b =>
                {
                    b.Property<int>("Medical_RecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Medical_RecordID"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscountPercent")
                        .HasColumnType("int");

                    b.Property<bool>("IsCard")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("PrescribedMedicinesandNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcedureIDs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferalList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SubTotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TreatedById")
                        .HasColumnType("int");

                    b.HasKey("Medical_RecordID");

                    b.HasIndex("PatientId");

                    b.HasIndex("TreatedById");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("DentalClinic.Models.MobileBanking", b =>
                {
                    b.Property<int>("MobileBankingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MobileBankingID"));

                    b.Property<string>("MobileBankingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MobileBankingID");

                    b.ToTable("MobileBanking");
                });

            modelBuilder.Entity("DentalClinic.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subcity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DentalClinic.Models.PatientCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientID")
                        .IsUnique();

                    b.ToTable("PatientCards");
                });

            modelBuilder.Entity("DentalClinic.Models.PatientProfile", b =>
                {
                    b.Property<int>("Patient_Id")
                        .HasColumnType("int");

                    b.Property<string>("Allergies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chronics")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalHistory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Patient_Id");

                    b.ToTable("patientProfiles");
                });

            modelBuilder.Entity("DentalClinic.Models.PatientVisit", b =>
                {
                    b.Property<int>("VisitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisitID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("ReasonForVisit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TreatmentProvided")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitID");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("patientVisits");
                });

            modelBuilder.Entity("DentalClinic.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageAttachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCredit")
                        .HasColumnType("bit");

                    b.Property<int>("IssuedByID")
                        .HasColumnType("int");

                    b.Property<string>("MobileBanking")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MobileBankingID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Tax")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IssuedByID");

                    b.HasIndex("MobileBankingID");

                    b.HasIndex("PatientID");

                    b.HasIndex("PaymentTypeID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("DentalClinic.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PaymentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("paymentTypes");
                });

            modelBuilder.Entity("DentalClinic.Models.PricingDescription", b =>
                {
                    b.Property<int>("PricingDescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PricingDescriptionId"));

                    b.Property<string>("pricingDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PricingDescriptionId");

                    b.ToTable("pricingDescriptions");
                });

            modelBuilder.Entity("DentalClinic.Models.PricingReason", b =>
                {
                    b.Property<int>("PricingReasonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PricingReasonID"));

                    b.Property<string>("PricingReasonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PricingReasonID");

                    b.ToTable("pricingReasons");
                });

            modelBuilder.Entity("DentalClinic.Models.Procedure", b =>
                {
                    b.Property<int>("ProcedureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProcedureID"));

                    b.Property<int?>("MedicalRecordMedical_RecordID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PricingDescriptionID")
                        .HasColumnType("int");

                    b.Property<int>("PricingReasonID")
                        .HasColumnType("int");

                    b.Property<string>("ProcedureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProcedureID");

                    b.HasIndex("MedicalRecordMedical_RecordID");

                    b.HasIndex("PricingDescriptionID");

                    b.HasIndex("PricingReasonID");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("DentalClinic.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<bool>("CanControlPayment")
                        .HasColumnType("bit");

                    b.Property<bool>("CanGenerateReport")
                        .HasColumnType("bit");

                    b.Property<bool>("CanMagEmploy")
                        .HasColumnType("bit");

                    b.Property<bool>("CanManageAppointment")
                        .HasColumnType("bit");

                    b.Property<bool>("CanManageMedicalRecord")
                        .HasColumnType("bit");

                    b.Property<bool>("CanManagePatient")
                        .HasColumnType("bit");

                    b.Property<bool>("CanManageSetting")
                        .HasColumnType("bit");

                    b.Property<bool>("CanManageUserPrivalage")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DentalClinic.Models.SMSSetting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AppointmentSetSMS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanExpireSMS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientRegistrationSMS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SMSApi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("SMSSettings");
                });

            modelBuilder.Entity("DentalClinic.Models.SubCity", b =>
                {
                    b.Property<int>("SubCityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCityID"));

                    b.Property<string>("SubCityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCityID");

                    b.ToTable("SubCities");
                });

            modelBuilder.Entity("DentalClinic.Models.UserAccount", b =>
                {
                    b.Property<int>("UserAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserAccountId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserAccountId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("DentalClinic.Models.Appointment", b =>
                {
                    b.HasOne("DentalClinic.Models.Employee", "ActionBy")
                        .WithMany("Appointments")
                        .HasForeignKey("ActionByID");

                    b.HasOne("DentalClinic.Models.Employee", "Dentist")
                        .WithMany()
                        .HasForeignKey("DentistID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DentalClinic.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionBy");

                    b.Navigation("Dentist");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DentalClinic.Models.Credit", b =>
                {
                    b.HasOne("DentalClinic.Models.Employee", "Employee")
                        .WithMany("Credits")
                        .HasForeignKey("IssuedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalClinic.Models.Patient", "Patient")
                        .WithMany("Credits")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DentalClinic.Models.CreditPaymentRecord", b =>
                {
                    b.HasOne("DentalClinic.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("IssuedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalClinic.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalClinic.Models.PaymentType", "PaymentTypes")
                        .WithMany("CreditPaymentRecord")
                        .HasForeignKey("PaymentType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Patient");

                    b.Navigation("PaymentTypes");
                });

            modelBuilder.Entity("DentalClinic.Models.HealthProgress", b =>
                {
                    b.HasOne("DentalClinic.Models.Employee", "Employee")
                        .WithMany("HealthProgresses")
                        .HasForeignKey("AdministeredById")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DentalClinic.Models.Patient", "Patient")
                        .WithMany("HealthProgresses")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DentalClinic.Models.MedicalRecord", b =>
                {
                    b.HasOne("DentalClinic.Models.Patient", "Patient")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalClinic.Models.Employee", "TreatedBy")
                        .WithMany("MedicalRecordAdministered")
                        .HasForeignKey("TreatedById")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Patient");

                    b.Navigation("TreatedBy");
                });

            modelBuilder.Entity("DentalClinic.Models.PatientCard", b =>
                {
                    b.HasOne("DentalClinic.Models.Patient", "Patient")
                        .WithOne("PatientCard")
                        .HasForeignKey("DentalClinic.Models.PatientCard", "PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DentalClinic.Models.PatientProfile", b =>
                {
                    b.HasOne("DentalClinic.Models.Patient", "Patient")
                        .WithOne("Profile")
                        .HasForeignKey("DentalClinic.Models.PatientProfile", "Patient_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DentalClinic.Models.PatientVisit", b =>
                {
                    b.HasOne("DentalClinic.Models.Employee", "Doctor")
                        .WithMany("PatientVisits")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalClinic.Models.Patient", "Patient")
                        .WithMany("PatientVisits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DentalClinic.Models.Payment", b =>
                {
                    b.HasOne("DentalClinic.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("IssuedByID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalClinic.Models.MobileBanking", null)
                        .WithMany("Payments")
                        .HasForeignKey("MobileBankingID");

                    b.HasOne("DentalClinic.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalClinic.Models.PaymentType", "PaymentType")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentTypeID");

                    b.Navigation("Employee");

                    b.Navigation("Patient");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("DentalClinic.Models.Procedure", b =>
                {
                    b.HasOne("DentalClinic.Models.MedicalRecord", null)
                        .WithMany("Procedures")
                        .HasForeignKey("MedicalRecordMedical_RecordID");

                    b.HasOne("DentalClinic.Models.PricingDescription", "PricingDescription")
                        .WithMany("Procedures")
                        .HasForeignKey("PricingDescriptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalClinic.Models.PricingReason", "PricingReason")
                        .WithMany("Procedures")
                        .HasForeignKey("PricingReasonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PricingDescription");

                    b.Navigation("PricingReason");
                });

            modelBuilder.Entity("DentalClinic.Models.UserAccount", b =>
                {
                    b.HasOne("DentalClinic.Models.Employee", "Employee")
                        .WithOne("UserAccount")
                        .HasForeignKey("DentalClinic.Models.UserAccount", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalClinic.Models.Role", "Role")
                        .WithMany("UserAccounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DentalClinic.Models.Employee", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Credits");

                    b.Navigation("HealthProgresses");

                    b.Navigation("MedicalRecordAdministered");

                    b.Navigation("PatientVisits");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("DentalClinic.Models.MedicalRecord", b =>
                {
                    b.Navigation("Procedures");
                });

            modelBuilder.Entity("DentalClinic.Models.MobileBanking", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("DentalClinic.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Credits");

                    b.Navigation("HealthProgresses");

                    b.Navigation("MedicalRecords");

                    b.Navigation("PatientCard");

                    b.Navigation("PatientVisits");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("DentalClinic.Models.PaymentType", b =>
                {
                    b.Navigation("CreditPaymentRecord");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("DentalClinic.Models.PricingDescription", b =>
                {
                    b.Navigation("Procedures");
                });

            modelBuilder.Entity("DentalClinic.Models.PricingReason", b =>
                {
                    b.Navigation("Procedures");
                });

            modelBuilder.Entity("DentalClinic.Models.Role", b =>
                {
                    b.Navigation("UserAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
