using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class MasterDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<int>(nullable: false),
                    Curr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManualDeposits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualDeposits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Total",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Total", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashIn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashIn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashIn_Amount_AmountId",
                        column: x => x.AmountId,
                        principalTable: "Amount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashOut",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashOut_Amount_AmountId",
                        column: x => x.AmountId,
                        principalTable: "Amount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cheque",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Curr = table.Column<string>(nullable: true),
                    Codeline = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ChequesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheque_Cheques_ChequesId",
                        column: x => x.ChequesId,
                        principalTable: "Cheques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NDoc = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    CountingsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Countings_CountingsId",
                        column: x => x.CountingsId,
                        principalTable: "Countings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Counted",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denom = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    CountingsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counted_Countings_CountingsId",
                        column: x => x.CountingsId,
                        principalTable: "Countings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(nullable: false),
                    CountingsId = table.Column<int>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Countings_CountingsId",
                        column: x => x.CountingsId,
                        principalTable: "Countings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Count",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<int>(nullable: false),
                    Den = table.Column<int>(nullable: false),
                    Curr = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    N = table.Column<int>(nullable: false),
                    SType = table.Column<string>(nullable: true),
                    CountingId = table.Column<int>(nullable: true),
                    DestDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Count", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Count_Counting_CountingId",
                        column: x => x.CountingId,
                        principalTable: "Counting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Count_DestDetails_DestDetailsId",
                        column: x => x.DestDetailsId,
                        principalTable: "DestDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    Curr = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    TicketsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManualDeposit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalId = table.Column<int>(nullable: true),
                    Nop = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    EnvelopeId = table.Column<int>(nullable: false),
                    ManualDepositsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualDeposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualDeposit_ManualDeposits_ManualDepositsId",
                        column: x => x.ManualDepositsId,
                        principalTable: "ManualDeposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManualDeposit_Total_TotalId",
                        column: x => x.TotalId,
                        principalTable: "Total",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RemoteMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionID = table.Column<int>(nullable: false),
                    User = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserLevel = table.Column<int>(nullable: false),
                    UserAlternateID = table.Column<int>(nullable: false),
                    UserOrganization = table.Column<string>(nullable: true),
                    UserInfo = table.Column<string>(nullable: true),
                    TransactionRef = table.Column<string>(nullable: true),
                    TransactionInfo = table.Column<string>(nullable: true),
                    AccountingDate = table.Column<DateTime>(nullable: false),
                    DetailsId = table.Column<int>(nullable: true),
                    IsKit = table.Column<int>(nullable: false),
                    DestDetailsId = table.Column<int>(nullable: true),
                    TicketsId = table.Column<int>(nullable: true),
                    ChequesId = table.Column<int>(nullable: true),
                    Conciliation = table.Column<int>(nullable: false),
                    Operation = table.Column<string>(nullable: true),
                    DeviceID = table.Column<string>(nullable: true),
                    CustomerCode = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    NOP = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    EnvelopeID = table.Column<int>(nullable: false),
                    SealID = table.Column<int>(nullable: false),
                    ManualDepositsId = table.Column<int>(nullable: true),
                    CountingId = table.Column<int>(nullable: true),
                    MachineId = table.Column<int>(nullable: false),
                    ExecutedBy = table.Column<int>(nullable: false),
                    ChannelID = table.Column<int>(nullable: false),
                    ChannelName = table.Column<string>(nullable: true),
                    CashOutId = table.Column<int>(nullable: true),
                    CashInId = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemoteMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemoteMessages_CashIn_CashInId",
                        column: x => x.CashInId,
                        principalTable: "CashIn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemoteMessages_CashOut_CashOutId",
                        column: x => x.CashOutId,
                        principalTable: "CashOut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemoteMessages_Cheques_ChequesId",
                        column: x => x.ChequesId,
                        principalTable: "Cheques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemoteMessages_Counting_CountingId",
                        column: x => x.CountingId,
                        principalTable: "Counting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemoteMessages_DestDetails_DestDetailsId",
                        column: x => x.DestDetailsId,
                        principalTable: "DestDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemoteMessages_Details_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemoteMessages_ManualDeposits_ManualDepositsId",
                        column: x => x.ManualDepositsId,
                        principalTable: "ManualDeposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemoteMessages_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BagID",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<int>(nullable: false),
                    Text = table.Column<int>(nullable: false),
                    N = table.Column<int>(nullable: false),
                    RemoteMessageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BagID_RemoteMessages_RemoteMessageId",
                        column: x => x.RemoteMessageId,
                        principalTable: "RemoteMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BagID_RemoteMessageId",
                table: "BagID",
                column: "RemoteMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_CashIn_AmountId",
                table: "CashIn",
                column: "AmountId");

            migrationBuilder.CreateIndex(
                name: "IX_CashOut_AmountId",
                table: "CashOut",
                column: "AmountId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CountingsId",
                table: "Category",
                column: "CountingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheque_ChequesId",
                table: "Cheque",
                column: "ChequesId");

            migrationBuilder.CreateIndex(
                name: "IX_Count_CountingId",
                table: "Count",
                column: "CountingId");

            migrationBuilder.CreateIndex(
                name: "IX_Count_DestDetailsId",
                table: "Count",
                column: "DestDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Counted_CountingsId",
                table: "Counted",
                column: "CountingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CountingsId",
                table: "Details",
                column: "CountingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualDeposit_ManualDepositsId",
                table: "ManualDeposit",
                column: "ManualDepositsId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualDeposit_TotalId",
                table: "ManualDeposit",
                column: "TotalId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteMessages_CashInId",
                table: "RemoteMessages",
                column: "CashInId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteMessages_CashOutId",
                table: "RemoteMessages",
                column: "CashOutId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteMessages_ChequesId",
                table: "RemoteMessages",
                column: "ChequesId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteMessages_CountingId",
                table: "RemoteMessages",
                column: "CountingId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteMessages_DestDetailsId",
                table: "RemoteMessages",
                column: "DestDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteMessages_DetailsId",
                table: "RemoteMessages",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteMessages_ManualDepositsId",
                table: "RemoteMessages",
                column: "ManualDepositsId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteMessages_TicketsId",
                table: "RemoteMessages",
                column: "TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketsId",
                table: "Ticket",
                column: "TicketsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BagID");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Cheque");

            migrationBuilder.DropTable(
                name: "Count");

            migrationBuilder.DropTable(
                name: "Counted");

            migrationBuilder.DropTable(
                name: "ManualDeposit");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "RemoteMessages");

            migrationBuilder.DropTable(
                name: "Total");

            migrationBuilder.DropTable(
                name: "CashIn");

            migrationBuilder.DropTable(
                name: "CashOut");

            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "Counting");

            migrationBuilder.DropTable(
                name: "DestDetails");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "ManualDeposits");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Amount");

            migrationBuilder.DropTable(
                name: "Countings");
        }
    }
}
