using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class SeptimaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasD_Areas_AreaID",
                table: "AreasD");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesHijas_AreasD_AreaDetalleID",
                table: "SolicitudesHijas");

            migrationBuilder.RenameColumn(
                name: "AreaDetalleID",
                table: "SolicitudesHijas",
                newName: "AreaID");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudesHijas_AreaDetalleID",
                table: "SolicitudesHijas",
                newName: "IX_SolicitudesHijas_AreaID");

            migrationBuilder.AddColumn<int>(
                name: "AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesHijas_AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas",
                column: "AreasDetalleAreaDetalleID");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasD_Areas_AreaID",
                table: "AreasD",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesHijas_AreasD_AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas",
                column: "AreasDetalleAreaDetalleID",
                principalTable: "AreasD",
                principalColumn: "AreaDetalleID");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesHijas_Areas_AreaID",
                table: "SolicitudesHijas",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasD_Areas_AreaID",
                table: "AreasD");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesHijas_AreasD_AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesHijas_Areas_AreaID",
                table: "SolicitudesHijas");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudesHijas_AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas");

            migrationBuilder.DropColumn(
                name: "AreasDetalleAreaDetalleID",
                table: "SolicitudesHijas");

            migrationBuilder.RenameColumn(
                name: "AreaID",
                table: "SolicitudesHijas",
                newName: "AreaDetalleID");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudesHijas_AreaID",
                table: "SolicitudesHijas",
                newName: "IX_SolicitudesHijas_AreaDetalleID");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasD_Areas_AreaID",
                table: "AreasD",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesHijas_AreasD_AreaDetalleID",
                table: "SolicitudesHijas",
                column: "AreaDetalleID",
                principalTable: "AreasD",
                principalColumn: "AreaDetalleID");
        }
    }
}
