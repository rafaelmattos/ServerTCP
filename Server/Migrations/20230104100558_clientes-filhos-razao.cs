using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class clientesfilhosrazao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientePaiId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ClientePaiId",
                table: "Clientes",
                column: "ClientePaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Clientes_ClientePaiId",
                table: "Clientes",
                column: "ClientePaiId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Clientes_ClientePaiId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ClientePaiId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClientePaiId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Clientes");
        }
    }
}
