using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class PermisoCambioRapido_v2 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "CambioRapidoOPC",
				table: "UsuariosRoles",
			nullable: true);

			migrationBuilder.Sql($@"
				UPDATE UsuariosRoles SET CambioRapidoOPC = 0 WHERE CambioRapidoOPC IS NULL
			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "CambioRapidoOPC",
				table: "UsuariosRoles");
		}
	}
}
