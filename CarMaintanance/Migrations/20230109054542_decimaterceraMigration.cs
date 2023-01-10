using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMaintanance.Migrations
{
    /// <inheritdoc />
    public partial class decimaterceraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perfiles_AreaID",
                table: "Perfiles");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_AreaID",
                table: "Perfiles",
                column: "AreaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perfiles_AreaID",
                table: "Perfiles");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_AreaID",
                table: "Perfiles",
                column: "AreaID",
                unique: true);
        }
    }
}
