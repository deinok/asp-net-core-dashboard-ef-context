using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ModulosPlcEnabled : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "PlcEnabled",
				table: "Modulos",
				nullable: false,
				defaultValue: false);
			migrationBuilder.Sql("UPDATE [Modulos] SET [PlcEnabled] = 1 WHERE [idPLC] >= 1;");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PlcEnabled",
				table: "Modulos");
		}
	}
}
