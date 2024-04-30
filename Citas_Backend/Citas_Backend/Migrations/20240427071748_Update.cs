using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citas_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_citas_users_user_id",
                schema: "cita",
                table: "citas");

            migrationBuilder.DropIndex(
                name: "IX_citas_user_id",
                schema: "cita",
                table: "citas");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "cita",
                table: "citas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "cita",
                table: "citas",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_citas_user_id",
                schema: "cita",
                table: "citas",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_citas_users_user_id",
                schema: "cita",
                table: "citas",
                column: "user_id",
                principalSchema: "Security",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
