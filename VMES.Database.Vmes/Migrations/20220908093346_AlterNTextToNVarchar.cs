using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class AlterNTextToNVarchar : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Descripción",
				table: "AlertasUsuariosInformesParametros",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Mensaje",
				table: "AlertasUsuariosInformes",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "smtpMensaje",
				table: "AlertasUsuarios",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Descripción",
				table: "AlertasUsuariosInformesParametros",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Mensaje",
				table: "AlertasUsuariosInformes",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "smtpMensaje",
				table: "AlertasUsuarios",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);
		}
	}
}
