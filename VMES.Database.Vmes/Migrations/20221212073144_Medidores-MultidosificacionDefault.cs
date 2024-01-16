using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class MedidoresMultidosificacionDefault : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "ModoMultidosificacion",
				table: "Medidores",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<bool>(
				name: "ModoMultidosificacion",
				table: "Medidores",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));
		}
	}
}
