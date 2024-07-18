using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class SeedPriorities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Level", "Id" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Level", "Id" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Level", "Id" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Level",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Level",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Level",
                keyValue: 3);
        }
    }

}
