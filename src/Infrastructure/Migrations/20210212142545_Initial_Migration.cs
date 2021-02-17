using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "EndDateTime", "ModifiedAt", "ModifiedBy", "Name", "StartDateTime" },
                values: new object[] { new Guid("04c7ff42-6c43-11eb-9439-0242ac130002"), 1, new DateTime(2021, 2, 12, 15, 25, 44, 963, DateTimeKind.Local).AddTicks(5772), "Frantisek Dolsky", new DateTime(2021, 2, 22, 15, 25, 44, 963, DateTimeKind.Local).AddTicks(4896), new DateTime(2021, 2, 12, 15, 25, 44, 963, DateTimeKind.Local).AddTicks(8561), "Frantisek Dolsky", "Seeded Task 1", new DateTime(2021, 2, 12, 15, 25, 44, 959, DateTimeKind.Local).AddTicks(2526) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");
        }
    }
}
