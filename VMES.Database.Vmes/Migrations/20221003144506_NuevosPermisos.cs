using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class NuevosPermisos : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "Alertas",
				table: "UsuariosRoles",
				nullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "DashboardEditar",
				table: "UsuariosRoles",
				nullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "LayoutMaximizar",
				table: "UsuariosRoles",
				nullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "ResetComunicaciones",
				table: "UsuariosRoles",
				nullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "SMTP",
				table: "UsuariosRoles",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Alertas",
				table: "UsuariosRoles");

			migrationBuilder.DropColumn(
				name: "DashboardEditar",
				table: "UsuariosRoles");

			migrationBuilder.DropColumn(
				name: "LayoutMaximizar",
				table: "UsuariosRoles");

			migrationBuilder.DropColumn(
				name: "ResetComunicaciones",
				table: "UsuariosRoles");

			migrationBuilder.DropColumn(
				name: "SMTP",
				table: "UsuariosRoles");
		}
	}
}
