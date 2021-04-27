using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coding_Test.Migrations
{
    public partial class addRefrestTokenToUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 27, 9, 38, 19, 479, DateTimeKind.Local).AddTicks(8013), new DateTime(2021, 4, 27, 9, 38, 19, 480, DateTimeKind.Local).AddTicks(9516) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 27, 9, 38, 19, 500, DateTimeKind.Local).AddTicks(5959), new DateTime(2021, 4, 27, 9, 38, 19, 500, DateTimeKind.Local).AddTicks(6022) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 27, 9, 38, 19, 512, DateTimeKind.Local).AddTicks(3708), new DateTime(2021, 4, 27, 9, 38, 19, 512, DateTimeKind.Local).AddTicks(3746) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 27, 9, 38, 19, 522, DateTimeKind.Local).AddTicks(4025), new DateTime(2021, 4, 27, 9, 38, 19, 522, DateTimeKind.Local).AddTicks(4043) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 27, 9, 38, 19, 532, DateTimeKind.Local).AddTicks(4556), new DateTime(2021, 4, 27, 9, 38, 19, 532, DateTimeKind.Local).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 27, 9, 38, 19, 543, DateTimeKind.Local).AddTicks(9215), new DateTime(2021, 4, 27, 9, 38, 19, 543, DateTimeKind.Local).AddTicks(9261) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 26, 15, 55, 48, 439, DateTimeKind.Local).AddTicks(8644), new DateTime(2021, 4, 26, 15, 55, 48, 442, DateTimeKind.Local).AddTicks(1887) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 26, 15, 55, 48, 493, DateTimeKind.Local).AddTicks(7653), new DateTime(2021, 4, 26, 15, 55, 48, 493, DateTimeKind.Local).AddTicks(7751) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 26, 15, 55, 48, 530, DateTimeKind.Local).AddTicks(8502), new DateTime(2021, 4, 26, 15, 55, 48, 530, DateTimeKind.Local).AddTicks(8565) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 26, 15, 55, 48, 563, DateTimeKind.Local).AddTicks(2810), new DateTime(2021, 4, 26, 15, 55, 48, 563, DateTimeKind.Local).AddTicks(2874) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 26, 15, 55, 48, 597, DateTimeKind.Local).AddTicks(1106), new DateTime(2021, 4, 26, 15, 55, 48, 597, DateTimeKind.Local).AddTicks(1178) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 26, 15, 55, 48, 631, DateTimeKind.Local).AddTicks(4634), new DateTime(2021, 4, 26, 15, 55, 48, 631, DateTimeKind.Local).AddTicks(4695) });
        }
    }
}
