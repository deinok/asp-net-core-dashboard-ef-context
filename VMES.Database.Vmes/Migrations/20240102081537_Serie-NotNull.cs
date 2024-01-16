using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class SerieNotNull : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "ContadorViajes",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorVentas",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true,
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorSalidas",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "ContadorRecetas",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "ContadorOrdenes",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "ContadorEntradas",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "ContadorCompras",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true,
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorCertificadoDesinfeccion",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "ContadorAlbaranes",
				table: "Series",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Series",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Series",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorViajes",
				table: "Series",
				type: "int",
				nullable: false,
				oldClrType: typeof(int),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorVentas",
				table: "Series",
				type: "int",
				nullable: true,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorSalidas",
				table: "Series",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorRecetas",
				table: "Series",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorOrdenes",
				table: "Series",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorEntradas",
				table: "Series",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorCompras",
				table: "Series",
				type: "int",
				nullable: true,
				defaultValueSql: "((0))",
				oldClrType: typeof(int),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorCertificadoDesinfeccion",
				table: "Series",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<int>(
				name: "ContadorAlbaranes",
				table: "Series",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldDefaultValueSql: "((0))");
		}
	}
}
