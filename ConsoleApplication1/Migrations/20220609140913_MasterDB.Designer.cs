﻿// <auto-generated />
using System;
using ConsoleApplication1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApplication1.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20220609140913_MasterDB")]
    partial class MasterDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApplication1.Amount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Curr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Amount");
                });

            modelBuilder.Entity("ConsoleApplication1.BagID", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("N")
                        .HasColumnType("int");

                    b.Property<int?>("RemoteMessageId")
                        .HasColumnType("int");

                    b.Property<int>("Text")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RemoteMessageId");

                    b.ToTable("BagID");
                });

            modelBuilder.Entity("ConsoleApplication1.CashIn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AmountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AmountId");

                    b.ToTable("CashIn");
                });

            modelBuilder.Entity("ConsoleApplication1.CashOut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AmountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AmountId");

                    b.ToTable("CashOut");
                });

            modelBuilder.Entity("ConsoleApplication1.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CountingsId")
                        .HasColumnType("int");

                    b.Property<int>("NDoc")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountingsId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ConsoleApplication1.Cheque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("ChequesId")
                        .HasColumnType("int");

                    b.Property<string>("Codeline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Curr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChequesId");

                    b.ToTable("Cheque");
                });

            modelBuilder.Entity("ConsoleApplication1.Cheques", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Cheques");
                });

            modelBuilder.Entity("ConsoleApplication1.Count", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountingId")
                        .HasColumnType("int");

                    b.Property<string>("Curr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Den")
                        .HasColumnType("int");

                    b.Property<int?>("DestDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("N")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<string>("SType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountingId");

                    b.HasIndex("DestDetailsId");

                    b.ToTable("Count");
                });

            modelBuilder.Entity("ConsoleApplication1.Counted", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountingsId")
                        .HasColumnType("int");

                    b.Property<double>("Denom")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountingsId");

                    b.ToTable("Counted");
                });

            modelBuilder.Entity("ConsoleApplication1.Counting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Counting");
                });

            modelBuilder.Entity("ConsoleApplication1.Countings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Valid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Countings");
                });

            modelBuilder.Entity("ConsoleApplication1.DestDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("DestDetails");
                });

            modelBuilder.Entity("ConsoleApplication1.Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountingsId")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountingsId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("ConsoleApplication1.ManualDeposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnvelopeId")
                        .HasColumnType("int");

                    b.Property<int?>("ManualDepositsId")
                        .HasColumnType("int");

                    b.Property<int>("Nop")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TotalId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManualDepositsId");

                    b.HasIndex("TotalId");

                    b.ToTable("ManualDeposit");
                });

            modelBuilder.Entity("ConsoleApplication1.ManualDeposits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("ManualDeposits");
                });

            modelBuilder.Entity("ConsoleApplication1.RemoteMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AccountingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CashInId")
                        .HasColumnType("int");

                    b.Property<int?>("CashOutId")
                        .HasColumnType("int");

                    b.Property<int>("ChannelID")
                        .HasColumnType("int");

                    b.Property<string>("ChannelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChequesId")
                        .HasColumnType("int");

                    b.Property<int>("Conciliation")
                        .HasColumnType("int");

                    b.Property<int?>("CountingId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DestDetailsId")
                        .HasColumnType("int");

                    b.Property<int?>("DetailsId")
                        .HasColumnType("int");

                    b.Property<string>("DeviceID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnvelopeID")
                        .HasColumnType("int");

                    b.Property<int>("ExecutedBy")
                        .HasColumnType("int");

                    b.Property<int>("IsKit")
                        .HasColumnType("int");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int?>("ManualDepositsId")
                        .HasColumnType("int");

                    b.Property<int>("NOP")
                        .HasColumnType("int");

                    b.Property<string>("Operation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SealID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TicketsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionID")
                        .HasColumnType("int");

                    b.Property<string>("TransactionInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionRef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.Property<int>("UserAlternateID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("UserInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserLevel")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserOrganization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CashInId");

                    b.HasIndex("CashOutId");

                    b.HasIndex("ChequesId");

                    b.HasIndex("CountingId");

                    b.HasIndex("DestDetailsId");

                    b.HasIndex("DetailsId");

                    b.HasIndex("ManualDepositsId");

                    b.HasIndex("TicketsId");

                    b.ToTable("RemoteMessages");
                });

            modelBuilder.Entity("ConsoleApplication1.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Curr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int?>("TicketsId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TicketsId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ConsoleApplication1.Tickets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ConsoleApplication1.Total", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Total");
                });

            modelBuilder.Entity("ConsoleApplication1.BagID", b =>
                {
                    b.HasOne("ConsoleApplication1.RemoteMessage", null)
                        .WithMany("BagID")
                        .HasForeignKey("RemoteMessageId");
                });

            modelBuilder.Entity("ConsoleApplication1.CashIn", b =>
                {
                    b.HasOne("ConsoleApplication1.Amount", "Amount")
                        .WithMany()
                        .HasForeignKey("AmountId");
                });

            modelBuilder.Entity("ConsoleApplication1.CashOut", b =>
                {
                    b.HasOne("ConsoleApplication1.Amount", "Amount")
                        .WithMany()
                        .HasForeignKey("AmountId");
                });

            modelBuilder.Entity("ConsoleApplication1.Category", b =>
                {
                    b.HasOne("ConsoleApplication1.Countings", null)
                        .WithMany("Category")
                        .HasForeignKey("CountingsId");
                });

            modelBuilder.Entity("ConsoleApplication1.Cheque", b =>
                {
                    b.HasOne("ConsoleApplication1.Cheques", null)
                        .WithMany("Cheque")
                        .HasForeignKey("ChequesId");
                });

            modelBuilder.Entity("ConsoleApplication1.Count", b =>
                {
                    b.HasOne("ConsoleApplication1.Counting", null)
                        .WithMany("Count")
                        .HasForeignKey("CountingId");

                    b.HasOne("ConsoleApplication1.DestDetails", null)
                        .WithMany("Count")
                        .HasForeignKey("DestDetailsId");
                });

            modelBuilder.Entity("ConsoleApplication1.Counted", b =>
                {
                    b.HasOne("ConsoleApplication1.Countings", null)
                        .WithMany("Counted")
                        .HasForeignKey("CountingsId");
                });

            modelBuilder.Entity("ConsoleApplication1.Details", b =>
                {
                    b.HasOne("ConsoleApplication1.Countings", "Countings")
                        .WithMany()
                        .HasForeignKey("CountingsId");
                });

            modelBuilder.Entity("ConsoleApplication1.ManualDeposit", b =>
                {
                    b.HasOne("ConsoleApplication1.ManualDeposits", null)
                        .WithMany("ManualDeposit")
                        .HasForeignKey("ManualDepositsId");

                    b.HasOne("ConsoleApplication1.Total", "Total")
                        .WithMany()
                        .HasForeignKey("TotalId");
                });

            modelBuilder.Entity("ConsoleApplication1.RemoteMessage", b =>
                {
                    b.HasOne("ConsoleApplication1.CashIn", "CashIn")
                        .WithMany()
                        .HasForeignKey("CashInId");

                    b.HasOne("ConsoleApplication1.CashOut", "CashOut")
                        .WithMany()
                        .HasForeignKey("CashOutId");

                    b.HasOne("ConsoleApplication1.Cheques", "Cheques")
                        .WithMany()
                        .HasForeignKey("ChequesId");

                    b.HasOne("ConsoleApplication1.Counting", "Counting")
                        .WithMany()
                        .HasForeignKey("CountingId");

                    b.HasOne("ConsoleApplication1.DestDetails", "DestDetails")
                        .WithMany()
                        .HasForeignKey("DestDetailsId");

                    b.HasOne("ConsoleApplication1.Details", "Details")
                        .WithMany()
                        .HasForeignKey("DetailsId");

                    b.HasOne("ConsoleApplication1.ManualDeposits", "ManualDeposits")
                        .WithMany()
                        .HasForeignKey("ManualDepositsId");

                    b.HasOne("ConsoleApplication1.Tickets", "Tickets")
                        .WithMany()
                        .HasForeignKey("TicketsId");
                });

            modelBuilder.Entity("ConsoleApplication1.Ticket", b =>
                {
                    b.HasOne("ConsoleApplication1.Tickets", null)
                        .WithMany("Ticket")
                        .HasForeignKey("TicketsId");
                });
#pragma warning restore 612, 618
        }
    }
}
