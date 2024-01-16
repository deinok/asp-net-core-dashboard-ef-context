using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class NetAlarmasTipoRespuestaOrigen : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "Activo",
				table: "NetAlarmasTiposRespuestasOrigenes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldDefaultValueSql: "1");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "Activo",
				table: "NetAlarmasTiposRespuestasOrigenes",
				type: "bit",
				nullable: false,
				defaultValueSql: "1",
				oldClrType: typeof(bool));
		}
	}
}
