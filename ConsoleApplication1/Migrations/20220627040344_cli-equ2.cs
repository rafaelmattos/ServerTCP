using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApplication1.Migrations
{
    public partial class cliequ2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Clientes_ClienteId",
                table: "Equipamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Equipamentos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Clientes_ClienteId",
                table: "Equipamentos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Clientes_ClienteId",
                table: "Equipamentos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
