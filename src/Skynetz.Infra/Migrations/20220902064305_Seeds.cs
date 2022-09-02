using Microsoft.EntityFrameworkCore.Migrations;

namespace Skynetz.Infra.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tarifas",
                columns: new[] { "Id", "Destino", "Origem", "TarifaMinuto" },
                values: new object[,]
                {
                    { 1, "016", "011", 1.9m },
                    { 2, "011", "016", 2.9m },
                    { 3, "017", "011", 1.7m },
                    { 4, "011", "017", 2.7m },
                    { 5, "018", "011", 0.9m },
                    { 6, "011", "018", 1.9m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
