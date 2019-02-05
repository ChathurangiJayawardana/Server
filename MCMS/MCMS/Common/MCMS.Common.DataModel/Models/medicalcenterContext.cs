using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class medicalcenterContext : DbContext
    {
        public medicalcenterContext()
        {
        }

        public medicalcenterContext(DbContextOptions<medicalcenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Clinics> Clinics { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Inventories> Inventories { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Prescriptions> Prescriptions { get; set; }
        public virtual DbSet<RoleCarryOuts> RoleCarryOuts { get; set; }
        public virtual DbSet<RoleGroups> RoleGroups { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Settlements> Settlements { get; set; }
        public virtual DbSet<SubscriptionInvoices> SubscriptionInvoices { get; set; }
        public virtual DbSet<UserRoleGroups> UserRoleGroups { get; set; }
        public virtual DbSet<Users> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=medicalcenter");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.ToTable("appointments", "medicalcenter");

                entity.HasIndex(e => e.ClinicId)
                    .HasName("clinic_id");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("created_by");

                entity.HasIndex(e => e.DoctorId)
                    .HasName("doctor_id");

                entity.HasIndex(e => e.PatientId)
                    .HasName("patient_id");

                entity.HasIndex(e => e.SessionId)
                    .HasName("session_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AppointedAt).HasColumnName("appointed_at");

                entity.Property(e => e.ClinicId)
                    .HasColumnName("clinic_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Diagnosis)
                    .HasColumnName("diagnosis")
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("doctor_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IsPresent)
                    .HasColumnName("isPresent")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("appointments_ibfk_1");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("appointments_ibfk_4");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("appointments_ibfk_2");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("appointments_ibfk_5");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("appointments_ibfk_3");
            });

            modelBuilder.Entity<Clinics>(entity =>
            {
                entity.ToTable("clinics", "medicalcenter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BillingCycle)
                    .IsRequired()
                    .HasColumnName("billing_cycle")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'monthly'");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RegNo)
                    .IsRequired()
                    .HasColumnName("reg_no")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubscribedAt)
                    .HasColumnName("subscribed_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.ToTable("doctors", "medicalcenter");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Hospital)
                    .HasColumnName("hospital")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasColumnName("registration_number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .IsRequired()
                    .HasColumnName("specialization")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctors_ibfk_1");
            });

            modelBuilder.Entity<Inventories>(entity =>
            {
                entity.ToTable("inventories", "medicalcenter");

                entity.HasIndex(e => e.AddedBy)
                    .HasName("inventory_ibfk_2");

                entity.HasIndex(e => new { e.ClinicId, e.AddedBy })
                    .HasName("clinic_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddedBy)
                    .HasColumnName("added_by")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BatchNo)
                    .HasColumnName("batch_no")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("brand_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClinicId)
                    .HasColumnName("clinic_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiry_date")
                    .HasColumnType("date");

                entity.Property(e => e.GenericName)
                    .IsRequired()
                    .HasColumnName("generic_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturedDate)
                    .HasColumnName("manufactured_date")
                    .HasColumnType("date");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasColumnName("manufacturer")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnName("reorder_level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StorageTemperature)
                    .IsRequired()
                    .HasColumnName("storage_temperature")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Strength)
                    .IsRequired()
                    .HasColumnName("strength")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("inventories_ibfk_2");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("inventories_ibfk_1");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.ToTable("patients", "medicalcenter");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasColumnName("blood_group")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.EmergencyContactAddress)
                    .HasColumnName("emergency_contact_address")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.EmergencyContactName)
                    .HasColumnName("emergency_contact_name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.EmergencyContactPhone)
                    .HasColumnName("emergency_contact_phone")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Nic)
                    .HasColumnName("nic")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patients_ibfk_1");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.ToTable("payments", "medicalcenter");

                entity.HasIndex(e => e.AppointmentId)
                    .HasName("appointment_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.AppointmentId)
                    .HasColumnName("appointment_id")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.IsReceived)
                    .HasColumnName("isReceived")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PaidAt)
                    .HasColumnName("paid_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("payments_ibfk_1");
            });

            modelBuilder.Entity<Prescriptions>(entity =>
            {
                entity.ToTable("prescriptions", "medicalcenter");

                entity.HasIndex(e => e.InventoryId)
                    .HasName("prescriptions_ibfk_2");

                entity.HasIndex(e => new { e.AppointmentId, e.InventoryId })
                    .HasName("appointment_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AppointmentId)
                    .HasColumnName("appointment_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Dosage)
                    .IsRequired()
                    .HasColumnName("dosage")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IssuedAt).HasColumnName("issued_at");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("prescriptions_ibfk_1");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("prescriptions_ibfk_2");
            });

            modelBuilder.Entity<RoleCarryOuts>(entity =>
            {
                entity.HasKey(e => new { e.RoleGroupId, e.RoleId });

                entity.ToTable("role_carry_outs", "medicalcenter");

                entity.HasIndex(e => e.RoleGroupId)
                    .HasName("role_group_id");

                entity.HasIndex(e => e.RoleId)
                    .HasName("role_id");

                entity.Property(e => e.RoleGroupId)
                    .HasColumnName("role_group_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.RoleGroup)
                    .WithMany(p => p.RoleCarryOuts)
                    .HasForeignKey(d => d.RoleGroupId)
                    .HasConstraintName("role_carry_outs_ibfk_1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleCarryOuts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("role_carry_outs_ibfk_2");
            });

            modelBuilder.Entity<RoleGroups>(entity =>
            {
                entity.ToTable("role_groups", "medicalcenter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles", "medicalcenter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.ToTable("sessions", "medicalcenter");

                entity.HasIndex(e => e.DoctorId)
                    .HasName("sessions_ibfk_1");

                entity.HasIndex(e => new { e.ClinicId, e.DoctorId })
                    .HasName("clinic_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClinicId)
                    .HasColumnName("clinic_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("doctor_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Fee)
                    .HasColumnName("fee")
                    .HasColumnType("decimal(10,2)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.HasConducted)
                    .HasColumnName("hasConducted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Start).HasColumnName("start");

                entity.Property(e => e.Stop).HasColumnName("stop");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("sessions_ibfk_2");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("sessions_ibfk_1");
            });

            modelBuilder.Entity<Settlements>(entity =>
            {
                entity.ToTable("settlements", "medicalcenter");

                entity.HasIndex(e => e.ClinicId)
                    .HasName("clinic_id");

                entity.HasIndex(e => e.DoctorId)
                    .HasName("doctor_id_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ClinicId)
                    .HasColumnName("clinic_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("doctor_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.PayedAt)
                    .HasColumnName("payed_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Settlements)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("settlements_ibfk_1");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Settlements)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("settlements_ibfk_2");
            });

            modelBuilder.Entity<SubscriptionInvoices>(entity =>
            {
                entity.ToTable("subscription_invoices", "medicalcenter");

                entity.HasIndex(e => e.ClinicId)
                    .HasName("clinic_id_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ClinicId)
                    .HasColumnName("clinic_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IssuedAt)
                    .HasColumnName("issued_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.PaidAt)
                    .HasColumnName("paid_at")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.SubscriptionInvoices)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subscription_invoices_ibfk_1");
            });

            modelBuilder.Entity<UserRoleGroups>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleGroupId });

                entity.ToTable("user_role_groups", "medicalcenter");

                entity.HasIndex(e => e.RoleGroupId)
                    .HasName("role_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleGroupId)
                    .HasColumnName("role_group_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.RoleGroup)
                    .WithMany(p => p.UserRoleGroups)
                    .HasForeignKey(d => d.RoleGroupId)
                    .HasConstraintName("user_role_groups_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleGroups)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_role_groups_ibfk_1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users", "medicalcenter");

                entity.HasIndex(e => e.ClinicId)
                    .HasName("clinic_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClinicId)
                    .HasColumnName("clinic_id")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("users_ibfk_1");
            });
        }
    }
}
