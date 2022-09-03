using Microsoft.EntityFrameworkCore.Migrations;

namespace Skynetz.Infra.Migrations
{
    public partial class SettingPrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Plano",
                table: "Plano");

            migrationBuilder.RenameTable(
                name: "Plano",
                newName: "Planos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planos",
                table: "Planos",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Planos",
                table: "Planos");

            migrationBuilder.RenameTable(
                name: "Planos",
                newName: "Plano");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plano",
                table: "Plano",
                column: "Id");
        }
    }
}
