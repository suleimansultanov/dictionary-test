using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class wordsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "Original", "OriginalId", "Translate", "TranslateId" },
                values: new object[,]
                {
                    { 12, "Nightmare", 2, "Кошмар", 1 },
                    { 13, "Улица", 1, "Street", 2 },
                    { 14, "Вес", 1, "Weight", 2 },
                    { 15, "Коробка", 1, "Box", 2 },
                    { 16, "Бомба", 1, "Bomb", 2 },
                    { 17, "Wood", 2, "Дерево", 1 },
                    { 18, "Carpet", 2, "Ковер", 1 },
                    { 19, "Dog", 2, "Собака", 1 },
                    { 20, "Circle", 2, "Круг", 1 },
                    { 21, "Wave", 2, "Волна", 1 },
                    { 22, "Здание", 2, "Building", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
