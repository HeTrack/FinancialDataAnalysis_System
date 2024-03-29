﻿// <auto-generated />
using System;
using FinancialDataAnalysis_System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinancialDataAnalysis_System.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20220513162115_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinancialDataAnalysis_System.Models.Finance", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"), 1L, 1);

                    b.Property<double>("AbsoluteLiquid")
                        .HasColumnType("float");

                    b.Property<double>("ActiveProfit")
                        .HasColumnType("float");

                    b.Property<double>("Avtonomia")
                        .HasColumnType("float");

                    b.Property<double>("CapitalProfit")
                        .HasColumnType("float");

                    b.Property<double>("CurrentLiquid")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("FastLiquid")
                        .HasColumnType("float");

                    b.Property<double>("ManevrCapital")
                        .HasColumnType("float");

                    b.Property<double>("MobilActive")
                        .HasColumnType("float");

                    b.Property<double>("ObespOborotSredstv")
                        .HasColumnType("float");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<double>("SaleProfit")
                        .HasColumnType("float");

                    b.Property<double>("VneoborotProfit")
                        .HasColumnType("float");

                    b.Property<double>("ZaemAndCapital")
                        .HasColumnType("float");

                    b.Property<double>("Zrate")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Finances");
                });

            modelBuilder.Entity("FinancialDataAnalysis_System.Models.Organization", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("FinancialDataAnalysis_System.Models.Finance", b =>
                {
                    b.HasOne("FinancialDataAnalysis_System.Models.Organization", "Organization")
                        .WithMany("Finances")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("FinancialDataAnalysis_System.Models.Organization", b =>
                {
                    b.Navigation("Finances");
                });
#pragma warning restore 612, 618
        }
    }
}
