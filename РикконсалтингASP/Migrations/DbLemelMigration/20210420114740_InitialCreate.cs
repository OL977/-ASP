using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace РикконсалтингASP.Migrations.DbLemelMigration
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "СотрудникиLemel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Имя = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Фамилия = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Отчество = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Организация = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Пользователь = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Роль = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ДатаИзменения = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_СотрудникиLemel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "СотрудникиLemel");
        }
    }
}
