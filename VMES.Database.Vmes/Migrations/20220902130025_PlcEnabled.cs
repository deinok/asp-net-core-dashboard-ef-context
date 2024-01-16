using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class PlcEnabled : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Nombre",
				table: "OpcConfig",
				maxLength: 64,
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(50)",
				oldMaxLength: 50,
				oldNullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "PlcEnabled",
				table: "Motores",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "PlcEnabled",
				table: "Electrovalvulas",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PlcEnabled",
				table: "Motores");

			migrationBuilder.DropColumn(
				name: "PlcEnabled",
				table: "Electrovalvulas");

			migrationBuilder.AlterColumn<string>(
				name: "Nombre",
				table: "OpcConfig",
				type: "nvarchar(50)",
				maxLength: 50,
				nullable: true,
				oldClrType: typeof(string),
				oldMaxLength: 64,
				oldNullable: true);
		}
	}
}
