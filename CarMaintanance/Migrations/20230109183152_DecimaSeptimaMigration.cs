using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class DecimaSeptimaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesHijas_AreasD_AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas");

            migrationBuilder.DropTable(
                name: "AreasD");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudesHijas_AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas");

            migrationBuilder.DropColumn(
                name: "AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas");

            migrationBuilder.AddColumn<bool>(
                name: "AreaVehicular",
                table: "Areas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaVehicular",
                table: "Areas");

            migrationBuilder.AddColumn<int>(
                name: "AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AreasD",
                columns: table => new
                {
                    AreaDetalleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaID = table.Column<int>(type: "int", nullable: false),
                    SolicitudID = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasD", x => x.AreaDetalleID);
                    table.ForeignKey(
                        name: "FK_AreasD_Areas_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Areas",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreasD_Solicitudes_SolicitudID",
                        column: x => x.SolicitudID,
                        principalTable: "Solicitudes",
                        principalColumn: "SolicitudID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesHijas_AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas",
                column: "AreasDetalleAreaDetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_AreasD_AreaID",
                table: "AreasD",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_AreasD_SolicitudID",
                table: "AreasD",
                column: "SolicitudID");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesHijas_AreasD_AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas",
                column: "AreasDetalleAreaDetalleID",
                principalTable: "AreasD",
                principalColumn: "AreaDetalleID");
        }
    }
}
