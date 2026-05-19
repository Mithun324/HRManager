using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthIdentificationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TINNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "AddressInformations",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Union = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockSector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseVillage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoadNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressInformations", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_AddressInformations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentDetails",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDesignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentDetails", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmploymentDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParentInformations",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FathersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FathersNID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FathersPassportNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FathersMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MothersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MothersNID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MothersPassportNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MothersMobile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentInformations", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_ParentInformations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaInformations",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LinkedInProfileURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookProfileURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitHubProfileURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalWebsiteURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaInformations", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_SocialMediaInformations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressInformations");

            migrationBuilder.DropTable(
                name: "EmploymentDetails");

            migrationBuilder.DropTable(
                name: "ParentInformations");

            migrationBuilder.DropTable(
                name: "SocialMediaInformations");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
