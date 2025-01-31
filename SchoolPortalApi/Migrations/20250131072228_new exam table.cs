using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPortalApi.Migrations
{
    /// <inheritdoc />
    public partial class newexamtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Examsss",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examsss", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Examsss_Registrations_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Registrations",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examsss_ApplicantId",
                table: "Examsss",
                column: "ApplicantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examsss");
        }
    }
}
