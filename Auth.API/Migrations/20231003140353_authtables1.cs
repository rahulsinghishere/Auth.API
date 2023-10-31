using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auth.API.Migrations
{
    /// <inheritdoc />
    public partial class authtables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "059fb75e-d3d4-492c-a3e6-048da596cf9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30f07a8a-a9d7-4ca9-abf8-dfe2e5d9e91c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3589f5-4985-4e2f-8dec-b7ed430d2620");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a87ddaf-c9c1-4be9-8d53-ec04ef86ba9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12f817b2-ccd5-4e24-bb25-c4a7a4a0127e", null, "ApplicationUserRole", "Other", "OTHER" },
                    { "75370e13-8b4e-4285-89f9-711a39ae4339", null, "ApplicationUserRole", "Guest", "GUEST" },
                    { "aac58de1-2ca9-4206-9284-3f6d3b588ca3", null, "ApplicationUserRole", "Administrator", "ADMINISTRATOR" },
                    { "e55507ad-83fc-45b2-ad98-939a532c0031", null, "ApplicationUserRole", "Host", "HOST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12f817b2-ccd5-4e24-bb25-c4a7a4a0127e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75370e13-8b4e-4285-89f9-711a39ae4339");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aac58de1-2ca9-4206-9284-3f6d3b588ca3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e55507ad-83fc-45b2-ad98-939a532c0031");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "059fb75e-d3d4-492c-a3e6-048da596cf9c", null, "ApplicationUserRole", "Administrator", null },
                    { "30f07a8a-a9d7-4ca9-abf8-dfe2e5d9e91c", null, "ApplicationUserRole", "Guest", null },
                    { "4d3589f5-4985-4e2f-8dec-b7ed430d2620", null, "ApplicationUserRole", "Host", null },
                    { "7a87ddaf-c9c1-4be9-8d53-ec04ef86ba9d", null, "ApplicationUserRole", "Other", null }
                });
        }
    }
}
