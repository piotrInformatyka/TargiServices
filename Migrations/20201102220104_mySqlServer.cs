using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Targi.Infrastructure.Migrations
{
    public partial class mySqlServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModeratorProfiles",
                keyColumn: "Id",
                keyValue: new Guid("66748671-ef3a-44f6-9334-23d381c95d84"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("99094694-8cd9-4a8d-890c-1a2d5de6b396"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "IsCompany", "Password", "PasswordSalt", "Role" },
                values: new object[] { new Guid("0f269511-f64c-4458-824b-57fc0a815ff5"), new DateTime(2020, 11, 2, 23, 1, 3, 841, DateTimeKind.Local).AddTicks(6906), "admin", true, false, new byte[] { 194, 7, 242, 213, 115, 105, 124, 49, 140, 234, 74, 119, 133, 33, 220, 83, 119, 90, 106, 197, 74, 248, 114, 108, 218, 47, 35, 226, 153, 172, 41, 172, 240, 84, 212, 179, 45, 163, 243, 206, 116, 174, 74, 17, 240, 65, 188, 146, 16, 86, 38, 20, 6, 140, 86, 115, 102, 98, 162, 101, 73, 186, 118, 102 }, new byte[] { 37, 206, 66, 133, 52, 35, 33, 54, 213, 20, 201, 62, 215, 177, 91, 242, 190, 16, 174, 89, 255, 232, 114, 60, 88, 91, 175, 141, 40, 94, 97, 140, 167, 216, 189, 124, 185, 50, 243, 229, 165, 3, 154, 243, 88, 126, 224, 34, 25, 117, 63, 19, 99, 23, 18, 12, 119, 61, 37, 190, 178, 110, 64, 166, 104, 162, 25, 129, 40, 89, 252, 60, 3, 59, 24, 41, 192, 191, 223, 165, 231, 232, 124, 150, 105, 232, 39, 247, 28, 29, 188, 10, 176, 234, 61, 197, 251, 95, 155, 250, 196, 56, 219, 26, 210, 179, 185, 38, 47, 167, 114, 195, 200, 198, 244, 19, 15, 31, 45, 69, 197, 133, 182, 43, 250, 254, 82, 210 }, "admin" });

            migrationBuilder.InsertData(
                table: "ModeratorProfiles",
                columns: new[] { "Id", "ContactPerson", "PhoneNumber", "Position", "UserId" },
                values: new object[] { new Guid("3e97e9f5-f618-4889-9921-5e1e8b17ca52"), "Webmastery", "783032065", "admin", new Guid("0f269511-f64c-4458-824b-57fc0a815ff5") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("99094694-8cd9-4a8d-890c-1a2d5de6b396"), new DateTime(2020, 11, 2, 1, 2, 50, 128, DateTimeKind.Local).AddTicks(8785), "admin", true, false, new byte[] { 254, 6, 203, 118, 184, 139, 208, 42, 226, 210, 38, 162, 56, 78, 35, 158, 98, 254, 190, 179, 187, 59, 88, 191, 84, 194, 113, 234, 230, 182, 6, 116, 14, 5, 218, 167, 21, 113, 224, 222, 164, 196, 144, 115, 83, 10, 70, 21, 212, 234, 82, 33, 19, 220, 173, 114, 222, 43, 117, 114, 216, 167, 48, 37 }, new byte[] { 96, 253, 160, 120, 164, 86, 152, 225, 69, 186, 210, 129, 127, 9, 191, 79, 72, 63, 197, 13, 112, 113, 75, 161, 5, 158, 242, 38, 181, 160, 101, 155, 245, 228, 92, 149, 144, 76, 27, 55, 228, 225, 238, 72, 13, 244, 79, 167, 193, 126, 112, 156, 91, 10, 123, 95, 62, 10, 13, 58, 119, 235, 87, 179, 18, 131, 138, 72, 11, 98, 49, 101, 84, 129, 200, 163, 251, 233, 11, 114, 86, 47, 105, 183, 36, 163, 219, 49, 99, 83, 158, 212, 74, 130, 75, 162, 203, 179, 171, 255, 160, 107, 159, 188, 191, 50, 168, 75, 40, 230, 88, 169, 71, 237, 217, 203, 93, 236, 6, 211, 119, 176, 18, 234, 104, 141, 181, 77 }, "admin" });

            migrationBuilder.InsertData(
                table: "ModeratorProfiles",
                columns: new[] { "Id", "ContactPerson", "PhoneNumber", "Position", "UserId" },
                values: new object[] { new Guid("66748671-ef3a-44f6-9334-23d381c95d84"), "Webmastery", "783032065", "admin", new Guid("99094694-8cd9-4a8d-890c-1a2d5de6b396") });
        }
    }
}
