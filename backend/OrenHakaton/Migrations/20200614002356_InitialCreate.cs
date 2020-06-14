using Microsoft.EntityFrameworkCore.Migrations;

namespace OrenHakaton.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesMC",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesMC", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    PollId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.PollId);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    PollId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.PollId);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpecialityId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    EmployeesMCEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.SpecialityId);
                    table.ForeignKey(
                        name: "FK_Specialties_EmployeesMC_EmployeesMCEmployeeId",
                        column: x => x.EmployeesMCEmployeeId,
                        principalTable: "EmployeesMC",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagementCompanies",
                columns: table => new
                {
                    ManagementCompanyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Yandex = table.Column<string>(nullable: true),
                    Google = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    EmployeesMCEmployeeId = table.Column<int>(nullable: true),
                    MeetingsPollId = table.Column<int>(nullable: true),
                    PollsPollId = table.Column<int>(nullable: true),
                    RequestsRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementCompanies", x => x.ManagementCompanyId);
                    table.ForeignKey(
                        name: "FK_ManagementCompanies_EmployeesMC_EmployeesMCEmployeeId",
                        column: x => x.EmployeesMCEmployeeId,
                        principalTable: "EmployeesMC",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagementCompanies_Meetings_MeetingsPollId",
                        column: x => x.MeetingsPollId,
                        principalTable: "Meetings",
                        principalColumn: "PollId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagementCompanies_Polls_PollsPollId",
                        column: x => x.PollsPollId,
                        principalTable: "Polls",
                        principalColumn: "PollId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagementCompanies_Requests_RequestsRequestId",
                        column: x => x.RequestsRequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(nullable: true),
                    ApartmentsCount = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    ManagementCompaniesManagementCompanyId = table.Column<int>(nullable: true),
                    MeetingsPollId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_Houses_ManagementCompanies_ManagementCompaniesManagementCompanyId",
                        column: x => x.ManagementCompaniesManagementCompanyId,
                        principalTable: "ManagementCompanies",
                        principalColumn: "ManagementCompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Houses_Meetings_MeetingsPollId",
                        column: x => x.MeetingsPollId,
                        principalTable: "Meetings",
                        principalColumn: "PollId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Layout = table.Column<string>(nullable: true),
                    HousesHouseId = table.Column<int>(nullable: true),
                    UsersUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_Apartments_Houses_HousesHouseId",
                        column: x => x.HousesHouseId,
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartments_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_HousesHouseId",
                table: "Apartments",
                column: "HousesHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_UsersUserId",
                table: "Apartments",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_ManagementCompaniesManagementCompanyId",
                table: "Houses",
                column: "ManagementCompaniesManagementCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_MeetingsPollId",
                table: "Houses",
                column: "MeetingsPollId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementCompanies_EmployeesMCEmployeeId",
                table: "ManagementCompanies",
                column: "EmployeesMCEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementCompanies_MeetingsPollId",
                table: "ManagementCompanies",
                column: "MeetingsPollId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementCompanies_PollsPollId",
                table: "ManagementCompanies",
                column: "PollsPollId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementCompanies_RequestsRequestId",
                table: "ManagementCompanies",
                column: "RequestsRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_EmployeesMCEmployeeId",
                table: "Specialties",
                column: "EmployeesMCEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ManagementCompanies");

            migrationBuilder.DropTable(
                name: "EmployeesMC");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
