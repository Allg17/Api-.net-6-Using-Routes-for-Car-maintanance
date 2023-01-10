using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class decimasextamigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modulos_Perfiles_PerfilID",
                table: "Modulos");

            migrationBuilder.DropIndex(
                name: "IX_Modulos_PerfilID",
                table: "Modulos");

            migrationBuilder.DropColumn(
                name: "Crear_Editar",
                table: "Modulos");

            migrationBuilder.DropColumn(
                name: "Eliminar",
                table: "Modulos");

            migrationBuilder.DropColumn(
                name: "PerfilID",
                table: "Modulos");

            migrationBuilder.DropColumn(
                name: "Ver",
                table: "Modulos");

            migrationBuilder.CreateTable(
                name: "PerfilesModulos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuloID = table.Column<int>(type: "int", nullable: false),
                    PerfilID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilesModulos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PerfilesModulos_Modulos_ModuloID",
                        column: x => x.ModuloID,
                        principalTable: "Modulos",
                        principalColumn: "ModuloId");
                    table.ForeignKey(
                        name: "FK_PerfilesModulos_Perfiles_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfiles",
                        principalColumn: "PerfilID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesModulos_ModuloID",
                table: "PerfilesModulos",
                column: "ModuloID");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesModulos_PerfilID",
                table: "PerfilesModulos",
                column: "PerfilID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilesModulos");

            migrationBuilder.AddColumn<bool>(
                name: "Crear_Editar",
                table: "Modulos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminar",
                table: "Modulos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PerfilID",
                table: "Modulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Ver",
                table: "Modulos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_PerfilID",
                table: "Modulos",
                column: "PerfilID");

            migrationBuilder.AddForeignKey(
                name: "FK_Modulos_Perfiles_PerfilID",
                table: "Modulos",
                column: "PerfilID",
                principalTable: "Perfiles",
                principalColumn: "PerfilID");
        }
    }
}
