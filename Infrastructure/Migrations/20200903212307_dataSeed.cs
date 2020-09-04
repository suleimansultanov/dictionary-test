using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class dataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Русский" },
                    { 2, "Английский" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "Original", "OriginalId", "Translate", "TranslateId" },
                values: new object[,]
                {
                    { 1, "Movie", 1, "Фильм", 2 },
                    { 2, "Дом", 1, "House", 2 },
                    { 3, "Ручка", 1, "Pencil", 2 },
                    { 4, "Игрушка", 1, "Toy", 2 },
                    { 5, "Машина", 1, "Car", 2 },
                    { 6, "Книга", 1, "Book", 2 },
                    { 7, "Лес", 1, "Forest", 2 },
                    { 8, "Крыша", 1, "Roof", 2 },
                    { 9, "Chicken", 2, "Курица", 1 },
                    { 10, "Stairway", 2, "Лестница", 1 },
                    { 11, "Star", 2, "Звезда", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
