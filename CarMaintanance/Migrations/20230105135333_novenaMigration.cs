using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class novenaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_ClienteID",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_ClienteID",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "ClienteID",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Facturas");

            migrationBuilder.AddColumn<int>(
                name: "ClientesClienteID",
                table: "Facturas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClientesClienteID",
                table: "Facturas",
                column: "ClientesClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_ClientesClienteID",
                table: "Facturas",
                column: "ClientesClienteID",
                principalTable: "Clientes",
                principalColumn: "ClienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_ClientesClienteID",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_ClientesClienteID",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "ClientesClienteID",
                table: "Facturas");

            migrationBuilder.AddColumn<int>(
                name: "ClienteID",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "Facturas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteID",
                table: "Facturas",
                column: "ClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_ClienteID",
                table: "Facturas",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ClienteID");
        }
    }
}
