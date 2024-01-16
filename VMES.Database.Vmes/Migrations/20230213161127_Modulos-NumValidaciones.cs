using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ModulosNumValidaciones : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "NumValidaciones",
				table: "Modulos",
				nullable: false,
				defaultValueSql: "20");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "NumValidaciones",
				table: "Modulos");
		}
	}
}
