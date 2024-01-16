using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ModulosIgnorarConsumidosProducidos : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "IgnorarConsumidos",
				table: "Modulos",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "IgnorarProducidos",
				table: "Modulos",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "IgnorarConsumidos",
				table: "Modulos");

			migrationBuilder.DropColumn(
				name: "IgnorarProducidos",
				table: "Modulos");
		}
	}
}
