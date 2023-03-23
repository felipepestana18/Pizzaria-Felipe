using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaria.PedidoAPI.Migrations
{
    public partial class FixIdCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Pedidos");
        }
    }
}
