using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPortalApi.Migrations
{
    /// <inheritdoc />
    public partial class reg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolAddress",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondarySchool",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolAddress",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "SecondarySchool",
                table: "Registrations");
        }
    }
}
