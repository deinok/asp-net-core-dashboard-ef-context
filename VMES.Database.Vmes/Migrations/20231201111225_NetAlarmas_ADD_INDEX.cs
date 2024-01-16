using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class NetAlarmas_ADD_INDEX : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_NetAlarmas_IdModulo] ON [NetAlarmas];");
			migrationBuilder.Sql("CREATE INDEX [IX_NetAlarmas_IdModulo] ON [NetAlarmas]([Id]);");
			migrationBuilder.DropIndex(
				name: "IX_NetAlarmas_IdModulo",
				table: "NetAlarmas");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_IdModulo_Enviada_PostEnvioProcesada",
				table: "NetAlarmas",
				columns: new[] { "IdModulo", "Enviada", "PostEnvioProcesada" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				name: "IX_NetAlarmas_IdModulo_Enviada_PostEnvioProcesada",
				table: "NetAlarmas");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_IdModulo",
				table: "NetAlarmas",
				column: "IdModulo");
		}
	}
}
