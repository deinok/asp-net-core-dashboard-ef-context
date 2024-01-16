using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ModuloPermitirPausarPermitirReanudar : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "PermitirPausar",
				table: "Modulos",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "PermitirReanudar",
				table: "Modulos",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PermitirPausar",
				table: "Modulos");

			migrationBuilder.DropColumn(
				name: "PermitirReanudar",
				table: "Modulos");
		}
	}
}
