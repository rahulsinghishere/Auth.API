using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auth.API.Migrations
{
    /// <inheritdoc />
    public partial class authtables10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRegistrationSource",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "615bf74e-bc0b-4fb5-9799-54c4fc7348f0", null, "ApplicationUserRole", "Administrator", "ADMINISTRATOR" },
                    { "c0e24792-e74a-454d-88e7-af9f57f2cd78", null, "ApplicationUserRole", "Other", "OTHER" },
                    { "db529793-24c9-48de-a84f-9483b5cf98cb", null, "ApplicationUserRole", "Host", "HOST" },
                    { "e9466dc7-21ec-40f1-8ed9-220564fc43f9", null, "ApplicationUserRole", "Guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "615bf74e-bc0b-4fb5-9799-54c4fc7348f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0e24792-e74a-454d-88e7-af9f57f2cd78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db529793-24c9-48de-a84f-9483b5cf98cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9466dc7-21ec-40f1-8ed9-220564fc43f9");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserRegistrationSource",
                table: "AspNetUsers");

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
    }
}
