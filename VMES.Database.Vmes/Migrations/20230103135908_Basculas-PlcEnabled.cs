using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class BasculasPlcEnabled : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "PlcEnabled",
				table: "Basculas",
				nullable: false,
				defaultValue: false);
			migrationBuilder.Sql("UPDATE [Basculas] SET [PlcEnabled] = 1 WHERE [PosicionPLC] >= 0 AND [EnviarDatosAPLC] = 1;");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PlcEnabled",
				table: "Basculas");
		}
	}
}
