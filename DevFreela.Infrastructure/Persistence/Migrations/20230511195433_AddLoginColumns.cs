using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "user");
        }
    }
}
