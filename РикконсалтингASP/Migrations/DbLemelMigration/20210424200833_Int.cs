using Microsoft.EntityFrameworkCore.Migrations;

namespace РикконсалтингASP.Migrations.DbLemelMigration
{
    public partial class Int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ФИОСборное",
                table: "СотрудникиLemel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ФИОСборное",
                table: "СотрудникиLemel");
        }
    }
}
