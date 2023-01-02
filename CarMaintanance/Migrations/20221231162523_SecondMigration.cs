using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perfiles_RolID",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "PerfilID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Crear_Editar",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "Eliminar",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "Modulo",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "Ver",
                table: "Perfiles");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    ModuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrearEditar = table.Column<bool>(name: "Crear_Editar", type: "bit", nullable: false),
                    Eliminar = table.Column<bool>(type: "bit", nullable: false),
                    Ver = table.Column<bool>(type: "bit", nullable: false),
                    PerfilID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.ModuloId);
                    table.ForeignKey(
                        name: "FK_Modulos_Perfiles_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfiles",
                        principalColumn: "PerfilID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_RolID",
                table: "Perfiles",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_PerfilID",
                table: "Modulos",
                column: "PerfilID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropIndex(
                name: "IX_Perfiles_RolID",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "PerfilID",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Crear_Editar",
                table: "Perfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminar",
                table: "Perfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Modulo",
                table: "Perfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Ver",
                table: "Perfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_RolID",
                table: "Perfiles",
                column: "RolID",
                unique: true);
        }
    }
}
