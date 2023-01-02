using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class CuartaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfiles_Roles_RolID",
                table: "Perfiles");

            migrationBuilder.DropIndex(
                name: "IX_Perfiles_RolID",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "RolID",
                table: "Perfiles");

            migrationBuilder.CreateTable(
                name: "PerfilesRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    PerfilID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilesRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PerfilesRoles_Perfiles_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfiles",
                        principalColumn: "PerfilID");
                    table.ForeignKey(
                        name: "FK_PerfilesRoles_Roles_RolID",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "RolID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesRoles_PerfilID",
                table: "PerfilesRoles",
                column: "PerfilID");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesRoles_RolID",
                table: "PerfilesRoles",
                column: "RolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilesRoles");

            migrationBuilder.AddColumn<int>(
                name: "RolID",
                table: "Perfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_RolID",
                table: "Perfiles",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfiles_Roles_RolID",
                table: "Perfiles",
                column: "RolID",
                principalTable: "Roles",
                principalColumn: "RolID");
        }
    }
}
