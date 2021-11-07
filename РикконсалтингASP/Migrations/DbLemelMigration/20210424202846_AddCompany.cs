using Microsoft.EntityFrameworkCore.Migrations;

namespace РикконсалтингASP.Migrations.DbLemelMigration
{
    public partial class AddCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyLemelId",
                table: "СотрудникиLemel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompanysLemel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanysLemel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_СотрудникиLemel_CompanyLemelId",
                table: "СотрудникиLemel",
                column: "CompanyLemelId");

            migrationBuilder.AddForeignKey(
                name: "FK_СотрудникиLemel_CompanysLemel_CompanyLemelId",
                table: "СотрудникиLemel",
                column: "CompanyLemelId",
                principalTable: "CompanysLemel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_СотрудникиLemel_CompanysLemel_CompanyLemelId",
                table: "СотрудникиLemel");

            migrationBuilder.DropTable(
                name: "CompanysLemel");

            migrationBuilder.DropIndex(
                name: "IX_СотрудникиLemel_CompanyLemelId",
                table: "СотрудникиLemel");

            migrationBuilder.DropColumn(
                name: "CompanyLemelId",
                table: "СотрудникиLemel");
        }
    }
}
