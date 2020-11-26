using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Targi.Infrastructure.Migrations
{
    public partial class mySQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsCompany = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ContactPerson = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    MaxJobOffers = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyStatus = table.Column<string>(nullable: true),
                    DayOfParticipation = table.Column<string>(nullable: true),
                    NipNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModeratorProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ContactPerson = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeratorProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeratorProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefitCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyProfileId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitCards_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyProfileId = table.Column<Guid>(nullable: false),
                    IsPromoted = table.Column<bool>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    WageLow = table.Column<int>(nullable: false),
                    WageHigh = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    ColorText = table.Column<string>(nullable: true),
                    ColorBackground = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyProfileId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socials_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Webinars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyProfileId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    StartDateOfTheEvent = table.Column<DateTime>(nullable: true),
                    EndDateOfTheEvent = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WebinarUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webinars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Webinars_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CompanyProfileId = table.Column<Guid>(nullable: true),
                    JobOfferId = table.Column<Guid>(nullable: true),
                    WebinarId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photo_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photo_Webinars_WebinarId",
                        column: x => x.WebinarId,
                        principalTable: "Webinars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "IsCompany", "Password", "PasswordSalt", "Role" },
                values: new object[] { new Guid("99094694-8cd9-4a8d-890c-1a2d5de6b396"), new DateTime(2020, 11, 2, 1, 2, 50, 128, DateTimeKind.Local).AddTicks(8785), "admin", true, false, new byte[] { 254, 6, 203, 118, 184, 139, 208, 42, 226, 210, 38, 162, 56, 78, 35, 158, 98, 254, 190, 179, 187, 59, 88, 191, 84, 194, 113, 234, 230, 182, 6, 116, 14, 5, 218, 167, 21, 113, 224, 222, 164, 196, 144, 115, 83, 10, 70, 21, 212, 234, 82, 33, 19, 220, 173, 114, 222, 43, 117, 114, 216, 167, 48, 37 }, new byte[] { 96, 253, 160, 120, 164, 86, 152, 225, 69, 186, 210, 129, 127, 9, 191, 79, 72, 63, 197, 13, 112, 113, 75, 161, 5, 158, 242, 38, 181, 160, 101, 155, 245, 228, 92, 149, 144, 76, 27, 55, 228, 225, 238, 72, 13, 244, 79, 167, 193, 126, 112, 156, 91, 10, 123, 95, 62, 10, 13, 58, 119, 235, 87, 179, 18, 131, 138, 72, 11, 98, 49, 101, 84, 129, 200, 163, 251, 233, 11, 114, 86, 47, 105, 183, 36, 163, 219, 49, 99, 83, 158, 212, 74, 130, 75, 162, 203, 179, 171, 255, 160, 107, 159, 188, 191, 50, 168, 75, 40, 230, 88, 169, 71, 237, 217, 203, 93, 236, 6, 211, 119, 176, 18, 234, 104, 141, 181, 77 }, "admin" });

            migrationBuilder.InsertData(
                table: "ModeratorProfiles",
                columns: new[] { "Id", "ContactPerson", "PhoneNumber", "Position", "UserId" },
                values: new object[] { new Guid("66748671-ef3a-44f6-9334-23d381c95d84"), "Webmastery", "783032065", "admin", new Guid("99094694-8cd9-4a8d-890c-1a2d5de6b396") });

            migrationBuilder.CreateIndex(
                name: "IX_BenefitCards_CompanyProfileId",
                table: "BenefitCards",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_UserId",
                table: "CompanyProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyProfileId",
                table: "JobOffers",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeratorProfiles_UserId",
                table: "ModeratorProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_CompanyProfileId",
                table: "Photo",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_JobOfferId",
                table: "Photo",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_WebinarId",
                table: "Photo",
                column: "WebinarId");

            migrationBuilder.CreateIndex(
                name: "IX_Socials_CompanyProfileId",
                table: "Socials",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Webinars_CompanyProfileId",
                table: "Webinars",
                column: "CompanyProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitCards");

            migrationBuilder.DropTable(
                name: "ModeratorProfiles");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "Webinars");

            migrationBuilder.DropTable(
                name: "CompanyProfiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
