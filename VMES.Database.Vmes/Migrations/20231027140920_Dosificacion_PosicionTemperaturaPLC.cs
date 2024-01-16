using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class Dosificacion_PosicionTemperaturaPLC : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "PosicionTemperaturaPLC",
				table: "Dosificaciones",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PosicionTemperaturaPLC",
				table: "Dosificaciones");
		}
	}
}
