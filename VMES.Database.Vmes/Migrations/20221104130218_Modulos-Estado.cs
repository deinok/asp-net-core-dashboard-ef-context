using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ModulosEstado : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("UPDATE [Modulos] SET [Estado] = 0 WHERE [Estado] IS NULL;");
			migrationBuilder.AlterColumn<int>(
				name: "Estado",
				table: "Modulos",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "Estado",
				table: "Modulos",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));
		}
	}
}
