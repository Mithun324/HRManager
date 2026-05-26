using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeNavigations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BicSwiftCode",
                table: "BankingInformation");

            migrationBuilder.RenameColumn(
                name: "EmployerWebsite",
                table: "WorkExperience",
                newName: "PreviousEmployerWebsite");

            migrationBuilder.RenameColumn(
                name: "EmployerName",
                table: "WorkExperience",
                newName: "PreviousEmployerName");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "WorkExperience",
                newName: "PreviousEmployerLocation");

            migrationBuilder.RenameColumn(
                name: "eTin",
                table: "TaxInformations",
                newName: "ETin");

            migrationBuilder.RenameColumn(
                name: "Nid",
                table: "SpouseInformation",
                newName: "NID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SpouseInformation",
                newName: "SpouseName");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                table: "SpouseInformation",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "MotherNid",
                table: "ParentInformations",
                newName: "MotherNID");

            migrationBuilder.RenameColumn(
                name: "FatherNid",
                table: "ParentInformations",
                newName: "FatherNID");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                table: "EmergencyContact",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "Institution",
                table: "EducationInformations",
                newName: "MajorGroup");

            migrationBuilder.RenameColumn(
                name: "DateOfExpiry",
                table: "DrivingLicenses",
                newName: "DateOfExpair");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ChildInformation",
                newName: "ChildName");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentEndDate",
                table: "WorkExperience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentStartDate",
                table: "WorkExperience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousDesignation",
                table: "WorkExperience",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkExperienceId",
                table: "WorkExperience",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TrainingName",
                table: "TrainingInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PortfolioUrl",
                table: "SocialMediaInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "EmploymentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeStatus",
                table: "EmploymentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JoinDesignation",
                table: "EmploymentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "EducationInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "EducationInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstitutionName",
                table: "EducationInformations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentEndDate",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "EmploymentStartDate",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "PreviousDesignation",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "WorkExperienceId",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "TrainingName",
                table: "TrainingInformation");

            migrationBuilder.DropColumn(
                name: "PortfolioUrl",
                table: "SocialMediaInformations");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "EmploymentDetails");

            migrationBuilder.DropColumn(
                name: "EmployeeStatus",
                table: "EmploymentDetails");

            migrationBuilder.DropColumn(
                name: "JoinDesignation",
                table: "EmploymentDetails");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "EducationInformations");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "EducationInformations");

            migrationBuilder.DropColumn(
                name: "InstitutionName",
                table: "EducationInformations");

            migrationBuilder.RenameColumn(
                name: "PreviousEmployerWebsite",
                table: "WorkExperience",
                newName: "EmployerWebsite");

            migrationBuilder.RenameColumn(
                name: "PreviousEmployerName",
                table: "WorkExperience",
                newName: "EmployerName");

            migrationBuilder.RenameColumn(
                name: "PreviousEmployerLocation",
                table: "WorkExperience",
                newName: "Designation");

            migrationBuilder.RenameColumn(
                name: "ETin",
                table: "TaxInformations",
                newName: "eTin");

            migrationBuilder.RenameColumn(
                name: "NID",
                table: "SpouseInformation",
                newName: "Nid");

            migrationBuilder.RenameColumn(
                name: "SpouseName",
                table: "SpouseInformation",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "SpouseInformation",
                newName: "ContactNo");

            migrationBuilder.RenameColumn(
                name: "MotherNID",
                table: "ParentInformations",
                newName: "MotherNid");

            migrationBuilder.RenameColumn(
                name: "FatherNID",
                table: "ParentInformations",
                newName: "FatherNid");

            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "EmergencyContact",
                newName: "ContactNo");

            migrationBuilder.RenameColumn(
                name: "MajorGroup",
                table: "EducationInformations",
                newName: "Institution");

            migrationBuilder.RenameColumn(
                name: "DateOfExpair",
                table: "DrivingLicenses",
                newName: "DateOfExpiry");

            migrationBuilder.RenameColumn(
                name: "ChildName",
                table: "ChildInformation",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "BicSwiftCode",
                table: "BankingInformation",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
