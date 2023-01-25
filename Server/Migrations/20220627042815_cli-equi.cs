using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class cliequi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Clientes_ClienteId",
                table: "Equipamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Equipamentos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Equipamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Clientes_ClienteId",
                table: "Equipamentos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
