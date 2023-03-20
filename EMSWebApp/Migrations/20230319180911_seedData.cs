using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSWebApp.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[] { 19, "default1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Phone", "departmentId", "dob", "email" },
                values: new object[] { 22, "default1", "09194324567", 2, new DateTime(2023, 3, 21, 2, 9, 11, 287, DateTimeKind.Local).AddTicks(208), "defaultemail@email.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
