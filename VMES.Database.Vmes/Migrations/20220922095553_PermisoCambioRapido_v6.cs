using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class PermisoCambioRapido_v6 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "CambioRapidoOPC",
				table: "UsuariosRoles",
				nullable: true,
				defaultValueSql: "((0))",
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "CambioRapidoOPC",
				table: "UsuariosRoles",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool),
				oldNullable: true,
				oldDefaultValueSql: "((0))");
		}
	}
}
