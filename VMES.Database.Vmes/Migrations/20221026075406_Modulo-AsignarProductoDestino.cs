using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ModuloAsignarProductoDestino : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "AsignarProductoDestino",
				table: "Modulos",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "VolteoHabilitarLlenarDestino",
				table: "Modulos",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "VolteoHabilitarVaciarOrigen",
				table: "Modulos",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "AsignarProductoDestino",
				table: "Modulos");

			migrationBuilder.DropColumn(
				name: "VolteoHabilitarLlenarDestino",
				table: "Modulos");

			migrationBuilder.DropColumn(
				name: "VolteoHabilitarVaciarOrigen",
				table: "Modulos");
		}
	}
}
