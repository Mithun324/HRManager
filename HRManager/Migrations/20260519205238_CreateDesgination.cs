using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManager.Migrations
{
    /// <inheritdoc />
    public partial class CreateDesgination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationInformation_Employees_EmployeeId",
                table: "EducationInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationInformation",
                table: "EducationInformation");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "EmploymentDetails");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "EducationInformation");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "EducationInformation");

            migrationBuilder.RenameTable(
                name: "EducationInformation",
                newName: "EducationInformations");

            migrationBuilder.RenameColumn(
                name: "JoinDesignation",
                table: "EmploymentDetails",
                newName: "Shift");

            migrationBuilder.RenameColumn(
                name: "EmployeeStatus",
                table: "EmploymentDetails",
                newName: "Designation");

            migrationBuilder.RenameColumn(
                name: "MajorGroup",
                table: "EducationInformations",
                newName: "Institution");

            migrationBuilder.RenameColumn(
                name: "InstitutionName",
                table: "EducationInformations",
                newName: "DegreeName");

            migrationBuilder.RenameIndex(
                name: "IX_EducationInformation_EmployeeId",
                table: "EducationInformations",
                newName: "IX_EducationInformations_EmployeeId");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "AddressInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AddressInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationInformations",
                table: "EducationInformations",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationInformations_Employees_EmployeeId",
                table: "EducationInformations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationInformations_Employees_EmployeeId",
                table: "EducationInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationInformations",
                table: "EducationInformations");

            migrationBuilder.DropColumn(
                name: "AddressLine",
                table: "AddressInformations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AddressInformations");

            migrationBuilder.RenameTable(
                name: "EducationInformations",
                newName: "EducationInformation");

            migrationBuilder.RenameColumn(
                name: "Shift",
                table: "EmploymentDetails",
                newName: "JoinDesignation");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "EmploymentDetails",
                newName: "EmployeeStatus");

            migrationBuilder.RenameColumn(
                name: "Institution",
                table: "EducationInformation",
                newName: "MajorGroup");

            migrationBuilder.RenameColumn(
                name: "DegreeName",
                table: "EducationInformation",
                newName: "InstitutionName");

            migrationBuilder.RenameIndex(
                name: "IX_EducationInformations_EmployeeId",
                table: "EducationInformation",
                newName: "IX_EducationInformation_EmployeeId");

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "EmploymentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "EducationInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "EducationInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationInformation",
                table: "EducationInformation",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationInformation_Employees_EmployeeId",
                table: "EducationInformation",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
