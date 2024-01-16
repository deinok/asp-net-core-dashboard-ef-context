using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class UbicacionesOpcConfigPlcEnabled : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "PlcEnabled",
				table: "UbicacionesOpcConfig",
				nullable: false,
				defaultValue: false);
			migrationBuilder.Sql("UPDATE [UbicacionesOpcConfig] SET [PlcEnabled] = 1;");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PlcEnabled",
				table: "UbicacionesOpcConfig");
		}
	}
}
