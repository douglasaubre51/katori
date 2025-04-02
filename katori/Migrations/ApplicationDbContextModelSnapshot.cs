﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using katori.Data;

#nullable disable

namespace katori.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("katori.Models.Journal", b =>
                {
                    b.Property<int>("JournalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JournalId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Credit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("Debit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Particular1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Particular2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JournalId");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("katori.Models.Ledger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LedgerType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("TotalCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalDebit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Ledgers");
                });

            modelBuilder.Entity("katori.Models.Particular", b =>
                {
                    b.Property<int>("ParticularId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParticularId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("LedgerId")
                        .HasColumnType("int");

                    b.Property<int>("LedgerType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParticularId");

                    b.HasIndex("LedgerId");

                    b.ToTable("Particulars");
                });

            modelBuilder.Entity("katori.Models.Particular", b =>
                {
                    b.HasOne("katori.Models.Ledger", "Ledger")
                        .WithMany("Particulars")
                        .HasForeignKey("LedgerId");

                    b.Navigation("Ledger");
                });

            modelBuilder.Entity("katori.Models.Ledger", b =>
                {
                    b.Navigation("Particulars");
                });
#pragma warning restore 612, 618
        }
    }
}
