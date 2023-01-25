using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApplication1.Migrations
{
    public partial class altercacoesticket3incluindoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketsId",
                table: "RemoteMessages",
                nullable: true);

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
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateIndex(
                name: "IX_RemoteMessages_TicketsId",
                table: "RemoteMessages",
                column: "TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketsId",
                table: "Ticket",
                column: "TicketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RemoteMessages_Tickets_TicketsId",
                table: "RemoteMessages",
                column: "TicketsId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RemoteMessages_Tickets_TicketsId",
                table: "RemoteMessages");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_RemoteMessages_TicketsId",
                table: "RemoteMessages");

            migrationBuilder.DropColumn(
                name: "TicketsId",
                table: "RemoteMessages");
        }
    }
}
