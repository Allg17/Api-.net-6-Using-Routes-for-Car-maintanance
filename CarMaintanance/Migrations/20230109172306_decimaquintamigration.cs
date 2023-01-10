using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class decimaquintamigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Usuarios_UsuarioID",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UsuarioID",
                table: "Roles");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolID",
                table: "Usuarios",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolID",
                table: "Usuarios",
                column: "RolID",
                principalTable: "Roles",
                principalColumn: "RolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolID",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsuarioID",
                table: "Roles",
                column: "UsuarioID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Usuarios_UsuarioID",
                table: "Roles",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID");
        }
    }
}
