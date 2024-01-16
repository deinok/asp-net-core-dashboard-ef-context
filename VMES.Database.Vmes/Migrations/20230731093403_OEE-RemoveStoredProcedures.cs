using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class OEERemoveStoredProcedures : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP FUNCTION IF EXISTS [VerTurno];");
			migrationBuilder.Sql("DROP FUNCTION IF EXISTS [VerTurnoId];");
			migrationBuilder.Sql("DROP FUNCTION IF EXISTS [udfRankingProductosFechas];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [AlarmasTop10Modulo];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [CalculoKWVentana];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [ConsumoKWMotores];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [ConsumoKWMotoresSecciones];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [EnergiaRellenoAlarmasSobreConsumo];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [GenerarKWEnOrdenesTeoricos];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [LimpiezaBuffers];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [OEEDesgloses];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [OEEEstadosFechaCompleto];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [OEEEStadosFechaIntervalos];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [OEEGenerarDatosFalsos];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [P_ERPProductoUbicacion];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [P_ERPStockDisponibleCargaSilo];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [RangoConsumoKWMotores];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [RangoConsumoKWMotoresSumas];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [RangoConsumoKWSecciones];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [RangoConsumoKWSeccionesSumas];");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [spReseedUserTables];");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
