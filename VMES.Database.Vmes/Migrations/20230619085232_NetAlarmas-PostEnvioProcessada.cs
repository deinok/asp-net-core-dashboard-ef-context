using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class NetAlarmasPostEnvioProcessada : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "PostEnvioProcesada",
				table: "NetAlarmas",
				nullable: false,
				defaultValue: false);
			migrationBuilder.Sql("UPDATE [NetAlarmas] SET [PostEnvioProcesada] = 1;");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PostEnvioProcesada",
				table: "NetAlarmas");
		}
	}
}
