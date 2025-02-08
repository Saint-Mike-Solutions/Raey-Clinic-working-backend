using DentalClinic.Models;
using DentalClinic.Utils;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AFB> AFBs { get; set; }
        public DbSet<Bacterology> Bacterologies { get; set; }

        public DbSet<Chemistry> Chemistries { get; set; }

        public DbSet<Microscopy> Microscopies { get; set; }

        public DbSet<StoolExamination> StoolExaminations { get; set; }

        public DbSet<Serology> Serologies { get; set; }

        public DbSet<Urinalysis> Urinalyses { get; set; }

        public DbSet<LaboratoryRequests> LaboratoryRequests { get; set; }

        public DbSet<Hematology> Hematologies { get; set; }


        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Procedure>   Procedures { get; set; }

        public DbSet<PricingDescription> pricingDescriptions { get; set; }
        public DbSet<MedicalRecord > MedicalRecords { get; set; }   

        public DbSet<PricingReason> pricingReasons { get; set; }

        public DbSet<PatientProfile> patientProfiles { get; set; }

        public DbSet<PatientVisit> patientVisits { get; set; }

        //public DbSet<Referal> Referals { get; set; }

        public DbSet<HealthProgress> HealthProgresses { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<SubCity> SubCities { get; set; }
        public DbSet<AppointmentLog> AppointmentLogs { get; set; }
        public DbSet<CompanySetting> CompanySettings { get; set; }

        public DbSet<PaymentType> paymentTypes { get; set; }

        public DbSet<PatientCard> PatientCards { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<SMSSetting> SMSSettings { get; set; }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<MobileBanking> MobileBanking { get; set; } 

        public DbSet<CreditPaymentRecord> CreditPaymentRecords { get; set; }

        public DbSet<MedicalCertificate> MedicalCertificates { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Referral> Referrals { get; set; }

        public DbSet<LaboratoryRequestList> LaboratoryRequestLists { get; set; }

        public DbSet<CompanyLabPrices> CompanyLabPrices { get; set; }

        public DbSet<SpecialCases> SpecialCases { get; set; }
        //public DbSet<ProcedureQuantity> ProcedureQuantity { get; set; }




        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var added = ChangeTracker.Entries<IAuditableEntity>().Where(E => E.State == EntityState.Added).ToList();
            var now = DateTime.Now;
            added.ForEach(E =>
            {
                E.Property(x => x.CreatedAt).CurrentValue = now;
                E.Property(x => x.UpdatedAt).CurrentValue = now;

            });

            var modified = ChangeTracker.Entries<IAuditableEntity>().Where(E => E.State == EntityState.Modified).ToList();

            modified.ForEach(E =>
            {
                E.Property(x => x.UpdatedAt).CurrentValue = now;

            });

            return base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LaboratoryRequestList>()
                .HasOne(l => l.Patient)
                .WithMany()
                .HasForeignKey(l => l.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LaboratoryRequestList>()
                .HasOne(l => l.Requester)
                .WithMany()
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HealthProgress>()
                .HasOne(hp => hp.Employee)
                .WithMany(e => e.HealthProgresses)
                .HasForeignKey(hp => hp.AdministeredById)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(hp => hp.TreatedBy)
                .WithMany(e => e.MedicalRecordAdministered)
                .HasForeignKey(hp => hp.TreatedById)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Dentist)
                .WithMany()
                .HasForeignKey(a => a.DentistID)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patient)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Prescriptions)
                .WithOne(p => p.Emp)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Patient)
                .WithOne(p => p.MedicalRecord) // Change WithMany to WithOne
                .HasForeignKey<MedicalRecord>(mr => mr.PatientId) // Specify the foreign key
                .OnDelete(DeleteBehavior.Cascade);




            modelBuilder.Entity<MedicalCertificate>()
                .HasOne(m => m.Employee)
                .WithMany(e => e.MedicalCertificatesHanded)
                .HasForeignKey(m => m.EmployeeId)
                .IsRequired(false); // Employee can be null

            modelBuilder.Entity<MedicalCertificate>()
                .HasOne(m => m.Patient)
                .WithMany(p => p.MedicalCertificates)
                .HasForeignKey(m => m.PatientId)
                .IsRequired();

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne() // Assuming Employees don't have navigation property to Department, else use WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentID); // Foreign key in Employee

            // Optional: Configure cascade delete if necessary
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.MedicalCertificatesHanded)
                .WithOne(m => m.Employee)
                .OnDelete(DeleteBehavior.Restrict); // or Cascade if desired

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.MedicalCertificates)
                .WithOne(m => m.Patient)
                .OnDelete(DeleteBehavior.Restrict); // or Cascade if desired

            // Configure the Referral-Employee relationship
            modelBuilder.Entity<Referral>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.ReferralsWritten)  // Assuming Employee has a Referrals collection
                .HasForeignKey(r => r.ReferredBy) // Foreign key is ReferredBy (which references EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);  // Handle null if an Employee is deleted

            // Configure the Referral-Patient relationship
            modelBuilder.Entity<Referral>()
                .HasOne(r => r.Patient)
                .WithMany(p => p.Referrals)  // Assuming Patient has a Referrals collection
                .HasForeignKey(r => r.PatientId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascades delete when a Patient is deleted

            modelBuilder.Entity<Hematology>()
                .HasOne(h => h.Diff)
                .WithOne()
                .HasForeignKey<Hematology>(h => h.DiffId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Define the behavior on delete

            // Optional: Configure Diff relationship
            modelBuilder.Entity<Diff>()
                .HasKey(d => d.Id); // Ensure Diff has a primary key

            modelBuilder.Entity<Bacterology>()
                .HasOne(b => b.AFB)       // A Bacterology has one AFB
                .WithOne()                 // An AFB can have one Bacterology
                .HasForeignKey<Bacterology>(b => b.AFBId) // AFBId in Bacterology is the foreign key
                .OnDelete(DeleteBehavior.Cascade); // If a Bacterology is deleted, the associated AFB can also be deleted

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.LaboratoryRequests)      // Patient has one LaboratoryRequest
                .WithOne(lr => lr.Patient)              // LaboratoryRequest has one Patient
                .HasForeignKey<LaboratoryRequests>(lr => lr.PatientId);  // Link by PatientId

            modelBuilder.Entity<LaboratoryRequests>()
                .HasOne(l => l.RequestedBy)
                .WithMany() // Assuming an employee can request multiple tests
                .HasForeignKey(l => l.RequestedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LaboratoryRequests>()
                .HasOne(l => l.ReportedBy)
                .WithMany() // Assuming an employee can report multiple tests
                .HasForeignKey(l => l.ReportedById)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-one relationship between Patient and Payment
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Payment)       // Patient has one Payment
                .WithOne(p => p.Patient)     // Payment has one Patient
                .HasForeignKey<Payment>(p => p.PatientID); // FK in Payment table


        //modelBuilder.Entity<LaboratoryRequestList>()
        //    .HasOne(lr => lr.labratoryRequest)
        //    .WithMany(l => l.LabrequestLists)
        //    .HasForeignKey(lr => lr.laboratoryrequestId);
    }

}
}
