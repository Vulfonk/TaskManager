using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "User Zero" },
                    { 1, "User One" },
                    { 2, "User Two" }
                    // Добавьте больше пользователей по необходимости
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Level" },
                values: new object[,]
                {
                    { 0, 0 },
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                    // Добавьте больше приоритетов по необходимости
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Title", "Description", "IsCompleted", "DueDate", "PriorityId", "UserId" },
                values: new object[,]
                {
                    { 0, "Task 0", "Description for Task 0", false, DateTime.Now.AddDays(9), 0, 0 },
                    { 1, "Task 1", "Description for Task 1", false, DateTime.Now.AddDays(7), 1, 1 },
                    { 2, "Task 2", "Description for Task 2", false, DateTime.Now.AddDays(3), 2, 2 }
                    // Добавьте больше задач по необходимости
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 0);
            
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 0);
            
            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 0);
            
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
