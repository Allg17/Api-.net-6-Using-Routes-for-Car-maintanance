using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class decimaOctabaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Usuarios",
                newName: "FechaModificado");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "SolicitudesHijas",
                newName: "FechaCreado");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Solicitudes",
                newName: "FechaCreado");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Roles",
                newName: "FechaModificado");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Recordatorios",
                newName: "FechaRecordatorio");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Modulos",
                newName: "FechaModificado");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Facturas",
                newName: "FechaCreado");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Areas",
                newName: "FechaModificado");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreado",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificado",
                table: "SolicitudesHijas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificado",
                table: "Solicitudes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreado",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreado",
                table: "Recordatorios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificado",
                table: "Recordatorios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreado",
                table: "PerfilesRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificado",
                table: "PerfilesRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreado",
                table: "PerfilesModulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificado",
                table: "PerfilesModulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreado",
                table: "Perfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificado",
                table: "Perfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreado",
                table: "Modulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificado",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificado",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreado",
                table: "Areas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaModificado",
                table: "SolicitudesHijas");

            migrationBuilder.DropColumn(
                name: "FechaModificado",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "FechaCreado",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "FechaCreado",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "FechaModificado",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "FechaCreado",
                table: "PerfilesRoles");

            migrationBuilder.DropColumn(
                name: "FechaModificado",
                table: "PerfilesRoles");

            migrationBuilder.DropColumn(
                name: "FechaCreado",
                table: "PerfilesModulos");

            migrationBuilder.DropColumn(
                name: "FechaModificado",
                table: "PerfilesModulos");

            migrationBuilder.DropColumn(
                name: "FechaCreado",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "FechaModificado",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "FechaCreado",
                table: "Modulos");

            migrationBuilder.DropColumn(
                name: "FechaModificado",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "FechaModificado",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FechaCreado",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "FechaModificado",
                table: "Usuarios",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "FechaCreado",
                table: "SolicitudesHijas",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "FechaCreado",
                table: "Solicitudes",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "FechaModificado",
                table: "Roles",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "FechaRecordatorio",
                table: "Recordatorios",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "FechaModificado",
                table: "Modulos",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "FechaCreado",
                table: "Facturas",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "FechaModificado",
                table: "Areas",
                newName: "Fecha");
        }
    }
}
