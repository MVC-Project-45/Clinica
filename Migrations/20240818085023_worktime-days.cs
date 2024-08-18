using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Final.Migrations
{
    /// <inheritdoc />
    public partial class worktimedays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "WorkingTime",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "WorkingTime");
        }
    }
}
