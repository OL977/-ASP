using Microsoft.EntityFrameworkCore.Migrations;

namespace РикконсалтингASP.Migrations.DbLemelMigration
{
    public partial class AddIDSotrРик : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDSotrРик",
                table: "СотрудникиLemel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDSotrРик",
                table: "СотрудникиLemel");
        }
    }
}
