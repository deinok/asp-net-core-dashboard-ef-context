using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class WarningsRemoveDefault : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "Activo",
				table: "ProductoMedidorCamino",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldDefaultValueSql: "1");

			migrationBuilder.AlterColumn<bool>(
				name: "ConOrigenes",
				table: "Modulos",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<bool>(
				name: "ConDestinos",
				table: "Modulos",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldDefaultValueSql: "((0))");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "Activo",
				table: "ProductoMedidorCamino",
				type: "bit",
				nullable: false,
				defaultValueSql: "1",
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "ConOrigenes",
				table: "Modulos",
				type: "bit",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "ConDestinos",
				table: "Modulos",
				type: "bit",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(bool));
		}
	}
}
