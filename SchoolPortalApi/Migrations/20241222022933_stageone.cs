using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPortalApi.Migrations
{
    /// <inheritdoc />
    public partial class stageone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmittedStudents_Registrations_RegistrationApplicantId",
                table: "AdmittedStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_WaitingLists_Registrations_RegistrationApplicantId",
                table: "WaitingLists");

            migrationBuilder.DropIndex(
                name: "IX_WaitingLists_RegistrationApplicantId",
                table: "WaitingLists");

            migrationBuilder.DropIndex(
                name: "IX_AdmittedStudents_RegistrationApplicantId",
                table: "AdmittedStudents");

            migrationBuilder.DropColumn(
                name: "RegistrationApplicantId",
                table: "WaitingLists");

            migrationBuilder.DropColumn(
                name: "RegistrationApplicantId",
                table: "AdmittedStudents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "WaitingLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "AdmittedStudents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatricNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AdmittedStudents_MatricNo",
                        column: x => x.MatricNo,
                        principalTable: "AdmittedStudents",
                        principalColumn: "MatricNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaitingLists_ApplicantId",
                table: "WaitingLists",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmittedStudents_ApplicantId",
                table: "AdmittedStudents",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MatricNo",
                table: "Users",
                column: "MatricNo");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmittedStudents_Registrations_ApplicantId",
                table: "AdmittedStudents",
                column: "ApplicantId",
                principalTable: "Registrations",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingLists_Registrations_ApplicantId",
                table: "WaitingLists",
                column: "ApplicantId",
                principalTable: "Registrations",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmittedStudents_Registrations_ApplicantId",
                table: "AdmittedStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_WaitingLists_Registrations_ApplicantId",
                table: "WaitingLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_WaitingLists_ApplicantId",
                table: "WaitingLists");

            migrationBuilder.DropIndex(
                name: "IX_AdmittedStudents_ApplicantId",
                table: "AdmittedStudents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "WaitingLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationApplicantId",
                table: "WaitingLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "AdmittedStudents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationApplicantId",
                table: "AdmittedStudents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingLists_RegistrationApplicantId",
                table: "WaitingLists",
                column: "RegistrationApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmittedStudents_RegistrationApplicantId",
                table: "AdmittedStudents",
                column: "RegistrationApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmittedStudents_Registrations_RegistrationApplicantId",
                table: "AdmittedStudents",
                column: "RegistrationApplicantId",
                principalTable: "Registrations",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingLists_Registrations_RegistrationApplicantId",
                table: "WaitingLists",
                column: "RegistrationApplicantId",
                principalTable: "Registrations",
                principalColumn: "ApplicantId");
        }
    }
}
