using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class DecimaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Facturada",
                table: "Solicitudes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facturada",
                table: "Solicitudes");
        }
    }
}
