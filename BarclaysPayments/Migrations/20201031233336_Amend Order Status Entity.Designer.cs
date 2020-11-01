﻿// <auto-generated />
using System;
using BarclaysPayments.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BarclaysPayments.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201031233336_Amend Order Status Entity")]
    partial class AmendOrderStatusEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BarclaysPayments.Models.BarclaysErrorCode", b =>
                {
                    b.Property<int>("BarclaysErrorCodeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("Retry")
                        .HasColumnType("bit");

                    b.HasKey("BarclaysErrorCodeID");

                    b.ToTable("PAY_BarclaysErrorCode");
                });

            modelBuilder.Entity("BarclaysPayments.Models.BarclaysPayment", b =>
                {
                    b.Property<int>("BarclaysPaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ACCEPTURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("AMOUNT")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BGCOLOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BUTTONBGCOLOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BUTTONTXTCOLOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CANCELURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CN")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CURRENCY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DECLINEURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMAIL")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("EXCEPTIONURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FONTTYPE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Forename")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LANGUAGE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LOGO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ORDERID")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("OWNERADDRESS")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("OWNERCTY")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("OWNERTELNO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OWNERTOWN")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("OWNERZIP")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("PSPID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentReasonID")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("PaymentReasonOther")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("PaymentURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SHASIGN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("TBLBGCOLOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TBLTXTCOLOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TXTCOLOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UniquePaymentRef")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BarclaysPaymentID");

                    b.HasIndex("PaymentReasonID");

                    b.ToTable("PAY_BarclaysPayment");
                });

            modelBuilder.Entity("BarclaysPayments.Models.BarclaysResponse", b =>
                {
                    b.Property<int>("BarclaysResponseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AAVADDRESS")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ACCEPTANCE")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<decimal>("AMOUNT")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BRAND")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CARDNO")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("CN")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("COMPLUS")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CURRENCY")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ED")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("HostName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("NCERROR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ORDERID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PAYID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAYMENT_REFERENCE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("STATUS")
                        .HasColumnType("int");

                    b.Property<string>("TRXDATE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BarclaysResponseID");

                    b.ToTable("PAY_BarclaysResponse");
                });

            modelBuilder.Entity("BarclaysPayments.Models.IELTSOrder", b =>
                {
                    b.Property<int>("IELTSOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarclaysPaymentID")
                        .HasColumnType("int");

                    b.Property<decimal>("IELTSTestAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("IELTSTestDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatusID")
                        .HasColumnType("int");

                    b.Property<decimal>("PracticeMaterialsAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("PracticeMaterialsSent")
                        .HasColumnType("bit");

                    b.Property<decimal>("PracticeTestAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("PracticeTestBooked")
                        .HasColumnType("bit");

                    b.Property<string>("TestType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IELTSOrderID");

                    b.HasIndex("BarclaysPaymentID");

                    b.HasIndex("OrderStatusID");

                    b.ToTable("PAY_IELTSOrder");
                });

            modelBuilder.Entity("BarclaysPayments.Models.IELTSPrice", b =>
                {
                    b.Property<int>("IELTSPriceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IELTSPriceID");

                    b.ToTable("PAY_IELTSPrice");
                });

            modelBuilder.Entity("BarclaysPayments.Models.IELTSTestType", b =>
                {
                    b.Property<string>("IELTSTestTypeID")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("IELTSTestTypeID");

                    b.ToTable("PAY_IELTSTestType");
                });

            modelBuilder.Entity("BarclaysPayments.Models.Note", b =>
                {
                    b.Property<int>("NoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAlert")
                        .HasColumnType("bit");

                    b.Property<string>("NoteText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionID")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NoteID");

                    b.ToTable("PAY_Note");
                });

            modelBuilder.Entity("BarclaysPayments.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("OrderStatusID");

                    b.ToTable("PAY_OrderStatus");
                });

            modelBuilder.Entity("BarclaysPayments.Models.PaymentReason", b =>
                {
                    b.Property<string>("PaymentReasonID")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("PaymentReasonID");

                    b.ToTable("PAY_PaymentReason");
                });

            modelBuilder.Entity("BarclaysPayments.Models.PaymentStatus", b =>
                {
                    b.Property<int>("PaymentStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("PaymentStatusID");

                    b.HasAlternateKey("Code");

                    b.ToTable("PAY_PaymentStatus");
                });

            modelBuilder.Entity("BarclaysPayments.Models.BarclaysPayment", b =>
                {
                    b.HasOne("BarclaysPayments.Models.PaymentReason", "PaymentReason")
                        .WithMany("BarclaysPayment")
                        .HasForeignKey("PaymentReasonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BarclaysPayments.Models.IELTSOrder", b =>
                {
                    b.HasOne("BarclaysPayments.Models.BarclaysPayment", "BarclaysPayment")
                        .WithMany()
                        .HasForeignKey("BarclaysPaymentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarclaysPayments.Models.OrderStatus", "OrderStatus")
                        .WithMany("IELTSOrder")
                        .HasForeignKey("OrderStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
