using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class OrdenesTransicionesEstadosHistory_InicioValidez_DEFAULT : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "InicioValidez",
				table: "OrdenesTransicionEstadosHistory",
				nullable: false,
				defaultValueSql: "(getdate())",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "InicioValidez",
				table: "OrdenesTransicionEstadosHistory",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldDefaultValueSql: "(getdate())");
		}
	}
}
