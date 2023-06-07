﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PosReversalNIBBS_API.Data;

#nullable disable

namespace PosReversalNIBBS_API.Migrations
{
    [DbContext(typeof(PosNibbsDbContext))]
    [Migration("20230607192413_Account_ID update")]
    partial class Account_IDupdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PosReversalNIBBS_API.Models.Domain.ExcelResponse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ACCOUNT_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AMOUNT")
                        .HasColumnType("float");

                    b.Property<string>("BANK")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MERCHANT_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PROCESSOR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RRN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("STAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TERMINAL_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TRANSACTION_DATE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExcelResponses");
                });
#pragma warning restore 612, 618
        }
    }
}
