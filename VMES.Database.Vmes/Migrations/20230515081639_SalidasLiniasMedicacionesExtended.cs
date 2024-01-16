using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class SalidasLiniasMedicacionesExtended : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
				ALTER VIEW [SalidasLiniasMedicacionesExtended] AS
				SELECT
					SLM.id,
					SLM.idSalidaLinia,
					PR.Id AS idMedicamento,
					PR.Nombre AS MedicamentoNombre,
					PR.Referencia AS MedicamentoReferencia,
					SLM.Cantidad,
					SLM.IdUnidad,
					Uni.Nombre AS UnidadTexto,
					SLM.Bultos,
					SLM.idFormato,
					Form.Nombre AS FormatoNombre,
					Form.Descripcion AS FormatoDescripcion,
					SLM.idEnvase,
					Enva.Nombre AS EnvaseNombre,
					SLM.PrecioUnidad,
					NULL AS IdMonedaPrecioUnidad,
					NULL AS MonedaPrecioUnidadStr,
					SLM.Estado,
					[dbo].GetTextoParametro('SalidasLiniasMedicaciones', 'Estado', SLM.Estado) AS EstadoStr,
					SLM.Precio,
					NULL AS IdMonedaPrecio,
					NULL AS MonedaPrecioStr,
					SLM.Fecha,
					SLM.idOrigen,
					UbiOrig.Nombre AS OrigenNombre
				FROM
					[SalidasLiniasMedicaciones] AS SLM
				LEFT OUTER JOIN Productos AS PR ON SLM.ProductoId = Pr.Id
				LEFT OUTER JOIN SalidasLinias as SL ON SLM.idSalidaLinia = SL.id
				LEFT OUTER JOIN Medicaciones AS Medi ON Medi.Id = SL.MedicacionId
				LEFT OUTER JOIN Ubicaciones AS UbiOrig ON UbiOrig.Id = SLM.idOrigen
				LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = SLM.IdUnidad
				LEFT OUTER JOIN Envases AS Enva ON Enva.Id = SLM.IdEnvase
				LEFT OUTER JOIN Formatos AS Form ON Form.Id = SLM.[IdFormato];
			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
