﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(Construction_companyContext))]
    partial class Construction_companyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Brigade", b =>
                {
                    b.Property<int>("BrigadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Brigade_id");

                    b.Property<string>("CompositionWorker")
                        .HasColumnName("Composition_worker")
                        .HasColumnType("nchar(10)");

                    b.Property<string>("FioBrigadier")
                        .HasColumnName("FIO_Brigadier")
                        .HasColumnType("nchar(10)");

                    b.Property<int?>("JobId")
                        .HasColumnName("Job_id");

                    b.Property<string>("NameBrigade")
                        .IsRequired()
                        .HasColumnName("Name_brigade")
                        .HasColumnType("nchar(10)");

                    b.HasKey("BrigadeId");

                    b.HasIndex("JobId");

                    b.ToTable("Brigade");
                });

            modelBuilder.Entity("WebApplication1.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Customer_id");

                    b.Property<string>("Address")
                        .HasColumnType("nchar(20)");

                    b.Property<string>("FioCustomer")
                        .IsRequired()
                        .HasColumnName("FIO_Customer")
                        .HasColumnType("nchar(20)");

                    b.Property<string>("PassportData")
                        .HasColumnName("Passport_data")
                        .HasColumnType("nchar(20)");

                    b.Property<int?>("Phone");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebApplication1.Materials", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Material_id");

                    b.Property<string>("Description")
                        .HasColumnType("nchar(10)");

                    b.Property<decimal?>("MaterialPrice")
                        .HasColumnName("Material_Price")
                        .HasColumnType("money");

                    b.Property<string>("NameMaterial")
                        .IsRequired()
                        .HasColumnName("Name_Material")
                        .HasColumnType("nchar(10)");

                    b.Property<string>("Packing")
                        .HasColumnType("nchar(10)");

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("WebApplication1.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Order_Id");

                    b.Property<int?>("BrigadeId")
                        .HasColumnName("Brigade_id");

                    b.Property<string>("Brigadier")
                        .HasColumnType("nchar(10)");

                    b.Property<bool?>("CompletionNote")
                        .HasColumnName("Completion_note");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("money");

                    b.Property<int?>("CustomersId")
                        .HasColumnName("Customers_id");

                    b.Property<int?>("JobId")
                        .HasColumnName("Job_id");

                    b.Property<int?>("MaterialsId")
                        .HasColumnName("Materials_id");

                    b.Property<bool?>("PaymentNote")
                        .HasColumnName("Payment_note");

                    b.HasKey("OrderId");

                    b.HasIndex("BrigadeId");

                    b.HasIndex("CustomersId");

                    b.HasIndex("MaterialsId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebApplication1.TypesOfJobs", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Job_id");

                    b.Property<decimal?>("CostWork")
                        .HasColumnName("Cost_work")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .HasMaxLength(10);

                    b.Property<int?>("MaterialId")
                        .HasColumnName("Material_id");

                    b.Property<string>("NameWork")
                        .IsRequired()
                        .HasColumnName("Name_Work")
                        .HasMaxLength(10);

                    b.HasKey("JobId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Types_Of_Jobs");
                });

            modelBuilder.Entity("WebApplication1.Works", b =>
                {
                    b.Property<int>("WorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Work_id");

                    b.Property<int?>("BrigadeId")
                        .HasColumnName("Brigade_id");

                    b.Property<DateTime?>("DateBeginning")
                        .HasColumnName("Date_Beginning")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnName("Date_End")
                        .HasColumnType("date");

                    b.Property<string>("FioBrigadier")
                        .HasColumnName("FIO_Brigadier")
                        .HasColumnType("nchar(10)");

                    b.Property<int?>("JobId")
                        .HasColumnName("Job_id");

                    b.Property<int?>("OrderId")
                        .HasColumnName("Order_id");

                    b.HasKey("WorkId");

                    b.HasIndex("BrigadeId");

                    b.HasIndex("JobId");

                    b.HasIndex("OrderId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("WebApplication1.Brigade", b =>
                {
                    b.HasOne("WebApplication1.TypesOfJobs", "Job")
                        .WithMany("Brigade")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK_Brigade_Types_Of_Jobs");
                });

            modelBuilder.Entity("WebApplication1.Orders", b =>
                {
                    b.HasOne("WebApplication1.Brigade", "Brigade")
                        .WithMany("Orders")
                        .HasForeignKey("BrigadeId")
                        .HasConstraintName("FK_Orders_Brigade");

                    b.HasOne("WebApplication1.Customers", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomersId")
                        .HasConstraintName("FK_Orders_Customers");

                    b.HasOne("WebApplication1.Materials", "Materials")
                        .WithMany("Orders")
                        .HasForeignKey("MaterialsId")
                        .HasConstraintName("FK_Orders_Materials")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.TypesOfJobs", b =>
                {
                    b.HasOne("WebApplication1.Materials", "Material")
                        .WithMany("TypesOfJobs")
                        .HasForeignKey("MaterialId")
                        .HasConstraintName("FK_Types_Of_Jobs_Materials");
                });

            modelBuilder.Entity("WebApplication1.Works", b =>
                {
                    b.HasOne("WebApplication1.Brigade", "Brigade")
                        .WithMany("Works")
                        .HasForeignKey("BrigadeId")
                        .HasConstraintName("FK_Works_Brigade");

                    b.HasOne("WebApplication1.TypesOfJobs", "Job")
                        .WithMany("Works")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK_Works_Types_Of_Jobs");

                    b.HasOne("WebApplication1.Orders", "Order")
                        .WithMany("Works")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_Works_Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
