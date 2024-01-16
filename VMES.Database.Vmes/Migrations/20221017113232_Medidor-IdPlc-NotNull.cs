using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class MedidorIdPlcNotNull : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "IdPLC",
				table: "Medidores",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "IdPLC",
				table: "Medidores",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));
		}
	}
}
