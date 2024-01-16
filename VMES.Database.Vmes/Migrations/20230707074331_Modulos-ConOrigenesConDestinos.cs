using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ModulosConOrigenesConDestinos : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "ConOrigenes",
				table: "Modulos",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "ConDestinos",
				table: "Modulos",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "ConOrigenes",
				table: "Modulos",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<bool>(
				name: "ConDestinos",
				table: "Modulos",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool),
				oldDefaultValueSql: "((0))");
		}
	}
}
