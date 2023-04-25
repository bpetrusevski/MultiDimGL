﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PositionKeeping.Database;

#nullable disable

namespace PositionKeeping.Migrations
{
    [DbContext(typeof(PositionKeepingDB))]
    partial class PositionKeepingDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PositionKeeping.Models.AccountUnit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<long?>("AccountUnitId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("AccruedInterest")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("CustomerTypeID")
                        .HasColumnType("int");

                    b.Property<string>("GLAccountNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)");

                    b.Property<int>("MaturitySegmentID")
                        .HasColumnType("int");

                    b.Property<int>("OUID")
                        .HasColumnType("int");

                    b.Property<int>("ProductFamilyID")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountUnitId");

                    b.HasIndex("CustomerTypeID");

                    b.HasIndex("GLAccountNumber");

                    b.HasIndex("MaturitySegmentID");

                    b.HasIndex("OUID");

                    b.HasIndex("ProductFamilyID");

                    b.HasIndex("TypeId");

                    b.ToTable("AccountUnits");
                });

            modelBuilder.Entity("PositionKeeping.Models.AccountingUnitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("AccountingUnitTypes");
                });

            modelBuilder.Entity("PositionKeeping.Models.ClassificationSchema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ClassificationSchemas");

                    b.HasDiscriminator<string>("Code");
                });

            modelBuilder.Entity("PositionKeeping.Models.ClassificationValue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Schema")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ClassificationValue");

                    b.HasDiscriminator<int>("Schema");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PositionKeeping.Models.GLAccount", b =>
                {
                    b.Property<string>("AccountNumber")
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR");

                    b.Property<short>("AL")
                        .HasColumnType("smallint");

                    b.Property<int>("AccountingCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AccountNumber");

                    b.HasIndex("AccountingCategoryID");

                    b.ToTable("ChartOfAccounts");
                });

            modelBuilder.Entity("PositionKeeping.Models.PostingEntry", b =>
                {
                    b.Property<long>("PostingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PostingId"));

                    b.Property<long>("AccountUnitId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("DC")
                        .HasColumnType("smallint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("InstructionRef")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TransactionType")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<DateTime>("ValueDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PostingId");

                    b.HasIndex("AccountUnitId");

                    b.ToTable("PostingEntries");
                });

            modelBuilder.Entity("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.AccountingCategory>", b =>
                {
                    b.HasBaseType("PositionKeeping.Models.ClassificationValue");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.ClassificationSchema>", b =>
                {
                    b.HasBaseType("PositionKeeping.Models.ClassificationValue");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.CustomerType>", b =>
                {
                    b.HasBaseType("PositionKeeping.Models.ClassificationValue");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.MaturitySegment>", b =>
                {
                    b.HasBaseType("PositionKeeping.Models.ClassificationValue");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.OrganizationUnit>", b =>
                {
                    b.HasBaseType("PositionKeeping.Models.ClassificationValue");

                    b.HasDiscriminator().HasValue(6);
                });

            modelBuilder.Entity("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.ProductFamily>", b =>
                {
                    b.HasBaseType("PositionKeeping.Models.ClassificationValue");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.TransactionType>", b =>
                {
                    b.HasBaseType("PositionKeeping.Models.ClassificationValue");

                    b.HasDiscriminator().HasValue(5);
                });

            modelBuilder.Entity("PositionKeeping.Models.AccountUnit", b =>
                {
                    b.HasOne("PositionKeeping.Models.AccountUnit", null)
                        .WithMany("Offsets")
                        .HasForeignKey("AccountUnitId");

                    b.HasOne("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.CustomerType>", "CustomerType")
                        .WithMany()
                        .HasForeignKey("CustomerTypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PositionKeeping.Models.GLAccount", "GL")
                        .WithMany()
                        .HasForeignKey("GLAccountNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.MaturitySegment>", "MaturitySegment")
                        .WithMany()
                        .HasForeignKey("MaturitySegmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.OrganizationUnit>", "OU")
                        .WithMany()
                        .HasForeignKey("OUID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.ProductFamily>", "ProductFamily")
                        .WithMany()
                        .HasForeignKey("ProductFamilyID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PositionKeeping.Models.AccountingUnitType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CustomerType");

                    b.Navigation("GL");

                    b.Navigation("MaturitySegment");

                    b.Navigation("OU");

                    b.Navigation("ProductFamily");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("PositionKeeping.Models.GLAccount", b =>
                {
                    b.HasOne("PositionKeeping.Models.ClassificationValue<PositionKeeping.Models.AccountingCategory>", "AccountingCategory")
                        .WithMany()
                        .HasForeignKey("AccountingCategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AccountingCategory");
                });

            modelBuilder.Entity("PositionKeeping.Models.PostingEntry", b =>
                {
                    b.HasOne("PositionKeeping.Models.AccountUnit", "AccountUnit")
                        .WithMany()
                        .HasForeignKey("AccountUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AccountUnit");
                });

            modelBuilder.Entity("PositionKeeping.Models.AccountUnit", b =>
                {
                    b.Navigation("Offsets");
                });
#pragma warning restore 612, 618
        }
    }
}
