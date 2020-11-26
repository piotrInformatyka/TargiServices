using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Targi.Infrastructure.Migrations
{
    public partial class extendJobOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModeratorProfiles",
                keyColumn: "Id",
                keyValue: new Guid("3e97e9f5-f618-4889-9921-5e1e8b17ca52"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0f269511-f64c-4458-824b-57fc0a815ff5"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "IsCompany", "Password", "PasswordSalt", "Role" },
                values: new object[] { new Guid("7ed40d3c-bcc6-458e-a4ac-a944269f7287"), new DateTime(2020, 11, 4, 22, 43, 4, 611, DateTimeKind.Local).AddTicks(8283), "admin", true, false, new byte[] { 129, 218, 128, 134, 34, 47, 57, 78, 216, 36, 62, 210, 112, 33, 156, 97, 120, 212, 134, 60, 175, 175, 214, 163, 99, 37, 90, 91, 108, 93, 82, 29, 199, 120, 22, 215, 209, 48, 218, 56, 142, 39, 115, 199, 202, 70, 27, 194, 143, 62, 15, 26, 245, 76, 132, 118, 2, 118, 37, 154, 223, 182, 133, 117 }, new byte[] { 220, 247, 149, 209, 209, 192, 169, 34, 173, 70, 61, 79, 36, 142, 110, 233, 2, 124, 60, 143, 35, 169, 3, 50, 122, 248, 8, 97, 81, 170, 84, 77, 22, 57, 161, 35, 120, 9, 242, 220, 56, 250, 164, 221, 212, 0, 63, 104, 149, 121, 221, 214, 77, 57, 185, 51, 6, 27, 0, 250, 161, 217, 48, 44, 67, 63, 148, 233, 228, 50, 216, 116, 232, 29, 98, 250, 119, 110, 102, 38, 40, 202, 76, 152, 163, 163, 74, 79, 120, 213, 131, 123, 8, 176, 234, 227, 75, 155, 70, 165, 119, 107, 73, 231, 125, 234, 58, 155, 227, 72, 47, 20, 143, 137, 131, 32, 28, 251, 100, 17, 45, 51, 25, 193, 39, 31, 59, 205 }, "admin" });

            migrationBuilder.InsertData(
                table: "ModeratorProfiles",
                columns: new[] { "Id", "ContactPerson", "PhoneNumber", "Position", "UserId" },
                values: new object[] { new Guid("69dcffbe-4de9-458f-93fb-4cd33517ec08"), "Webmastery", "783032065", "admin", new Guid("7ed40d3c-bcc6-458e-a4ac-a944269f7287") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModeratorProfiles",
                keyColumn: "Id",
                keyValue: new Guid("69dcffbe-4de9-458f-93fb-4cd33517ec08"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7ed40d3c-bcc6-458e-a4ac-a944269f7287"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "IsCompany", "Password", "PasswordSalt", "Role" },
                values: new object[] { new Guid("0f269511-f64c-4458-824b-57fc0a815ff5"), new DateTime(2020, 11, 2, 23, 1, 3, 841, DateTimeKind.Local).AddTicks(6906), "admin", true, false, new byte[] { 194, 7, 242, 213, 115, 105, 124, 49, 140, 234, 74, 119, 133, 33, 220, 83, 119, 90, 106, 197, 74, 248, 114, 108, 218, 47, 35, 226, 153, 172, 41, 172, 240, 84, 212, 179, 45, 163, 243, 206, 116, 174, 74, 17, 240, 65, 188, 146, 16, 86, 38, 20, 6, 140, 86, 115, 102, 98, 162, 101, 73, 186, 118, 102 }, new byte[] { 37, 206, 66, 133, 52, 35, 33, 54, 213, 20, 201, 62, 215, 177, 91, 242, 190, 16, 174, 89, 255, 232, 114, 60, 88, 91, 175, 141, 40, 94, 97, 140, 167, 216, 189, 124, 185, 50, 243, 229, 165, 3, 154, 243, 88, 126, 224, 34, 25, 117, 63, 19, 99, 23, 18, 12, 119, 61, 37, 190, 178, 110, 64, 166, 104, 162, 25, 129, 40, 89, 252, 60, 3, 59, 24, 41, 192, 191, 223, 165, 231, 232, 124, 150, 105, 232, 39, 247, 28, 29, 188, 10, 176, 234, 61, 197, 251, 95, 155, 250, 196, 56, 219, 26, 210, 179, 185, 38, 47, 167, 114, 195, 200, 198, 244, 19, 15, 31, 45, 69, 197, 133, 182, 43, 250, 254, 82, 210 }, "admin" });

            migrationBuilder.InsertData(
                table: "ModeratorProfiles",
                columns: new[] { "Id", "ContactPerson", "PhoneNumber", "Position", "UserId" },
                values: new object[] { new Guid("3e97e9f5-f618-4889-9921-5e1e8b17ca52"), "Webmastery", "783032065", "admin", new Guid("0f269511-f64c-4458-824b-57fc0a815ff5") });
        }
    }
}
