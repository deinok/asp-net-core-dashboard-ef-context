using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class MedidorModuloNotNull : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "Modulo",
				table: "Medidores",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "PlcEnabled",
				table: "Medidores",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PlcEnabled",
				table: "Medidores");

			migrationBuilder.AlterColumn<int>(
				name: "Modulo",
				table: "Medidores",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));
		}
	}
}
