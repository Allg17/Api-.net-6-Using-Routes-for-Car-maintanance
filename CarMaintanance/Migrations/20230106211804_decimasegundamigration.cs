﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class decimasegundamigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Despachada",
                table: "Solicitudes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Despachada",
                table: "Solicitudes");
        }
    }
}
