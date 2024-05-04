using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citas_Backend.Migrations.LogDb
{
    /// <inheritdoc />
    public partial class FieldUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "detalle",
                table: "log");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "log",
                newName: "usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "usuario",
                table: "log",
                newName: "user_id");

            migrationBuilder.AddColumn<string>(
                name: "detalle",
                table: "log",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
