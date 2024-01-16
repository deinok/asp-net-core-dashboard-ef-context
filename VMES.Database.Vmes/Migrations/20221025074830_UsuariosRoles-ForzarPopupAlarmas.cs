using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class UsuariosRolesForzarPopupAlarmas : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "ForzarPopupAlarmas",
				table: "UsuariosRoles",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ForzarPopupAlarmas",
				table: "UsuariosRoles");
		}
	}
}
