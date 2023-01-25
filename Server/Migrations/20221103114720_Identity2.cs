using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Identity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
