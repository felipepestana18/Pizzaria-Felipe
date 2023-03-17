using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaria.BebidaAPI.Migrations
{
    public partial class FixColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Bebidas",
                newName: "Fornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fornecedor",
                table: "Bebidas",
                newName: "Marca");
        }
    }
}
