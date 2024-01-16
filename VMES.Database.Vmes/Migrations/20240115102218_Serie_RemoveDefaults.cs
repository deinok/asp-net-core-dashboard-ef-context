using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class Serie_RemoveDefaults : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Series",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldDefaultValueSql: "((0))");

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Series",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldDefaultValueSql: "((0))");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Series",
				type: "bit",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Series",
				type: "bit",
				nullable: false,
				defaultValueSql: "((0))",
				oldClrType: typeof(bool));
		}
	}
}
