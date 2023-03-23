using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaria.PedidoAPI.Migrations
{
    public partial class FixPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoBebidas_Bebida_BebidaId",
                table: "PedidoBebidas");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoBebidas_Pedidos_PedidoId",
                table: "PedidoBebidas");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoPizzas_Pedidos_PedidoId",
                table: "PedidoPizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoPizzas_Pizza_PizzaId",
                table: "PedidoPizzas");

            migrationBuilder.DropIndex(
                name: "IX_PedidoPizzas_PedidoId",
                table: "PedidoPizzas");

            migrationBuilder.DropIndex(
                name: "IX_PedidoPizzas_PizzaId",
                table: "PedidoPizzas");

            migrationBuilder.DropIndex(
                name: "IX_PedidoBebidas_BebidaId",
                table: "PedidoBebidas");

            migrationBuilder.DropIndex(
                name: "IX_PedidoBebidas_PedidoId",
                table: "PedidoBebidas");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "PedidoPizzas");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "PedidoPizzas");

            migrationBuilder.DropColumn(
                name: "BebidaId",
                table: "PedidoBebidas");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "PedidoBebidas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "PedidoPizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "PedidoPizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BebidaId",
                table: "PedidoBebidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "PedidoBebidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPizzas_PedidoId",
                table: "PedidoPizzas",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPizzas_PizzaId",
                table: "PedidoPizzas",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoBebidas_BebidaId",
                table: "PedidoBebidas",
                column: "BebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoBebidas_PedidoId",
                table: "PedidoBebidas",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoBebidas_Bebida_BebidaId",
                table: "PedidoBebidas",
                column: "BebidaId",
                principalTable: "Bebida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoBebidas_Pedidos_PedidoId",
                table: "PedidoBebidas",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoPizzas_Pedidos_PedidoId",
                table: "PedidoPizzas",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoPizzas_Pizza_PizzaId",
                table: "PedidoPizzas",
                column: "PizzaId",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
