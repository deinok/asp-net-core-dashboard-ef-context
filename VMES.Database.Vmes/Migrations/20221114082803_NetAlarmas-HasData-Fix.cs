using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class NetAlarmasHasDataFix : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.UpdateData(
				table: "NetAlarmasTipos",
				keyColumn: "Id",
				keyValue: 2050,
				column: "TextoError",
				value: "Comprobacion Origen Vacio");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.UpdateData(
				table: "NetAlarmasTipos",
				keyColumn: "Id",
				keyValue: 2050,
				column: "TextoError",
				value: "Comprovacion Origen Vacio");
		}
	}
}
