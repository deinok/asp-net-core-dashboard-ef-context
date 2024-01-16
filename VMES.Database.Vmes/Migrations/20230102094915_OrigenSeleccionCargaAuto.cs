using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class OrigenSeleccionCargaAuto : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "SeleccionCargaAutomatica",
				table: "Origenes",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "SeleccionCargaAutomatica",
				table: "Origenes");
		}
	}
}
