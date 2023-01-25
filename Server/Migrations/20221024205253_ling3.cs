using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class ling3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Operacao",
                table: "RemoteMessages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operacao",
                table: "RemoteMessages");
        }
    }
}
