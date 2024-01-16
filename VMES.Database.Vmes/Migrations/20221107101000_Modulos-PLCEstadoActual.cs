using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ModulosPLCEstadoActual : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("UPDATE [Modulos] SET [PLCEstadoActual] = 0 WHERE [PLCEstadoActual] IS NULL;");
			migrationBuilder.AlterColumn<int>(
				name: "PLCEstadoActual",
				table: "Modulos",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "PLCEstadoActual",
				table: "Modulos",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));
		}
	}
}
