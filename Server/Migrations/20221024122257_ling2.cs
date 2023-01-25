using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class ling2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Linguagens",
                columns: table => new
                {
                    En = table.Column<string>(nullable: false),
                    Pt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linguagens", x => x.En);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Linguagens");
        }
    }
}
