using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coding_Test.Migrations
{
    public partial class intialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 26, 15, 55, 48, 439, DateTimeKind.Local).AddTicks(8644), "user1@domain.com", "User 1", "yOUX+/+CqjgLuHYGZrolWyaIBFQ7lLSAZfK7Fpktrdc=", new DateTime(2021, 4, 26, 15, 55, 48, 442, DateTimeKind.Local).AddTicks(1887) },
                    { 2, new DateTime(2021, 4, 26, 15, 55, 48, 493, DateTimeKind.Local).AddTicks(7653), "user2@domain.com", "User 2", "ldLO1Zoa1xlT8VGhdNIjXwCxn9Ff2A1WO0eQ/KiNDmg=", new DateTime(2021, 4, 26, 15, 55, 48, 493, DateTimeKind.Local).AddTicks(7751) },
                    { 3, new DateTime(2021, 4, 26, 15, 55, 48, 530, DateTimeKind.Local).AddTicks(8502), "user3@domain.com", "User 3", "sQel1UcHimuBXpoIRxeQP8pb7CBbddJEybbofCqaccQ=", new DateTime(2021, 4, 26, 15, 55, 48, 530, DateTimeKind.Local).AddTicks(8565) },
                    { 4, new DateTime(2021, 4, 26, 15, 55, 48, 563, DateTimeKind.Local).AddTicks(2810), "user4@domain.com", "User 4", "cbtylFp8cf7v6ehzmPKQSrV7gWakB8lKBx6QIqhlfnA=", new DateTime(2021, 4, 26, 15, 55, 48, 563, DateTimeKind.Local).AddTicks(2874) },
                    { 5, new DateTime(2021, 4, 26, 15, 55, 48, 597, DateTimeKind.Local).AddTicks(1106), "user5@domain.com", "User 5", "QI6wXgRvNrZO/Wiz5WZA25kha9BDjY3lMi4mS1q83/M=", new DateTime(2021, 4, 26, 15, 55, 48, 597, DateTimeKind.Local).AddTicks(1178) },
                    { 6, new DateTime(2021, 4, 26, 15, 55, 48, 631, DateTimeKind.Local).AddTicks(4634), "user6@domain.com", "User 6", "Tor+uPdA34FwwNQtpy3NrbNKYQ1OR+Lhwi4tXVNn6Qs=", new DateTime(2021, 4, 26, 15, 55, 48, 631, DateTimeKind.Local).AddTicks(4695) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
