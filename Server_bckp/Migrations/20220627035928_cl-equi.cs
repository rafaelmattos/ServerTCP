using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class clequi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Clientes_ClienteId1",
                table: "Equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_ClienteId1",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "Equipamentos");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Equipamentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_ClienteId",
                table: "Equipamentos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Clientes_ClienteId",
                table: "Equipamentos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Clientes_ClienteId",
                table: "Equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_ClienteId",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Equipamentos");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId1",
                table: "Equipamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_ClienteId1",
                table: "Equipamentos",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Clientes_ClienteId1",
                table: "Equipamentos",
                column: "ClienteId1",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
