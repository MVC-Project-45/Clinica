using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Final.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "age",
                table: "Patients",
                newName: "Age");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Specializations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Specializations");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Patients",
                newName: "age");
        }
    }
}
