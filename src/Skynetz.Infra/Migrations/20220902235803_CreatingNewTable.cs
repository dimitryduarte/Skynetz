using Microsoft.EntityFrameworkCore.Migrations;

namespace Skynetz.Infra.Migrations
{
    public partial class CreatingNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Minutos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Plano",
                columns: new[] { "Id", "Minutos", "Nome" },
                values: new object[] { 1, 30, "FaleMais 30" });

            migrationBuilder.InsertData(
                table: "Plano",
                columns: new[] { "Id", "Minutos", "Nome" },
                values: new object[] { 2, 60, "FaleMais 60" });

            migrationBuilder.InsertData(
                table: "Plano",
                columns: new[] { "Id", "Minutos", "Nome" },
                values: new object[] { 3, 120, "FaleMais 120" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plano");
        }
    }
}
