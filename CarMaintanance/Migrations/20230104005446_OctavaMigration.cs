using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class OctavaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasD_Solicitudes_SolicitudID",
                table: "AreasD");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasD_Solicitudes_SolicitudID",
                table: "AreasD",
                column: "SolicitudID",
                principalTable: "Solicitudes",
                principalColumn: "SolicitudID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasD_Solicitudes_SolicitudID",
                table: "AreasD");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasD_Solicitudes_SolicitudID",
                table: "AreasD",
                column: "SolicitudID",
                principalTable: "Solicitudes",
                principalColumn: "SolicitudID");
        }
    }
}
