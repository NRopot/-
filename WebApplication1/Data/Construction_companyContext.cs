using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1
{
    public partial class Construction_companyContext : DbContext
    {
        public virtual DbSet<Brigade> Brigade { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<TypesOfJobs> TypesOfJobs { get; set; }
        public virtual DbSet<Works> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=KOLENO-ПК\SQLEXPRESS;Database=Construction_company;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brigade>(entity =>
            {
                entity.Property(e => e.BrigadeId).HasColumnName("Brigade_id");

                entity.Property(e => e.CompositionWorker)
                    .HasColumnName("Composition_worker")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.FioBrigadier)
                    .HasColumnName("FIO_Brigadier")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.JobId).HasColumnName("Job_id");

                entity.Property(e => e.NameBrigade)
                    .IsRequired()
                    .HasColumnName("Name_brigade")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Brigade)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_Brigade_Types_Of_Jobs");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.Address).HasColumnType("nchar(20)");

                entity.Property(e => e.FioCustomer)
                    .IsRequired()
                    .HasColumnName("FIO_Customer")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.PassportData)
                    .HasColumnName("Passport_data")
                    .HasColumnType("nchar(20)");
            });

            modelBuilder.Entity<Materials>(entity =>
            {
                entity.HasKey(e => e.MaterialId);

                entity.Property(e => e.MaterialId).HasColumnName("Material_id");

                entity.Property(e => e.Description).HasColumnType("nchar(10)");

                entity.Property(e => e.MaterialPrice)
                    .HasColumnName("Material_Price")
                    .HasColumnType("money");

                entity.Property(e => e.NameMaterial)
                    .IsRequired()
                    .HasColumnName("Name_Material")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Packing).HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.BrigadeId).HasColumnName("Brigade_id");

                entity.Property(e => e.Brigadier).HasColumnType("nchar(10)");

                entity.Property(e => e.CompletionNote).HasColumnName("Completion_note");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.CustomersId).HasColumnName("Customers_id");

                entity.Property(e => e.JobId).HasColumnName("Job_id");

                entity.Property(e => e.MaterialsId).HasColumnName("Materials_id");

                entity.Property(e => e.PaymentNote).HasColumnName("Payment_note");

                entity.HasOne(d => d.Brigade)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BrigadeId)
                    .HasConstraintName("FK_Orders_Brigade");

                entity.HasOne(d => d.Customers)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomersId)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Materials)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MaterialsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Materials");
            });

            modelBuilder.Entity<TypesOfJobs>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.ToTable("Types_Of_Jobs");

                entity.Property(e => e.JobId).HasColumnName("Job_id");

                entity.Property(e => e.CostWork)
                    .HasColumnName("Cost_work")
                    .HasColumnType("money");

                entity.Property(e => e.Description).HasMaxLength(10);

                entity.Property(e => e.MaterialId).HasColumnName("Material_id");

                entity.Property(e => e.NameWork)
                    .IsRequired()
                    .HasColumnName("Name_Work")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.TypesOfJobs)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_Types_Of_Jobs_Materials");
            });

            modelBuilder.Entity<Works>(entity =>
            {
                entity.HasKey(e => e.WorkId);

                entity.Property(e => e.WorkId).HasColumnName("Work_id");

                entity.Property(e => e.BrigadeId).HasColumnName("Brigade_id");

                entity.Property(e => e.DateBeginning)
                    .HasColumnName("Date_Beginning")
                    .HasColumnType("date");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("Date_End")
                    .HasColumnType("date");

                entity.Property(e => e.FioBrigadier)
                    .HasColumnName("FIO_Brigadier")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.JobId).HasColumnName("Job_id");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.HasOne(d => d.Brigade)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.BrigadeId)
                    .HasConstraintName("FK_Works_Brigade");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_Works_Types_Of_Jobs");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Works_Orders");
            });
        }
    }
}
