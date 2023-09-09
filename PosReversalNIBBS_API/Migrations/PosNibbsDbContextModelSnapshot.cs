﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PosReversalNIBBS_API.Data;

#nullable disable

namespace PosReversalNIBBS_API.Migrations
{
    [DbContext(typeof(PosNibbsDbContext))]
    partial class PosNibbsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("IsReversed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LOG_DRP")
                        .HasColumnType("int");

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

                    b.Property<Guid?>("UploadedExcelDetailBatchId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("clientRequestId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UploadedExcelDetailBatchId");

                    b.ToTable("ExcelResponses");
                });

            modelBuilder.Entity("PosReversalNIBBS_API.Models.Domain.FinnacleDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FORACID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PART_TRAN_TYPE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TRAN_AMT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TRAN_DATE")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("finnacleDbs");
                });

            modelBuilder.Entity("PosReversalNIBBS_API.Models.Domain.PostilionDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ACCOUNT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("card_acceptor_id_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datetime_req")
                        .HasColumnType("datetime2");

                    b.Property<string>("pan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("retrieval_reference_nr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("system_trace_audit_nr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("terminal_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("transaction_amount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("postilionDBs");
                });

            modelBuilder.Entity("PosReversalNIBBS_API.Models.Domain.UploadedExcelDetail", b =>
                {
                    b.Property<Guid>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateUploaded")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double?>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<double?>("TotalTransaction")
                        .HasColumnType("float");

                    b.HasKey("BatchId");

                    b.ToTable("UploadedExcelDetails");
                });

            modelBuilder.Entity("PosReversalNIBBS_API.Models.Domain.ExcelResponse", b =>
                {
                    b.HasOne("PosReversalNIBBS_API.Models.Domain.UploadedExcelDetail", "uploadedExcelDetail")
                        .WithMany()
                        .HasForeignKey("UploadedExcelDetailBatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("uploadedExcelDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
